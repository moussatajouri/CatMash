using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatMash.Services.Cat.DataAccess;
using CatMash.Services.Cat.Messages;
using CatMash.Services.Cat.Transverse;

namespace CatMash.Services.Cat.Business
{
    public class CatService : ICatService
    {
        private readonly ICatRepository _catRepository;

        public CatService(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public GetCatScoresResponse GetCatScores()
        {
            var dbCats = _catRepository.GetAllCat();
            var totalVote = _catRepository.VotesCount();

            var cats = new List<Model.Cat>();

            foreach (var cat in dbCats)
            {
                cats.Add(new Model.Cat
                {
                    Id = cat.CatId,
                    Url = cat.Url,
                    Score = ScoreHelpler.CalculateScore(totalVote, cat.TVoteWinCat.Count(), cat.TVoteLostCat.Count())
                });
            }

            return new GetCatScoresResponse { Cats = cats };

        }

        public bool InsertVote(VoteRequest voteRequest)
        {
            var vote = VoteMapper.Map(voteRequest);
            var updateCount = _catRepository.AddVote(vote);

            return updateCount > 0;
        }
    }
}
