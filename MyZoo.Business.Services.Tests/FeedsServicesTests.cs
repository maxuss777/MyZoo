using System.Collections.Generic;
using MyZoo.Common.Feeds;
using MyZoo.DataAccess.Core;
using NUnit.Framework;
using ServiceStack;

namespace MyZoo.Business.Services.Tests
{
    public class FeedsServicesTests
    {
        private readonly FeedsRepository _feedsRepository = new FeedsRepository();
        private readonly FeedsServices _feedsServices = new FeedsServices();

        #region Create feeds

        [Test]
        public void CreateCageForMammal()
        {
            //arange
            var FeedToCreate = new List<Feeds> { Feeds.ForMammal };
            const Feeds actualFeed = Feeds.ForMammal;

            //act
            _feedsServices.CreateFeed(FeedToCreate);
            var expectedFeed = _feedsRepository.GetLastCreatedFeed();

            //assert
            Assert.AreEqual(expected: expectedFeed.ToJson(), actual: actualFeed.ToJson());
        }

        [Test]
        public void CreateFeedForBird()
        {
            //arange
            var FeedToCreate = new List<Feeds> { Feeds.ForBird };
            const Feeds expectedFeed = Feeds.ForBird;

            //act
            _feedsServices.CreateFeed(FeedToCreate);
            var actualFeed = _feedsRepository.GetLastCreatedFeed();

            //assert
            Assert.AreEqual(expected: expectedFeed.ToJson(), actual: actualFeed.ToJson());
        }

        [Test]
        public void CreateFeedForReptile()
        {
            //arange
            var feedToCreate = new List<Feeds> { Feeds.ForReptile };
            const Feeds actualFeed = Feeds.ForReptile;

            //act
            _feedsServices.CreateFeed(feedToCreate);
            var expectedFeed = _feedsRepository.GetLastCreatedFeed();

            //assert
            Assert.AreEqual(expected: expectedFeed.ToJson(), actual: actualFeed.ToJson());
        }

        #endregion

        #region Get all existing feeds

        [Test]

        public void GetAllFeedsAsList()
        {
            //arrange

            //act
            var expectedFeedsList = _feedsRepository.GetAll();
            var actualFeedsList = _feedsServices.GetAllExistinfFeeds();

            //assert
            Assert.AreEqual(expected: expectedFeedsList.ToJson(), actual: actualFeedsList.ToJson());
        }

        #endregion
    }
}
