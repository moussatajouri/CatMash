using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.Services.Cat.Messages
{
    public class VoteRequest
    {
        public int WinId { get; set; }

        public int LostId { get; set; }
    }
}
