using System.Threading.Tasks;
using api.Extensions;
using api.Interfaces;
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
        private readonly UserManager<AppUser> _usermanager;
        private readonly IStockRepo _stockrepo;
        private readonly IPortfolioRepo _portfoliorepo;

        public PortfolioController(UserManager<AppUser> user, IStockRepo stockRepo, IPortfolioRepo portfolioRepo)
        {
            _usermanager = user;
            _stockrepo = stockRepo;
            _portfoliorepo = portfolioRepo;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserPortfolio()
        {
            var username = User.GetUserName();
            var appUser = await _usermanager.FindByNameAsync(username);
            var userPortfolio = await _portfoliorepo.GetUserPortfolio(appUser);
            return Ok(userPortfolio);
        }
    }
}
