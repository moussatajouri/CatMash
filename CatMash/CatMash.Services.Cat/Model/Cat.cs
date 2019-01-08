using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.Services.Cat.Model
{
    public class Cat
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public Score Score { get; set; }
    }
}
