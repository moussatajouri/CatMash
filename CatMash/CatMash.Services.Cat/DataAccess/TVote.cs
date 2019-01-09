using System;
using System.Collections.Generic;

namespace CatMash.Services.Cat.DataAccess
{
    public partial class TVote
    {
        public int VoteId { get; set; }
        public int WinCatId { get; set; }
        public int LostCatId { get; set; }
        public DateTime? CreationDate { get; set; }

        public TCat LostCat { get; set; }
        public TCat WinCat { get; set; }
    }
}
