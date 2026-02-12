using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Stock;
using api.Extensions;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepo;
        private readonly IPortfolioRepository _portfolioRepo;
        public PortfolioController(
            UserManager<AppUser> userManager,
            IStockRepository stockRepo,
            IPortfolioRepository portfolioRepo
        )
        {
            _userManager = userManager;
            _stockRepo = stockRepo;
            _portfolioRepo = portfolioRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio()
        {
            var username = User.GetUserName();
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
            {
                return Unauthorized();
            }

            var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);
            var result = userPortfolio.Select(s => new StockDTO
            {
                Id = s.Id,
                Symbol = s.Symbol,
                CompanyName = s.CompanyName,
                Purchase = s.Purchase,
                LastDiv = s.LastDiv,
                Industry = s.Industry,
                MarketCap = s.MarketCap,
                Comments = s.Comments.Select(c => c.ToCommentDTO()).ToList()
            });

            return Ok(result);
        }
    }
}