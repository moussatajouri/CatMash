using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.Services.Cat.Messages
{
    public class GetCatScoresResponse
    {
        public IEnumerable<CatScore> CatScores { get; set; }
    }
}
