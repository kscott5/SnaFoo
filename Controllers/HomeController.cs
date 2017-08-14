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
    public class HomeController : Controller
    {
        private ILogger Logger {get; set;}
        private SnackService SnackService {get; set;}

        public HomeController(ILoggerFactory loggerFactory, SnackService snackService) : base() {
            this.Logger = loggerFactory.CreateLogger("Nerdy.Controllers.Home");
            this.SnackService = snackService;
        }
        private const string PAGE_TITLE = "SNA Foo - {0}";

        private void SetViewDataTitle(string title) {
            ViewData["Body_Title"] = title;
            ViewData["Title"] = string.Format(PAGE_TITLE, title);
        }

        [HttpPost]
        [Route("Home/Suggestions")]
        public IActionResult SnaFoo4([FromForm] string suggestionInput, [FromForm] string suggestionLocation  ) {
            this.Logger.LogDebug("Suggestions HttpPOST/Data: {0} - {1} ", suggestionInput, suggestionLocation);
            this.SnackService.SaveSnack(
                new Snack{
                    Id=SnackService.SNACK_ID++, 
                    Name=suggestionInput, 
                    PurchaseLocations = suggestionLocation}
            );
            
            return this.RedirectToAction("Suggestions", "Home");
        }

        [Route("Home/Voting")]
        [Route("")]
        public IActionResult SnaFoo3()
        {
            this.Logger.LogDebug("HttpGet: Voting");            
            this.SetViewDataTitle("Voting");

            var snacks = this.SnackService.GetSnacks();
            var data = new object[] {snacks, "testing"};
            return View(data);
        }

        [Route("Home/ShoppingList")]
        public IActionResult SnaFoo2()
        {
            this.SetViewDataTitle("Shopping List");
            var snacks = this.SnackService.GetSnacks();
            return View(snacks);
        }

        [Route("Home/Suggestions")]
        public IActionResult SnaFoo1()
        {
            this.SetViewDataTitle("Suggestions");

            var snacks = this.SnackService.GetSnacks();            
            return View(snacks);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
