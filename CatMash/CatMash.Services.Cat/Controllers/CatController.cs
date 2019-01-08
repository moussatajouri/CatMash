using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatMash.Services.Cat.Messages;
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
                CatScores = new List<CatScore>()
                {
                    new CatScore{ CatId="1", Score=10 },
                    new CatScore{ CatId="2", Score=3 },
                    new CatScore{ CatId="3" }
                }
            };
            return Ok(catscoresResponses);
        }

        [HttpPut]
        [Route("vote/{catId}")]
        public void Vote(string catId)
        {
        }
    }
}
