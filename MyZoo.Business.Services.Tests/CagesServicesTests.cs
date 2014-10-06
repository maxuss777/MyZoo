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
        public void CreateCage_ForMammal()
        {
            //arange
            var cageToCreate = new List<Cages> {Cages.ForMammal};
            const Cages actualCage = Cages.ForMammal;

            //act
            _cagesServices.CreateCages(cageToCreate);
            var expectedCage = _cagesRepository.GetLastCreatedCage();

            //assert
            Assert.AreEqual(expected: expectedCage.ToJson(), actual: actualCage.ToJson());
        }

        [Test]
        public void CreateCage_ForBird()
        {
            //arange
            var cageToCreate = new List<Cages> {Cages.ForBird};
            const Cages expectedlCage = Cages.ForBird;

            //act
            _cagesServices.CreateCages(cageToCreate);
            var actualCage = _cagesRepository.GetLastCreatedCage();

            //assert
            Assert.AreEqual(expected: expectedlCage.ToJson(), actual: actualCage.ToJson());
        }

        [Test]
        public void CreateCage_ForReptile()
        {
            //arange
            var cageToCreate = new List<Cages> {Cages.ForReptile};
            const Cages actualCage = Cages.ForReptile;

            //act
            _cagesServices.CreateCages(cageToCreate);
            var expectedCage = _cagesRepository.GetLastCreatedCage();

            //assert
            Assert.AreEqual(expected: expectedCage.ToJson(), actual: actualCage.ToJson());
        }

        [Test]
        public void CreateRandomCages()
        {
            //arange
            List<Cages> cagesToCreate = _cagesServices.CreateRandomFilledCagesList();
<<<<<<< .mine
            
=======

>>>>>>> .theirs


            //act
<<<<<<< .mine
            _cagesServices.CreateCage(cagesToCreate);
            List<Cages> allExistingCages = _cagesRepository.GetAll();
            int j = -1;
=======
            _cagesServices.CreateCages(cagesToCreate);
            List<Cages> allExistingCages = _cagesRepository.GetAll();
            int j = allExistingCages.Count - 1;
>>>>>>> .theirs

            //assert
<<<<<<< .mine
            for (int i = cagesToCreate.Count-1; i >= 0 ; i--)
=======
            for (int i = cagesToCreate.Count - 1; i >= 0; i--)
>>>>>>> .theirs
            {
<<<<<<< .mine
                j++;
                Assert.AreEqual(expected:cagesToCreate[i], actual:allExistingCages[j]);
                
=======
                Assert.AreEqual(expected: cagesToCreate[i], actual: allExistingCages[j]);
                j--;

>>>>>>> .theirs
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
            Assert.AreEqual(expected: expectedCagesList.ToJson(), actual: actualCagesList.ToJson());
        }

        #endregion
    }
}