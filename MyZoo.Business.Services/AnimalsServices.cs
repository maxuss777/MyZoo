using System;
using System.Collections.Generic;
using MyZoo.Common.Animal.Interfaces.Common_Layer_interfaces;
using MyZoo.Common.Animal.Interfaces.Data_Access_Layer_Interfaces;
using MyZoo.Common.ZooItems.Factories;
using MyZoo.DataAccess.Core;


namespace MyZoo.Business.Services
{
    public class AnimalsServices : AnimalFactory
    {
        private readonly IAnimalsRepository _animalRepository = new AnimalsRepository();
        private List<IAnimals> _animalsList;

        public override void CreateAnimals(IEnumerable<IAnimals> animalsList)
        {
            if (animalsList == null)
                throw new Exception("Animals list mustn't be empty!");

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