using System;
using System.Collections.Generic;
using MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces;
using MyZoo.Common.Feeds;
using MyZoo.DataAccess.Core;
using NUnit.Framework;
using ServiceStack;

namespace MyZoo.Business.Services.Tests
{
    public class FeedsServicesTests
    {
        private readonly FeedsRepository _feedRepository = new FeedsRepository();
        private readonly FeedsServices _feedServices = new FeedsServices();
        private IFeed _actualFeed;
        private IFeed _expectedFeed;
        private List<IFeed> _actualFeedsList;
        private List<IFeed> _expectedFeedsList;

        #region Create feeds

        [Test]
        public void CreateFeed_With_Two_Parameter_In_Constructor()
        {
            //arrange
            _actualFeedsList = new List<IFeed>
                {
                    new Feed("meat", 10)
                };
            _expectedFeed = new Feed("meat", 10);

            //act
            _feedServices.CreateFeeds(_actualFeedsList);
            _actualFeed = _feedRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedFeed.ToJson(), actual: _actualFeed.ToJson());
        }

        [Test]
        public void CreateFeed_With_All_Parameters_In_Constructor()
        {
            //arrange
            _actualFeedsList = new List<IFeed>
            {
                new Feed("meat", 20, "Mammal")
            };
            _expectedFeed = new Feed("meat", 20, "Mammal");

            //act
            _feedServices.CreateFeeds(_actualFeedsList);
            _actualFeed = _feedRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedFeed.ToJson(), actual: _actualFeed.ToJson());
        }

        [Test]
        public void CreateFeed_FeedsListToCreateIsNull()
        {
            //arrange

            //act
            var exc = Assert.Throws<Exception>(() => _feedServices.CreateFeeds(null));

            //assert
            Assert.That(exc.Message, Is.EqualTo("Feeds list musn't be empty!"));
        }

        #endregion

        #region Get all existing feeds

        [Test]
        public void GetAlFeedsAsList()
        {
            //arrange

            //act
            _expectedFeedsList = (List<IFeed>)_feedRepository.GetAllItems();
            _actualFeedsList = (List<IFeed>)_feedServices.GetAllExistingFeeds();

            //assert
            Assert.AreEqual(expected: _expectedFeedsList.ToJson(), actual: _actualFeedsList.ToJson());
        }

        #endregion

        #region Get feed details

        [Test]
        public void GetFeedDetails()
        {
            //arrange
            var actualDetails = new[] { "meat", "30", "Mammal" };
            _actualFeed = new Feed("meat", 30, "Mammal");

            //act
            var expectedDetails = _actualFeed.ShowDetails();

            //assert
            Assert.AreEqual(expected: expectedDetails.ToJson(), actual: actualDetails.ToJson());
        }

        #endregion
    }
}