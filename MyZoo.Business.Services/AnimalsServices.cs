using System;
using System.Collections.Generic;
using MyZoo.Common.ZooItems;
using MyZoo.Common.Interfaces;
using MyZoo.DataAccess.Core;


namespace MyZoo.Business.Services
{
    public class AnimalsServices : AnimalFactory
    {
        private readonly IZooItemsRepository<IAnimal> _animalRepository = new AnimalsRepository();

        public override void CreateAnimals(IEnumerable<IAnimal> animalsList)
        {
            if (animalsList == null)
                throw new Exception("Animals list mustn't be empty!");

            foreach (var animal in animalsList)
            {
                _animalRepository.Insert(animal);
            }
        }

        public IEnumerable<IAnimal> GetAllExistingAnimals()
        {
            return _animalRepository.GetAllItems();
        }

    }
}