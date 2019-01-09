using CatMash.WebMVC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.WebMVC.Models
{
    public class VoteModel
    {
        public Cat FirstCat { get; set; }

        public Cat SecondCat { get; set; }

        public int WinId { get; set; }

        public int LostId { get; set; }
    }
}
