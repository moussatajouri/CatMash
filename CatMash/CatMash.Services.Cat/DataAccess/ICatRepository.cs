using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.Services.Cat.DataAccess
{
    public interface ICatRepository
    {
        TCat GetCatById(int id);

        IEnumerable<TCat> GetAllCat();

        int AddVote(TVote vote);
    }
}
