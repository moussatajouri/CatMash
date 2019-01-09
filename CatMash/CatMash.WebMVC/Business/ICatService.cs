using CatMash.WebMVC.Domain;
using CatMash.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.WebMVC.Business
{
    public interface ICatService
    {
        Task<CatScoresModel> GetCatScores();

        Task SendVote(VoteModel vote);

        Task<Tuple<Cat, Cat>> GetCatsForVote();
    }
}
