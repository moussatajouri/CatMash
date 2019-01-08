using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatMash.Services.Cat.Model;

namespace CatMash.Services.Cat.Messages
{
    public class GetCatScoresResponse
    {
        public IEnumerable<Model.Cat> Cats { get; set; }
    }
}
