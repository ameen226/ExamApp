using ExamApp.Application.Dtos.Auth;
using ExamApp.Application.Interfaces.Services;
using ExamApp.Domain.Enums;
using ExamApp.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;


        public AuthService(UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            IConfiguration config,
            SignInManager<IdentityUser> signInManager,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
            _config = config;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            

            if (user == null)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Errors = new List<string> { "Invalid credentials" }
                };
            }
            var student = await _unitOfWork.Students.GetByIdAsync(user.Id);

            if (role == Role.Student.ToString() && (student == null || !student.Enabled))
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Errors = new List<string> { "Your account is disabled" }
                };
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Errors = new List<string> { "Invalid credentials" }
                };
            }

            return await GenerateAuthResponse(user);
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
        {
            var user = new IdentityUser
            {
                Email = dto.Email,
                UserName = dto.Email.Substring(0, dto.Email.IndexOf('@')),
                LockoutEnabled = true
            };


            if (await _userManager.FindByEmailAsync(user.Email) != null)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Errors = new List<string> { "Email already exists" }
                };
            }

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
            }

            if (!await _roleManager.RoleExistsAsync(Role.Student.ToString()))
                await _roleManager.CreateAsync(new IdentityRole(Role.Student.ToString()));

            await _userManager.AddToRoleAsync(user, Role.Student.ToString());

            return await GenerateAuthResponse(user);

        }

        private async Task<AuthResponseDto> GenerateAuthResponse(IdentityUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role.ToLower())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(24),
                signingCredentials: creds
                );

            return new AuthResponseDto
            {
                Id = user.Id,
                Success = true,
                Email = user.Email,
                Role = role,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
