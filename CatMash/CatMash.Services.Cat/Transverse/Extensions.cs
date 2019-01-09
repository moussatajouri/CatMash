using CatMash.Services.Cat.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.Services.Cat.Transverse
{
    public static class Extensions
    {
        public static Model.Cat ToModelCat(this TCat tCat)
        {
            if (tCat == null)
                return null;

            return new Model.Cat
            {
                Id = tCat.CatId,
                Url = tCat.Url,
            };
        }
    }
}
