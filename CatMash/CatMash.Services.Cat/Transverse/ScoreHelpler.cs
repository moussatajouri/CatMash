using CatMash.Services.Cat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.Services.Cat.Transverse
{
    public static class ScoreHelpler
    {
        private static readonly int WIN_WEIGHT = 5;
        private static readonly int LOST_WEIGHT = 1;

        public static Score CalculateScore(int totalVote, int winVoteCount, int lostVoteCount)
        {
            return new Score
            {
                LostVoteCount = lostVoteCount,
                WinVoteCount = winVoteCount,
                Value = totalVote == 0 ? 0 : (winVoteCount * WIN_WEIGHT - lostVoteCount * LOST_WEIGHT) / totalVote
            };
        }
    }
}
