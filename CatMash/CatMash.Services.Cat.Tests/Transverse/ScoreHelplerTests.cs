using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using CatMash.Services.Cat.Transverse;

namespace CatMash.Services.Cat.Tests.Transverse
{
    public class ScoreHelplerTests
    {
        [Theory]
        [InlineData(0,0,0)]
        [InlineData(1, 0, 5)]
        [InlineData(3, 0, 15)]
        [InlineData(0, 1, -1)]
        [InlineData(0, 3, -3)]
        [InlineData(1, 5, 0)]
        [InlineData(2, 10, 0)]
        [InlineData(3, 15, 0)]
        [InlineData(1, 1, 4)]
        [InlineData(2, 2, 8)]
        [InlineData(3, 3, 12)]
        [InlineData(7, 7, 28)]
        [InlineData(3, 1, 14)]
        [InlineData(7, 1, 34)]
        [InlineData(1, 3, 2)]
        [InlineData(1, 9, -4)]
        public void Should_CalculateScore_Return_Score(int winVoteCount, int lostVoteCount, double expectedScoreValue)
        {
            var score = ScoreHelpler.CalculateScore(winVoteCount, lostVoteCount);

            Assert.NotNull(score);
            Assert.Equal(winVoteCount, score.WinVoteCount);
            Assert.Equal(lostVoteCount, score.LostVoteCount);
            Assert.Equal(expectedScoreValue, score.Value);
        }
    }
}
