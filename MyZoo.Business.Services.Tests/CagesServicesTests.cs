using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces;
using MyZoo.Common.ZooItems.BaseClasses;
using MyZoo.DataAccess.Core;
using NUnit.Framework;
using ServiceStack;
using Assert = NUnit.Framework.Assert;


namespace MyZoo.Business.Services.Tests
{
    [TestClass]
    public class CagesServicesTests
    {
        private readonly CagesRepository _cageRepository = new CagesRepository();
        private readonly CagesServices _cageServices = new CagesServices();
        private ICage _actualCage;
        private ICage _expectedCage;
        private List<ICage> _actualCagesList;
        private List<ICage> _expectedCagesList;
            
        #region Create cages

        [Test]
        public void CreateCage_With_One_Parameter_In_Constructor()
        {
            //arrange
            _actualCagesList = new List<ICage>
                {
                    new Cage("Mammal")
                };
            _expectedCage = new Cage("Mammal");

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
                new Cage("Mammal", 2, 3, 5)
            };
            _expectedCage = new Cage("Mammal", 2, 3, 5);

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
            var actualDetails = new[] { "Mammal", "2", "3", "5" };
            _actualCage = new Cage("Mammal", 2, 3, 5);

            //act
            var expectedDetails = _actualCage.ShowDetails();

            //assert
            Assert.AreEqual(expected: expectedDetails.ToJson(), actual: actualDetails.ToJson());
        }

        #endregion
    }
} 