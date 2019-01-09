using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.Services.Cat.DataAccess
{
    public class CatRepository : ICatRepository
    {
        private readonly CatDBContext _catDbContext;

        public CatRepository(CatDBContext catDbContext)
        {
            _catDbContext = catDbContext;
        }
        
        public IEnumerable<TCat> GetAllCat()
        {
            return _catDbContext.TCat.ToList();
        }

        public TCat GetCatById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return _catDbContext.TCat.Where(c => c.CatId == id).FirstOrDefault();
        }

        public int AddVote(TVote vote)
        {
            if(vote == null)
            {
                return 0;
            }

            if (vote.WinCatId <= 0 || vote.LostCatId <= 0 || vote.WinCatId == vote.LostCatId)
            {
                throw new Exception($"Invalid Vote. WinCatId: {vote.WinCatId} / LostCatId: {vote.LostCatId}");
            }

            if (_catDbContext.TCat.Where(c => c.CatId == vote.WinCatId).Count() <= 0)
            {
                throw new Exception($"Cat Not Found for this Vote. CatId : {vote.WinCatId}");
            }

            if (_catDbContext.TCat.Where(c => c.CatId == vote.LostCatId).Count() <= 0)
            {
                throw new Exception($"Cat Not Found for this Vote. CatId : {vote.LostCatId}");
            }

            try
            {
                _catDbContext.TVote.Add(vote);

                return _catDbContext.SaveChanges();
            }
            catch(Exception exp)
            {
                throw new Exception("DataAccessException", exp);
            }
        }
    }
}
