using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyZoo.Common.Cages;
using MyZoo.DataAccess.Core;
using NUnit.Framework;
using ServiceStack;
using Assert = NUnit.Framework.Assert;

namespace MyZoo.Business.Services.Tests
{
    [TestClass]
    class CagesServicesTests
    {
        private readonly CagesRepository _cagesRepository = new CagesRepository();
        private readonly CagesServices _cagesServices = new CagesServices();
    
        #region Create cages

        [Test]
        public void CreateCageForMammal()
        {
            //arange
            var CageToCreate = new List<Cages> {Cages.ForMammal};
            const Cages actualCage = Cages.ForMammal;

            //act
            _cagesServices.CreateCage(CageToCreate);
            var expectedCage = _cagesRepository.GetLastCreatedCage();

            //assert
            Assert.AreEqual(expected:expectedCage.ToJson(), actual:actualCage.ToJson());
        }

        [Test]
        public void CreateCageForBird()
        {
            //arange
            var CageToCreate = new List<Cages> {Cages.ForBird};
            const Cages expectedlCage = Cages.ForBird;

            //act
            _cagesServices.CreateCage(CageToCreate);
            var actualCage = _cagesRepository.GetLastCreatedCage();

            //assert
            Assert.AreEqual(expected: expectedlCage.ToJson(), actual: actualCage.ToJson());
        }

        [Test]
        public void CreateCageForReptile()
        {
            //arange
            var CageToCreate = new List<Cages> { { Cages.ForReptile } };
            const Cages actualCage = Cages.ForReptile;

            //act
            _cagesServices.CreateCage(CageToCreate);
            var expectedCage = _cagesRepository.GetLastCreatedCage();

            //assert
            Assert.AreEqual(expected: expectedCage.ToJson(), actual: actualCage.ToJson());
        }

        #endregion

        #region Get all existing cages

        [Test]

        public void GetAllCagesAsList()
        {
            //arrange
            
            //act
            var expectedCagesList = _cagesRepository.GetAll();
            var actualCagesList = _cagesServices.GetAllExistCages();

            //assert
            Assert.AreEqual(expected: expectedCagesList.ToJson(), actual:actualCagesList.ToJson());
        }

        #endregion

    }
}
