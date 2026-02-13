using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDBContext _context;
        public PortfolioRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Portfolio> CreateUserPortfolioAsync(string userId, int stockId)
        {
            var portfolioModel = new Portfolio
            {
                StockId = stockId,
                AppUserId = userId
            };

            await _context.Portfolios.AddAsync(portfolioModel);
            await _context.SaveChangesAsync();
            return portfolioModel;
        }

        public async Task<Portfolio?> GetByUserStockIdAsync(string userId, int stockId)
        {
            return await _context.Portfolios.FirstOrDefaultAsync(x => x.StockId == stockId && x.AppUserId == userId);
        }

        public async Task<Portfolio?> DeletePortfolioAsync(string userId, int stockId)
        {
            var portfolio = await GetByUserStockIdAsync(userId, stockId);

            if (portfolio == null)
            {
                return null;
            }

            _context.Portfolios.Remove(portfolio);
            await _context.SaveChangesAsync();
            return portfolio;
        }

        public async Task<List<Stock>> GetUserPortfolioAsync(AppUser user)
        {
            return await _context.Portfolios.Where(u => u.AppUserId == user.Id)
                .Select(stock => new Stock
                {
                    Id = stock.StockId,
                    Symbol = stock.Stock.Symbol,
                    CompanyName = stock.Stock.CompanyName,
                    Purchase = stock.Stock.Purchase,
                    LastDiv = stock.Stock.LastDiv,
                    Industry = stock.Stock.Industry,
                    MarketCap = stock.Stock.MarketCap,
                    Comments = stock.Stock.Comments
                }).ToListAsync();
        }
    }
}