using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyZoo.Common.Animal.Species;
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
        private readonly IAnimalRepository _animalRepository = new AnimalsRepository();
        private readonly AnimalsServices _animalService = new AnimalsServices();
        private IAnimals actualAnimal;
        private IAnimals expectedAnimal;
        private List<IAnimals> _actualAnimalsList;
        private List<IAnimals> _expectedAnimalsList;

        #region Create animals

        [TestMethod]
        public void CreateAnimal_Mammal()
        {
            //arrange
            var animalListDictionary = new Dictionary<string, string>
            {
                {"tiger", "mammal"}
            };
            expectedAnimal = new Mammals("mammal","tiger");

            //act
            _animalService.CreateAnimal(animalListDictionary);
            actualAnimal = _animalRepository.GetLastCreatedAnimal();

            //assert
            Assert.AreEqual(expected: expectedAnimal.ToJson(), actual: actualAnimal.ToJson());
        }

        [TestMethod]
        public void CreateAnimal_Reptile()
        {
            //arrange
            var animalListDictionary = new Dictionary<string, string>
            {
                {"crocodile", "reptile"}
            };
            expectedAnimal = new Reptiles("reptile", "crocodile");

            //act
            _animalService.CreateAnimal(animalListDictionary);
            actualAnimal = _animalRepository.GetLastCreatedAnimal();

            //assert
            Assert.AreEqual(expected: expectedAnimal.ToJson(), actual: actualAnimal.ToJson());
        }

        [TestMethod]
        public void CreateAnimal_Bird()
        {
            //arrange
            var animalListDictionary = new Dictionary<string, string>
            {
                {"owl", "bird"}
            };
            expectedAnimal = new Birds("bird", "owl");

            //act
            _animalService.CreateAnimal(animalListDictionary);
            actualAnimal = _animalRepository.GetLastCreatedAnimal();

            //assert
            Assert.AreEqual(expected: expectedAnimal.ToJson(), actual: actualAnimal.ToJson());
        }

        [TestMethod]
        public void CreateAnimal_AnimalListToCreateIsNull()
        {
            //arrange

            //act
            var exc = Assert.Throws<Exception>(()=> _animalService.CreateAnimal(null));

            //assert
            Assert.That(exc.Message, Is.EqualTo("Animals list musn't be empty!"));
        }
        
        #endregion

        #region Get all existing animals

        [TestMethod]
        public void GetAllAnimals()
        {
            //arrange
            _actualAnimalsList = _animalRepository.GetAllAnimal();

            //act
            _expectedAnimalsList = _animalService.GetAllAnimalsAsAList();

            //assert
            Assert.AreEqual(expected: _expectedAnimalsList.ToJson(),actual:_actualAnimalsList.ToJson());
        }

        #endregion
    }
}
