using System;
using System.Collections.Generic;

namespace CatMash.Services.Cat.DataAccess
{
    public partial class TCat
    {
        public TCat()
        {
            TVoteLostCat = new HashSet<TVote>();
            TVoteWinCat = new HashSet<TVote>();
        }

        public int CatId { get; set; }
        public string Url { get; set; }

        public ICollection<TVote> TVoteLostCat { get; set; }
        public ICollection<TVote> TVoteWinCat { get; set; }
    }
}
