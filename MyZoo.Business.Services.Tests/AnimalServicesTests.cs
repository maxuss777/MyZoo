using System.Collections.Generic;
using MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces;
using MyZoo.Common.Animal.Interfaces.DataAccess.Core.Interfaces;
using MyZoo.Common.Animal.ZooItems.Animals;
using MyZoo.Common.ZooItems;
using MyZoo.DataAccess.Core;
using NUnit.Framework;
using ServiceStack;
using System;


namespace MyZoo.Business.Services.Tests
{
    public class AnimalServicesTests
    {
        private readonly IZooItemsRepository<IAnimal> _animalRepository = new AnimalsRepository();
        private readonly AnimalsServices _animalServices = new AnimalsServices();
        private IAnimal _actualAnimal;
        private IAnimal _expectedAnimal;
        private IAnimal _lastCreatedAnimal;
        private List<IAnimal> _actualAnimalsList;
        private List<IAnimal> _expectedAnimalsList;

        #region Create animals

        [Test]
        public void CreateAnimal_Mammal_With_One_Parameter_In_Constructor()
        {
            //arrange
            _actualAnimalsList = new List<IAnimal>
            {
                new Mammal(0, "tiger")
            };
            _lastCreatedAnimal = _animalRepository.GetLastCreatedItem();
            _expectedAnimal = new Mammal(_lastCreatedAnimal.Id + 1, "tiger");

            //act
            _animalServices.CreateAnimals(_actualAnimalsList);
            _actualAnimal = _animalRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedAnimal.ToJson(), actual: _actualAnimal.ToJson());
        }

        [Test]
        public void CreateAnimal_Mammal_With_All_Parameters_In_Constructor()
        {
            //arrange
            _actualAnimalsList = new List<IAnimal>
            {
                new Mammal(0, "tiger", "Name", "Food", 1)
            };
            _lastCreatedAnimal = _animalRepository.GetLastCreatedItem();
            _expectedAnimal = new Mammal(_lastCreatedAnimal.Id + 1, "tiger", "Name", "Food", 1);

            //act
            _animalServices.CreateAnimals(_actualAnimalsList);
            _actualAnimal = _animalRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedAnimal.ToJson(), actual: _actualAnimal.ToJson());
        }

        [Test]
        public void CreateAnimal_Reptile_With_One_Parameter_In_Constructor()
        {
            //arrange
            _actualAnimalsList = new List<IAnimal>
            {
                new Reptile(0, "crocodile")
            };
            _lastCreatedAnimal = _animalRepository.GetLastCreatedItem();
            _expectedAnimal = new Reptile(_lastCreatedAnimal.Id + 1, "crocodile");

            //act
            _animalServices.CreateAnimals(_actualAnimalsList);
            _actualAnimal = _animalRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedAnimal.ToJson(), actual: _actualAnimal.ToJson());
        }

        [Test]
        public void CreateAnimal_Reptile_With_All_Parameters_In_Constructor()
        {
            //arrange
            _actualAnimalsList = new List<IAnimal>
            {
                new Reptile(0, "crocodile", "Name", "Food", 2)
            };
            _lastCreatedAnimal = _animalRepository.GetLastCreatedItem();
            _expectedAnimal = new Reptile(_lastCreatedAnimal.Id + 1, "crocodile", "Name", "Food", 2 );

            //act
            _animalServices.CreateAnimals(_actualAnimalsList);
            _actualAnimal = _animalRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedAnimal.ToJson(), actual: _actualAnimal.ToJson());
        }

        [Test]
        public void CreateAnimal_Bird_With_One_Parameter_In_Constructor()
        {
            //arrange
            _actualAnimalsList = new List<IAnimal>
            {
                new Bird(0, "owl")
            };
            _lastCreatedAnimal = _animalRepository.GetLastCreatedItem();
            _expectedAnimal = new Bird(_lastCreatedAnimal.Id + 1, "owl");

            //act
            _animalServices.CreateAnimals(_actualAnimalsList);
            _actualAnimal = _animalRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedAnimal.ToJson(), actual: _actualAnimal.ToJson());
        }

        [Test]
        public void CreateAnimal_Bird_With_All_Parameters_In_Constructor()
        {
            //arrange
            _actualAnimalsList = new List<IAnimal>
            {
                new Bird(0, "owl", "Name", "Food", 3)
            };
            _lastCreatedAnimal = _animalRepository.GetLastCreatedItem();
            _expectedAnimal = new Bird(_lastCreatedAnimal.Id + 1, "owl", "Name", "Food", 3);

            //act
            _animalServices.CreateAnimals(_actualAnimalsList);
            _actualAnimal = _animalRepository.GetLastCreatedItem();

            //assert
            Assert.AreEqual(expected: _expectedAnimal.ToJson(), actual: _actualAnimal.ToJson());
        }

        [Test]
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

        [Test]
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

        [Test]
        public void GetAnimalDetails()
        {
            //arrange
            var actualDetails = new[] {"0", "Mammal", "tiger", "jack", "meet", "17"};
            _actualAnimal = new Mammal(0, "tiger", "jack", "meet", 17);

            //act
            var expectedDetails = _actualAnimal.ShowDetails();

            //assert
            Assert.AreEqual(expected: expectedDetails.ToJson(), actual: actualDetails.ToJson());
        }

        #endregion

    }
}
