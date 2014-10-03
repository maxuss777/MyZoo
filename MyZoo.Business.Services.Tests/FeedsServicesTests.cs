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
        public void CreateFeedForMammal()
        {
            //arange
            var feedToCreate = new List<Feeds> {Feeds.ForMammal};
            const Feeds actualFeed = Feeds.ForMammal;

            //act
            _feedsServices.CreateFeeds(feedToCreate);
            var expectedFeed = _feedsRepository.GetLastCreatedFeed();

            //assert
            Assert.AreEqual(expected: expectedFeed.ToJson(), actual: actualFeed.ToJson());
        }

        [Test]
        public void CreateFeedForBird()
        {
            //arange
            var feedToCreate = new List<Feeds> {Feeds.ForBird};
            const Feeds expectedFeed = Feeds.ForBird;

            //act
            _feedsServices.CreateFeeds(feedToCreate);
            var actualFeed = _feedsRepository.GetLastCreatedFeed();

            //assert
            Assert.AreEqual(expected: expectedFeed.ToJson(), actual: actualFeed.ToJson());
        }

        [Test]
        public void CreateFeedForReptile()
        {
            //arange
            var feedToCreate = new List<Feeds> {Feeds.ForReptile};
            const Feeds actualFeed = Feeds.ForReptile;

            //act
            _feedsServices.CreateFeeds(feedToCreate);
            var expectedFeed = _feedsRepository.GetLastCreatedFeed();

            //assert
            Assert.AreEqual(expected: expectedFeed.ToJson(), actual: actualFeed.ToJson());
        }

        [Test]
        public void RandomCreateFeeds()
        {
            //arange
            List<Feeds> feedsToCreate = _feedsServices.CreateRandomFilledFeedsList();

            //act
            _feedsServices.CreateFeeds(feedsToCreate);
            List<Feeds> allExistingFeeds = _feedsRepository.GetAll();
            int j = allExistingFeeds.Count - 1;

            //assert
            for (int i = feedsToCreate.Count - 1; i >= 0; i--)
            {
                Assert.AreEqual(expected: feedsToCreate[i], actual: allExistingFeeds[j]);
                j--;
            }
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