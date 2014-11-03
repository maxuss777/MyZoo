using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyZoo.Common.Interfaces;
using MyZoo.Common.ZooItems.Species;
using MyZoo.DataAccess.Core;
using NUnit.Framework;
using ServiceStack;
using System;
using Assert = NUnit.Framework.Assert;


namespace MyZoo.Business.Services.Tests
{
    [TestClass]
    public class AnimalServicesTests
    {
        private readonly IZooItemsRepository<IAnimal> _animalRepository = new AnimalsRepository();
        private readonly AnimalsServices _animalServices = new AnimalsServices();
        private IAnimal _actualAnimal;
        private IAnimal _expectedAnimal;
        private List<IAnimal> _actualAnimalsList;
        private List<IAnimal> _expectedAnimalsList;

        #region Create animals

        [TestMethod]
        public void CreateAnimal_Mammal_With_One_Parameter_In_Constructor()
        {
            //arrange
            _actualAnimalsList = new List<IAnimal>
            {
                new Mammal("tiger")
            };
            _expectedAnimal = new Mammal("tiger");
            //act
            _animalServices.CreateAnimals(_actualAnimalsList);
            _actualAnimal = _animalRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedAnimal.ToJson(), actual: _actualAnimal.ToJson());
        }

        [TestMethod]
        public void CreateAnimal_Mammal_With_All_Parameters_In_Constructor()
        {
            //arrange
            _actualAnimalsList = new List<IAnimal>
            {
                new Mammal("tiger", "Name", "Food", 1)
            };
            _expectedAnimal = new Mammal("tiger", "Name", "Food", 1);
            //act
            _animalServices.CreateAnimals(_actualAnimalsList);
            _actualAnimal = _animalRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedAnimal.ToJson(), actual: _actualAnimal.ToJson());
        }

        [TestMethod]
        public void CreateAnimal_Reptile_With_One_Parameter_In_Constructor()
        {
            //arrange
            _actualAnimalsList = new List<IAnimal>
            {
                new Mammal("crocodile")
            };
            _expectedAnimal = new Mammal("crocodile");
            //act
            _animalServices.CreateAnimals(_actualAnimalsList);
            _actualAnimal = _animalRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedAnimal.ToJson(), actual: _actualAnimal.ToJson());
        }

        [TestMethod]
        public void CreateAnimal_Reptile_With_All_Parameters_In_Constructor()
        {
            //arrange
            _actualAnimalsList = new List<IAnimal>
            {
                new Mammal("crocodile", "Name", "Food", 2)
            };
            _expectedAnimal = new Mammal("crocodile", "Name", "Food", 2);
            //act
            _animalServices.CreateAnimals(_actualAnimalsList);
            _actualAnimal = _animalRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedAnimal.ToJson(), actual: _actualAnimal.ToJson());
        }

        [TestMethod]
        public void CreateAnimal_Bird_With_One_Parameter_In_Constructor()
        {
            //arrange
            _actualAnimalsList = new List<IAnimal>
            {
                new Mammal("owl")
            };
            _expectedAnimal = new Mammal("owl");
            //act
            _animalServices.CreateAnimals(_actualAnimalsList);
            _actualAnimal = _animalRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedAnimal.ToJson(), actual: _actualAnimal.ToJson());
        }

        [TestMethod]
        public void CreateAnimal_Bird_With_All_Parameters_In_Constructor()
        {
            //arrange
            _actualAnimalsList = new List<IAnimal>
            {
                new Mammal("owl", "Name", "Food", 3)
            };
            _expectedAnimal = new Mammal("owl", "Name", "Food", 3);
            //act
            _animalServices.CreateAnimals(_actualAnimalsList);
            _actualAnimal = _animalRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedAnimal.ToJson(), actual: _actualAnimal.ToJson());
        }
        
        [TestMethod]
        public void CreateAnimal_AnimalListToCreateIsNull()
        {
            //arrange

            //act
            var exc = Assert.Throws<Exception>(()=> _animalServices.CreateAnimals(null));

            //assert
            Assert.That(exc.Message, Is.EqualTo("Animals list mustn't be empty!"));
        }
        
        #endregion

        #region Get all existing animals

        [TestMethod]
        public void GetAllAnimals()
        {
            //arrange
            _actualAnimalsList = (List<IAnimal>) _animalRepository.GetAllItems();

            //act
            _expectedAnimalsList = (List<IAnimal>) _animalServices.GetAllExistingAnimals();

            //assert
            Assert.AreEqual(expected: _expectedAnimalsList.ToJson(),actual:_actualAnimalsList.ToJson());
        }

        #endregion

        #region Get animal details

        [TestMethod]
        public void GetAnimalDetails()
        {
            //arrange
            var actualDetails = new string[] { "Mammal", "tiger", "jack", "meet", "17" };
            _actualAnimal = new Mammal("tiger", "jack", "meet", 17);

            //act
            var expectedDetails = _actualAnimal.ShowDetails();

            //assert
            Assert.AreEqual(expected: expectedDetails.ToJson(), actual: actualDetails.ToJson());
        }

        #endregion
    }
}
