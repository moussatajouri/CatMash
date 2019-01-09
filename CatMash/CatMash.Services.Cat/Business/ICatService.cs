using CatMash.Services.Cat.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.Services.Cat.Business
{
    public interface ICatService
    {
        GetCatScoresResponse GetCatScores();

        bool InsertVote(VoteRequest vote);
    }
}
