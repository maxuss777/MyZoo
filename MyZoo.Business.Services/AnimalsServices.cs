using System;
using System.Collections.Generic;
using MyZoo.Common.ZooItems.Factories;
using MyZoo.Common.Interfaces;
using MyZoo.DataAccess.Core;


namespace MyZoo.Business.Services
{
    public class AnimalsServices : AnimalFactory
    {
        private readonly IAnimalRepository _animalRepository = new AnimalsRepository();
        private List<IAnimals> _animalsList;

        public override void CreateAnimals(IEnumerable<IAnimals> animalsList)
        {
            if (animalsList == null)
                throw new Exception("Animals list must'n be empty!");

            foreach (var pair in animalsList)
            {
                _animalRepository.Insert(pair);
            }
        }

        public List<IAnimals> GetAllAnimalsAsAList()
        {
            _animalsList = _animalRepository.GetAllAnimal();
            return _animalsList;
        }
    }
}