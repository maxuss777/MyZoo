using System;
using System.Collections.Generic;
using MyZoo.Common.Interfaces;
using MyZoo.Common.ZooItems;
using MyZoo.DataAccess.Core;
using NUnit.Framework;
using ServiceStack;


namespace MyZoo.Business.Services.Tests
{
    public class CagesServicesTests
    {
        private readonly CagesRepository _cageRepository = new CagesRepository();
        private readonly CagesServices _cageServices = new CagesServices();
        private ICage _actualCage;
        private ICage _expectedCage;
        private ICage _lastCreatedCage;
        private List<ICage> _actualCagesList;
        private List<ICage> _expectedCagesList;
            
        #region Create cages

        [Test]
        public void CreateCage_With_One_Parameter_In_Constructor()
        {
            //arrange
            _actualCagesList = new List<ICage>
                {
                    new Cage(0, "Mammal")
                };
            _lastCreatedCage = _cageRepository.GetLastCreatedItem();
            _expectedCage = new Cage(_lastCreatedCage.Id + 1, "Mammal");

            //act
            _cageServices.CreateCages(_actualCagesList);
            _actualCage = _cageRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedCage.ToJson(), actual: _actualCage.ToJson());
        }

        [Test]
        public void CreateCage_With_All_Parameters_In_Constructor()
        {
            //arrange
            _actualCagesList = new List<ICage>
            {
                new Cage(0, "Mammal", 2, 3, 5)
            };
            _lastCreatedCage = _cageRepository.GetLastCreatedItem();
            _expectedCage = new Cage(_lastCreatedCage.Id + 1, "Mammal", 2, 3, 5);

            //act
            _cageServices.CreateCages(_actualCagesList);
            _actualCage = _cageRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedCage.ToJson(), actual: _actualCage.ToJson());
        }

        [Test]
        public void CreateCage_AnimalListToCreateIsNull()
        {
            //arrange

            //act
            var exc = Assert.Throws<Exception>(() => _cageServices.CreateCages(null));

            //assert
            Assert.That(exc.Message, Is.EqualTo("Cages list mustn't be empty!"));
        }

        #endregion

        #region Get all existing cages

        [Test]
        public void GetAllCagesAsList()
        {
            //arrange

            //act
            _expectedCagesList = (List<ICage>) _cageRepository.GetAllItems();
            _actualCagesList = (List<ICage>)_cageServices.GetAllExistingCages();

            //assert
            Assert.AreEqual(expected: _expectedCagesList.ToJson(), actual: _actualCagesList.ToJson());
        }

        #endregion

        #region Get cage details

        [Test]
        public void GetCageDetails()
        {
            //arrange
            var actualDetails = new[] {"0", "Mammal", "2", "3", "5" };
            _actualCage = new Cage(0, "Mammal", 2, 3, 5);

            //act
            var expectedDetails = _actualCage.ShowDetails();

            //assert
            Assert.AreEqual(expected: expectedDetails.ToJson(), actual: actualDetails.ToJson());
        }

        #endregion

        #region Create cages randomly

        [Test]
        public void CreateCagesRandomly()
        {
            //arrange
            _expectedCage = _cageRepository.GetLastCreatedItem();
            
            //act
            _cageServices.CreateCageRandomly(typeof(Animal));
            _actualCage = _cageRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedCage.Id + 1, actual: _actualCage.Id);
        }

        #endregion
    }
}