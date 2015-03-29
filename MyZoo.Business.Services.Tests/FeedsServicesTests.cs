using System;
using System.Collections.Generic;
using MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces;
using MyZoo.Common.Animal.ZooItems.Animals;
using MyZoo.Common.ZooItems;
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
        private IFeed _lastCreatedFeed;
        private List<IFeed> _actualFeedsList;
        private List<IFeed> _expectedFeedsList;

        #region Create feeds

        [Test]
        public void CreateFeed_With_One_Parameter_In_Constructor()
        {
            //arrange
            _actualFeedsList = new List<IFeed>
                {
                    new Feed(0, "Mammal")
                };
            _lastCreatedFeed = _feedRepository.GetLastCreatedItem();
            _expectedFeed = new Feed(_lastCreatedFeed.Id + 1, "Mammal");

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
                    new Feed(0, "meat", 20, "Mammal")
                };
            _lastCreatedFeed = _feedRepository.GetLastCreatedItem();
            _expectedFeed = new Feed(_lastCreatedFeed.Id + 1, "meat", 20, "Mammal");

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
            _expectedFeedsList = (List<IFeed>) _feedRepository.GetAllItems();
            _actualFeedsList = (List<IFeed>) _feedServices.GetAllExistingFeeds();

            //assert
            Assert.AreEqual(expected: _expectedFeedsList.ToJson(), actual: _actualFeedsList.ToJson());
        }

        #endregion

        #region Get feed details

        [Test]
        public void GetFeedDetails()
        {
            //arrange
            var actualDetails = new[] {"0", "meat", "30", "Mammal"};
            _actualFeed = new Feed(0, "meat", 30, "Mammal");

            //act
            var expectedDetails = _actualFeed.ShowDetails();

            //assert
            Assert.AreEqual(expected: expectedDetails.ToJson(), actual: actualDetails.ToJson());
        }

        #endregion

        #region Create feeds randomly

        [Test]
        public void CreateFeedRandomly()
        {
            //arange
            _expectedFeed = _feedRepository.GetLastCreatedItem();

            //act
            _feedServices.CreateFeedsRandomly(typeof (Animal));
            _actualFeed = _feedRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedFeed.Id + 1, actual: _actualFeed.Id);
        }

        #endregion
    }
}