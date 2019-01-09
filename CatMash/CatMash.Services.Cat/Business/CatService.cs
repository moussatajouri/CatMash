using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatMash.Services.Cat.DataAccess;
using CatMash.Services.Cat.Messages;
using CatMash.Services.Cat.Model;
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

            var cats = new List<Model.Cat>();

            foreach (var cat in dbCats)
            {
                cats.Add(new Model.Cat
                {
                    Id = cat.CatId,
                    Url = cat.Url,
                    Score = ScoreHelpler.CalculateScore(cat.TVoteWinCat.Count(), cat.TVoteLostCat.Count())
                });
            }

            return new GetCatScoresResponse { Cats = cats.OrderByDescending(c => c.Score?.Value) };

        }

        public Tuple<Model.Cat, Model.Cat> GetCandidatesCats()
        {
            var firstCat = _catRepository.GetRandomCat().ToModelCat();

            Model.Cat secondCat = null;
            var isSecond = false;
            var maxTries = 30;
            var tries = 0;

            while (!isSecond && tries < maxTries)
            {
                tries++;

                var cat = _catRepository.GetRandomCat().ToModelCat();
                if (cat.Id != firstCat.Id)
                {
                    secondCat = cat;
                    isSecond = true;
                }
            }

            if (secondCat == null)
            {
                return null;
            }
            else
            {
                return Tuple.Create(firstCat, secondCat);
            }

        }

        public bool InsertVote(VoteRequest voteRequest)
        {
            var vote = VoteMapper.Map(voteRequest);
            var updateCount = _catRepository.AddVote(vote);

            return updateCount > 0;
        }
    }
}
