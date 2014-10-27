using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyZoo.Common.Interfaces;
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
        private readonly CagesRepository _cagesRepository = new CagesRepository();
        private readonly CagesServices _cagesServices = new CagesServices();
        private IZooItems<Cage> _actualCage;

        #region Create cages

        [Test]
        public void CreateCage_ForMammal()
        {
            //arange
            var cageToCreate = new List<IZooItems<Cage>>
                {
                    new Cage("mammal", "tiger" )
                };

            //act
            _cagesServices.CreateCages(cageToCreate);

            _actualCage = _cagesRepository.GetLastCreatedItem();

            var expectedCage = _cagesRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: expectedCage.ToJson(), actual: _actualCage.ToJson());
        }

        [Test]
        public void CreateCage_ForBird()
        {
            //arange
            var cageToCreate = new List<IZooItems<Cage>>
                {
                    new Cage("bird","owl")
                };
            IZooItems<Cage> expectedlCage = new Cage("bird", "owl");

            //act
            _cagesServices.CreateCages(cageToCreate);
            var actualCage = _cagesRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: expectedlCage.ToJson(), actual: actualCage.ToJson());
        }

        [Test]
        public void CreateCage_ForReptile()
        {
            //arange
            var cageToCreate = new List<IZooItems<Cage>>
                {
                    new Cage("reptile","crocodile")
                };
            IZooItems<Cage> actualCage = new Cage("reptile", "crocodile");

            //act
            _cagesServices.CreateCages(cageToCreate);
            var expectedCage = _cagesRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: expectedCage.ToJson(), actual: actualCage.ToJson());
        }

        /*[Test]
        public void CreateRandomCages()
        {
            //arange
            var cagesToCreate = _cagesServices.CreateRandomFilledCagesList();

            //act

            _cagesServices.CreateCages(cagesToCreate);
            var allExistingCages = _cagesRepository.GetAllItems();
            int j = allExistingCages.Count - 1;

            //assert

            for (int i = cagesToCreate.Count - 1; i >= 0; i--)
            {
                Assert.AreEqual(expected: cagesToCreate[i], actual: allExistingCages[j]);
                j--;
            }
        }*/

        #endregion

        #region Get all existing cages

        [Test]
        public void GetAllCagesAsList()
        {
            //arrange

            //act
            var expectedCagesList = _cagesRepository.GetAllItems();
            var actualCagesList = _cagesServices.GetAllExistingCages();

            //assert
            Assert.AreEqual(expected: expectedCagesList.ToJson(), actual: actualCagesList.ToJson());
        }

        #endregion
    }
} 