using CatMash.Services.Cat.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;


namespace CatMash.Services.Cat.Tests.DataAccess
{
    public class CatRepositoryUnitTests
    {
        [Fact]
        public void Should_GetAllCat_Return_Null_When_Db_Is_Empty()
        {
            var options = new DbContextOptionsBuilder<CatDBContext>()
                .UseInMemoryDatabase(databaseName: "Should_GetAllCat_Return_Null_When_Db_Is_Empty")
                .Options;

            using (var context = new CatDBContext(options))
            {
                var catRepository = new CatRepository(context);
                var cats = catRepository.GetAllCat();

                Assert.NotNull(cats);
                Assert.Empty(cats);
            }
        }

        [Fact]
        public void Should_GetAllCat_Return_All_Cat_When_Db_Is_Not_Empty()
        {
            var options = new DbContextOptionsBuilder<CatDBContext>()
                .UseInMemoryDatabase(databaseName: "Should_GetAllCat_Return_All_Cat_When_Db_Is_Not_Empty")
                .Options;

            using (var context = new CatDBContext(options))
            {
                context.TCat.Add(new TCat { CatId = 1, Url = "url 1" });
                context.TCat.Add(new TCat { CatId = 2, Url = "url 2" });
                context.TCat.Add(new TCat { CatId = 3, Url = "url 3" });
                var updateCount = context.SaveChanges();

                Assert.Equal(3, updateCount);
            }

            using (var context = new CatDBContext(options))
            {
                var catRepository = new CatRepository(context);
                var cats = catRepository.GetAllCat();

                Assert.NotNull(cats);
                Assert.Equal(3, cats.Count());
                Assert.Single(cats.Where(c => c.Url == "url 1"));
                Assert.Single(cats.Where(c => c.Url == "url 2"));
                Assert.Single(cats.Where(c => c.Url == "url 3"));
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-99)]
        public void Should_GetCatById_return_Null_When_CatId_IsNegativeOrZero(int catId)
        {
            var catRepository = new CatRepository(null);

            var cat = catRepository.GetCatById(catId);

            Assert.Null(cat);
        }

        [Fact]
        public void Should_GetCatById_return_Null_When_Cat_IsNoutFound()
        {
            var options = new DbContextOptionsBuilder<CatDBContext>()
                .UseInMemoryDatabase(databaseName: "Should_GetCatById_return_Null_When_Cat_IsNoutFound")
                .Options;

            using (var context = new CatDBContext(options))
            {
                context.TCat.Add(new TCat { CatId = 1, Url = "url 1" });
                context.TCat.Add(new TCat { CatId = 2, Url = "url 2" });
                context.TCat.Add(new TCat { CatId = 3, Url = "url 3" });
                var updateCount = context.SaveChanges();

                Assert.Equal(3, updateCount);
            }

            using (var context = new CatDBContext(options))
            {
                var catRepository = new CatRepository(context);
                var cat = catRepository.GetCatById(5);

                Assert.Null(cat);
            }
        }

        [Fact]
        public void Should_GetCatById_return_Cat_When_Cat_Exist()
        {
            var options = new DbContextOptionsBuilder<CatDBContext>()
                .UseInMemoryDatabase(databaseName: "Should_GetCatById_return_Cat_When_Cat_Exist")
                .Options;

            using (var context = new CatDBContext(options))
            {
                context.TCat.Add(new TCat { CatId = 1, Url = "url 1" });
                context.TCat.Add(new TCat { CatId = 2, Url = "url 2" });
                context.TCat.Add(new TCat { CatId = 3, Url = "url 3" });
                var updateCount = context.SaveChanges();

                Assert.Equal(3, updateCount);
            }

            using (var context = new CatDBContext(options))
            {
                var catRepository = new CatRepository(context);
                var cat = catRepository.GetCatById(2);

                Assert.NotNull(cat);
                Assert.Equal("url 2", cat.Url);
            }
        }

        [Fact]
        public void Should_AddVote_Return_Zero_When_Vote_Is_Null()
        {
            var catRepository = new CatRepository(null);

            var updateCount = catRepository.AddVote(null);

            Assert.Equal(0, updateCount);
        }

        [Fact]
        public void Should_AddVote_Throw_Exception_When_WinCatId_Equal_LostCatId()
        {
            var catRepository = new CatRepository(null);

            var vote = new TVote { LostCatId = 5, WinCatId = 5 };

            var exception = Assert.Throws<Exception>(() => catRepository.AddVote(vote));
            Assert.Equal("Invalid Vote. WinCatId: 5 / LostCatId: 5", exception.Message);
        }

        [Fact]
        public void Should_AddVote_Throw_Exception_When_WinCat_NotFound()
        {
            var options = new DbContextOptionsBuilder<CatDBContext>()
                .UseInMemoryDatabase(databaseName: "Should_AddVote_Throw_Exception_When_WinCat_NotFound")
                .Options;

            using (var context = new CatDBContext(options))
            {
                context.TCat.Add(new TCat { CatId = 1, Url = "url 1" });
                context.TCat.Add(new TCat { CatId = 2, Url = "url 2" });
                context.TCat.Add(new TCat { CatId = 3, Url = "url 3" });
                var updateCount = context.SaveChanges();

                Assert.Equal(3, updateCount);
            }

            using (var context = new CatDBContext(options))
            {
                var catRepository = new CatRepository(context);

                var vote = new TVote { LostCatId = 1, WinCatId = 99 };

                var exception = Assert.Throws<Exception>(() => catRepository.AddVote(vote));
                Assert.Equal("Cat Not Found for this Vote. CatId : 99", exception.Message);
            }
        }

        [Fact]
        public void Should_AddVote_Throw_Exception_When_LostCat_NotFound()
        {
            var options = new DbContextOptionsBuilder<CatDBContext>()
                .UseInMemoryDatabase(databaseName: "Should_AddVote_Throw_Exception_When_LostCat_NotFound")
                .Options;

            using (var context = new CatDBContext(options))
            {
                context.TCat.Add(new TCat { CatId = 1, Url = "url 1" });
                context.TCat.Add(new TCat { CatId = 2, Url = "url 2" });
                context.TCat.Add(new TCat { CatId = 3, Url = "url 3" });
                var updateCount = context.SaveChanges();

                Assert.Equal(3, updateCount);
            }

            using (var context = new CatDBContext(options))
            {
                var catRepository = new CatRepository(context);

                var vote = new TVote { LostCatId = 99, WinCatId = 1 };

                var exception = Assert.Throws<Exception>(() => catRepository.AddVote(vote));
                Assert.Equal("Cat Not Found for this Vote. CatId : 99", exception.Message);
            }
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 5)]
        [InlineData(5, 0)]
        [InlineData(-1, 5)]
        [InlineData(5, -1)]
        [InlineData(-1, -1)]
        public void Should_AddVote_Throw_Exception_When_CatId_Is_Wrong(int winCatId, int lostCatId)
        {
            var catRepository = new CatRepository(null);

            var vote = new TVote { LostCatId = lostCatId, WinCatId = winCatId };

            var exception = Assert.Throws<Exception>(() => catRepository.AddVote(vote));
            Assert.Equal($"Invalid Vote. WinCatId: {winCatId} / LostCatId: {lostCatId}", exception.Message);

        }

        [Fact]
        public void Should_AddVote_Add_Vote_When_Is_Correct()
        {
            var options = new DbContextOptionsBuilder<CatDBContext>()
                .UseInMemoryDatabase(databaseName: "Should_AddVote_Add_Vote_When_Is_Correct")
                .Options;

            using (var context = new CatDBContext(options))
            {
                context.TCat.Add(new TCat { CatId = 1, Url = "url 1" });
                context.TCat.Add(new TCat { CatId = 2, Url = "url 2" });
                context.TCat.Add(new TCat { CatId = 3, Url = "url 3" });
                var updateCount = context.SaveChanges();

                Assert.Equal(3, updateCount);
            }

            using (var context = new CatDBContext(options))
            {
                var catRepository = new CatRepository(context);

                var vote = new TVote { LostCatId = 1, WinCatId = 2 };

                var updateCount = catRepository.AddVote(vote);
                Assert.Equal(1, updateCount);
            }
        }


    }
}
