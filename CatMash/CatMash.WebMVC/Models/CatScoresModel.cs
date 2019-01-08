using CatMash.WebMVC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.WebMVC.Models
{
    public class CatScoresModel
    {
        public IEnumerable<Cat> Cats { get; set; }
    }    
}
