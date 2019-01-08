using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.WebMVC.Domain
{
    public class Score
    {
        public int LostVoteCount { get; set; }

        public int WinVoteCount { get; set; }

        public double Value { get; set; }
    }
}
