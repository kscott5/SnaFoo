using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace nerdy.Controllers
{
    public class HomeController : Controller
    {
        private const string PAGE_TITLE = "SNA Foo - %0";

        private void SetViewDataTitle(string title) {
            ViewData["Body_Title"] = "Voting";
            ViewData["Title"] = string.Format(PAGE_TITLE, ViewData["Body_Title"]);            
        }

        [Route("Voting")]
        public IActionResult SnaFoo3()
        {
            this.SetViewDataTitle("Voting");
            return View();
        }

        [Route("ShoppingList")]
        public IActionResult SnaFoo2()
        {
            this.SetViewDataTitle("Shopping List");
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Route("Suggestions")]
        public IActionResult SnaFoo1()
        {
            this.SetViewDataTitle("Shopping List");
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
