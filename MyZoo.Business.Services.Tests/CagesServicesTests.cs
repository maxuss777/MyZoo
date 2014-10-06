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
    public class CagesServicesTests
    {
        private readonly CagesRepository _cagesRepository = new CagesRepository();
        private readonly CagesServices _cagesServices = new CagesServices();
    
        #region Create cages

        [Test]
        public void CreateCageForMammal()
        {
            //arange
            var cageToCreate = new List<Cages> {Cages.ForMammal};
            const Cages actualCage = Cages.ForMammal;

            //act
            _cagesServices.CreateCage(cageToCreate);
            var expectedCage = _cagesRepository.GetLastCreatedCage();

            //assert
            Assert.AreEqual(expected:expectedCage.ToJson(), actual:actualCage.ToJson());
        }

        [Test]
        public void CreateCageForBird()
        {
            //arange
            var cageToCreate = new List<Cages> {Cages.ForBird};
            const Cages expectedlCage = Cages.ForBird;

            //act
            _cagesServices.CreateCage(cageToCreate);
            var actualCage = _cagesRepository.GetLastCreatedCage();

            //assert
            Assert.AreEqual(expected: expectedlCage.ToJson(), actual: actualCage.ToJson());
        }

        [Test]
        public void CreateCageForReptile()
        {
            //arange
            var cageToCreate = new List<Cages> { Cages.ForReptile };
            const Cages actualCage = Cages.ForReptile;

            //act
            _cagesServices.CreateCage(cageToCreate);
            var expectedCage = _cagesRepository.GetLastCreatedCage();

            //assert
            Assert.AreEqual(expected: expectedCage.ToJson(), actual: actualCage.ToJson());
        }

        [Test]
        public void RandomCreateCages()
        {
            //arange
            List<Cages> cagesToCreate = _cagesServices.CreateRandomFilledCagesList();
            

            //act
            _cagesServices.CreateCage(cagesToCreate);
            List<Cages> allExistingCages = _cagesRepository.GetAll();
            int j = -1;

            //assert
            for (int i = cagesToCreate.Count-1; i >= 0 ; i--)
            {
                j++;
                Assert.AreEqual(expected:cagesToCreate[i], actual:allExistingCages[j]);
                
            }

        }

        #endregion

        #region Get all existing cages

        [Test]

        public void GetAllCagesAsList()
        {
            //arrange
            
            //act
            var expectedCagesList = _cagesRepository.GetAll();
            var actualCagesList = _cagesServices.GetAllExistingCages();

            //assert
            Assert.AreEqual(expected: expectedCagesList.ToJson(), actual:actualCagesList.ToJson());
        }

        #endregion

    }
}
