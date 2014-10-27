using System;
using System.Collections.Generic;
using MyZoo.Common.ZooItems.BaseClasses;
using MyZoo.Common.ZooItems.Factories;
using MyZoo.Common.Interfaces;
using MyZoo.DataAccess.Core;


namespace MyZoo.Business.Services
{
    public class AnimalsServices : AnimalFactory
    {
        private readonly IZooItemsRepository<IZooItems<Animal>> _animalRepository = new AnimalsRepository();

        public override void CreateAnimals(IEnumerable<IZooItems<Animal>> animalsList)
        {
            if (animalsList == null)
                throw new Exception("Animals list mustn't be empty!");

            foreach (var pair in animalsList)
            {
                _animalRepository.Insert(pair);
            }
        }

        public IEnumerable<IZooItems<Animal>> GetAllAnimalsAsAList()
        {
            var animalsList = _animalRepository.GetAllItems();
            return animalsList;
        }
    }
}