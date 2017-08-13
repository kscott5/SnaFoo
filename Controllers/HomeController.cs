using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using nerdy.Models;
using nerdy.Services;

namespace nerdy.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private ILogger logger;
        private SnackService snackService;

        public HomeController(ILoggerFactory loggerFactory, SnackService snackService) : base() {
            this.logger = loggerFactory.CreateLogger("Nerdy.Controllers.Home");
            this.snackService = snackService;
        }
        private const string PAGE_TITLE = "SNA Foo - %s";

        private void SetViewDataTitle(string title) {
            ViewData["Body_Title"] = title;
            ViewData["Title"] = string.Format(PAGE_TITLE, title);
        }

        [HttpPost]
        [Route("Suggestions")]
        public void SnaFoo4([FromForm] string suggestionsInput, [FromForm] string suggestionLocation  ) {
            this.logger.LogDebug("Suggestions HttpPOST/Data: %1 %2", suggestionsInput, suggestionLocation);
            this.RedirectToAction("Suggestions");
        }

        [Route("Voting")]
        public IActionResult SnaFoo3()
        {
            this.logger.LogDebug("HttpGet: Voting");

            this.SetViewDataTitle("Voting");
            return View();
        }

        [Route("ShoppingList")]
        public IActionResult SnaFoo2()
        {
            this.SetViewDataTitle("Shopping List");
            return View();
        }

        [Route("Suggestions")]
        public IActionResult SnaFoo1()
        {
            this.SetViewDataTitle("Suggestions");

            var snacks = this.snackService.GetSnacks();            
            return View(snacks);
        }

        [Route("Error")]
        public IActionResult Error()
        {
            return View();
        }
    }
}
