using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyZoo.Common.ZooItems.BaseClasses;
using MyZoo.Common.Interfaces;
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
        private readonly IZooItemsRepository<IZooItems<Animal>> _animalRepository = new AnimalsRepository();
        private readonly AnimalsServices _animalService = new AnimalsServices();
        private IZooItems<Animal> _actualAnimal;
        private IZooItems<Animal> _expectedAnimal;
        private List<IZooItems<Animal>> _actualAnimalsList;
        private List<IZooItems<Animal>> _expectedAnimalsList;

        #region Create animals

        [TestMethod]
        public void CreateAnimal_Mammal()
        {
            //arrange
            _actualAnimalsList = new List<IZooItems<Animal>>
            {
                new Animal("mammal", "tiger")
            };
            _expectedAnimal = new Animal("mammal","tiger");

            //act
            _animalService.CreateAnimals(_actualAnimalsList);
            _actualAnimal = _animalRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedAnimal.ToJson(), actual: _actualAnimal.ToJson());
        }

        [TestMethod]
        public void CreateAnimal_Reptile()
        {
            //arrange
            _actualAnimalsList = new List<IZooItems<Animal>>
            {
                new Animal("reptile", "crocodile")
            };
            _expectedAnimal = new Animal("reptile", "crocodile");

            //act
            _animalService.CreateAnimals(_actualAnimalsList);
            _actualAnimal = _animalRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedAnimal.ToJson(), actual: _actualAnimal.ToJson());
        }

        [TestMethod]
        public void CreateAnimal_Bird()
        {
            //arrange
            _actualAnimalsList = new List<IZooItems<Animal>>
            {
                new Animal("bird", "owl")

            };
            _expectedAnimal = new Animal("bird", "owl");

            //act
            _animalService.CreateAnimals(_actualAnimalsList);
            _actualAnimal = _animalRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedAnimal.ToJson(), actual: _actualAnimal.ToJson());
        }

        [TestMethod]
        public void CreateAnimal_AnimalListToCreateIsNull()
        {
            //arrange

            //act
            var exc = Assert.Throws<Exception>(()=> _animalService.CreateAnimals(null));

            //assert
            Assert.That(exc.Message, Is.EqualTo("Animals list mustn't be empty!"));
        }
        
        #endregion

        #region Get all existing animals

        [TestMethod]
        public void GetAllAnimals()
        {
            //arrange
            _actualAnimalsList = (List<IZooItems<Animal>>) _animalRepository.GetAllItems();

            //act
            _expectedAnimalsList = (List<IZooItems<Animal>>) _animalService.GetAllAnimalsAsAList();

            //assert
            Assert.AreEqual(expected: _expectedAnimalsList.ToJson(),actual:_actualAnimalsList.ToJson());
        }

        #endregion
    }
}
