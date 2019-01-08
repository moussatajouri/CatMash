using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatMash.WebMVC.Domain;
using CatMash.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatMash.WebMVC.Controllers
{
    public class CatController : Controller
    {
        public IActionResult Scores()
        {
            var model = new CatScoresModel
            {
                Cats = new List<Cat>
                {
                    new Cat{ Id=1, Url="http://24.media.tumblr.com/tumblr_m82woaL5AD1rro1o5o1_1280.jpg", Score= new Score{ LostVoteCount=1, WinVoteCount = 3, Value= 10.2 } },
                    new Cat{ Id=2, Url="http://24.media.tumblr.com/tumblr_m82woaL5AD1rro1o5o1_1280.jpg", Score= new Score{ LostVoteCount=3, WinVoteCount = 0, Value= 5 } },
                    new Cat{ Id=3, Url="http://24.media.tumblr.com/tumblr_lzxok2e2kX1qgjltdo1_1280.jpg", Score= new Score{ LostVoteCount=0, WinVoteCount = 2, Value= 2 } }
                }
            };

            return View(model);
        }

        public IActionResult Vote()
        {
            var model = new VoteModel
            {
                FirstCat = new Cat { Id = 1, Url = "http://24.media.tumblr.com/tumblr_m82woaL5AD1rro1o5o1_1280.jpg" },
                SecondCat = new Cat { Id = 2, Url = "http://24.media.tumblr.com/tumblr_m29a9d62C81r2rj8po1_500.jpg" },
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Vote([FromBody]VoteModel model)
        {
            return Ok();
        }

    }
}