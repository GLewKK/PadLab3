using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pad.Domain.Entities;
using Pad.Domain.Enums;
using Pad.Representation.Abstractions;
using Pad.Web.Models;

namespace Pad.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _manager;
        private readonly IUserConfigurationRepository _repository;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> manager, IUserConfigurationRepository repository)
        {
            _logger = logger;
            _manager = manager;
            _repository = repository;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = _manager.GetUserId(User);

                var configuration = _repository.GetByUserId(userId);

                if (configuration is null)
                {
                    _repository.Add(new UserConfiguration { UserId = new Guid(userId) });
                }

            }
            return View();
        }

        [Cached(600)]
        [Route("user-data")]
        [HttpGet]
        public IActionResult GetCurrentUserData()
        {
            var userId = _manager.GetUserId(User);

            return Ok(_repository.GetByUserId(userId));
        }
        public IActionResult Privacy()          
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
