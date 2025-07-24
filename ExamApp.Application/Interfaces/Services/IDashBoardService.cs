using ExamApp.Application.Common.Models;
using ExamApp.Application.Dtos.DashBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Interfaces.Services
{
    public interface IDashBoardService
    {
        Task<Response<DashBoardDto>> GetDashBoardStatesAsync();
    }
}
