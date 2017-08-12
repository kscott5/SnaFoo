using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace nerdy.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private ILogger logger;


        public HomeController(ILoggerFactory loggerFactory) : base() {
            this.logger = loggerFactory.CreateLogger("HomeController");
        }
        private const string PAGE_TITLE = "SNA Foo - %0";

        private void SetViewDataTitle(string title) {
            ViewData["Body_Title"] = title;
            ViewData["Title"] = string.Format(PAGE_TITLE, title);
        }

        [HttpPost]
        [Route("Suggestions")]
        public void SnaFoo4([FromForm] string suggestionsInput, [FromForm] string suggestionLocation  ) {
            
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
            return View();
        }

        [Route("Error")]
        public IActionResult Error()
        {
            return View();
        }
    }
}
