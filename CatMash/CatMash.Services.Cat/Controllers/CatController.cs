using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatMash.Services.Cat.Messages;
using CatMash.Services.Cat.Model;
using Microsoft.AspNetCore.Mvc;

namespace CatMash.Services.Cat.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CatController : ControllerBase
    {
        [HttpGet]
        [Route("scores")]
        public IActionResult GetScores()
        {
            var catscoresResponses = new GetCatScoresResponse
            {
                Cats = new List<Model.Cat>()
                {
                    new Model.Cat{ Id = 1, Score= new Score{LostVoteCount= 1, WinVoteCount = 5, Value=10.2 } },
                    new Model.Cat{ Id = 2, Score= new Score{LostVoteCount= 1, WinVoteCount = 5, Value=10.2 }  },
                    new Model.Cat{ Id = 3 }
                }
            };
            return Ok(catscoresResponses);
        }

        [HttpPost]
        [Route("vote")]
        public void Vote([FromBody]VoteRequest voteRequest)
        {

        }
    }
}
