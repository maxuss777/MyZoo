using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyZoo.Common.Cages;
using MyZoo.DataAccess.Core;
using NUnit.Framework;
using ServiceStack;

namespace MyZoo.Business.Services.Tests
{
    [TestClass]
    class CagesServicesTests
    {
        private readonly CagesRepository _cagesRepository = new CagesRepository();
        private Cages actualCage;
        private Cages expectedCage;
    
        #region Create Cages

        [Test]
        public void CreateCage()
        {
            //arange

            //act
            _cagesRepository.Insert(expectedCage);

            //assert

        }

        #endregion
    }
}
