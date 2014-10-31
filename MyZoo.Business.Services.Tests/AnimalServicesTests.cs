using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyZoo.Common.ZooItems.BaseClasses;
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
        private readonly AnimalsServices _animalService = new AnimalsServices();
        private IAnimal _actualAnimal;
        private IAnimal _expectedAnimal;
        private List<IAnimal> _actualAnimalsList;
        private List<IAnimal> _expectedAnimalsList;

        #region Create animals

        [TestMethod]
        public void CreateAnimal_Mammal()
        {
            //arrange
            _actualAnimalsList = new List<IAnimal>
            {
                new Mammal("tiger")
            };
            _expectedAnimal = new Mammal("tiger");
            //act
            _animalService.CreateAnimals(_actualAnimalsList);
            _actualAnimal = _animalRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedAnimal.ToJson(), actual: _actualAnimal.ToJson());
        }

        /*[TestMethod]
        public void CreateAnimal_Reptile()
        {
            //arrange
            _actualAnimalsList = new List<IZooItems<Animal>>
            {
                new Reptile("Reptiles", "crocodile")
            };
            _expectedAnimal = new Reptile("Reptiles", "crocodile");

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
                new Bird("Birds", "owl")

            };
            _expectedAnimal = new Bird("Birds", "owl");

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
        }*/
        
        #endregion

        /*#region Get all existing animals

        [TestMethod]
        public void GetAllAnimals()
        {
            //arrange
            _actualAnimalsList = (List<IZooItems<Animal>>) _animalRepository.GetAllItems();

            //act
            _expectedAnimalsList = (List<IZooItems<Animal>>) _animalService.GetAllExistingAnimals();

            //assert
            Assert.AreEqual(expected: _expectedAnimalsList.ToJson(),actual:_actualAnimalsList.ToJson());
        }

        #endregion*/
    }
}
