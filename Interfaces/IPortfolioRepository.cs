using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<List<Stock>> GetUserPortfolioAsync(AppUser appUser);
        Task<Portfolio?> GetByUserStockIdAsync(string userId, int stockId);
        Task<Portfolio> CreateUserPortfolioAsync(string userId, int stockId);
        Task<Portfolio?> DeletePortfolioAsync(string userId, int stockId);
    }
}