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

        public int WinCatId { get; set; }

        public int LostCatId { get; set; }
    }
}
