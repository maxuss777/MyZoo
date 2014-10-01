using System;
using System.Collections.Generic;
using MyZoo.Common.Animal.Species;
using MyZoo.Common.Factories;
using MyZoo.Common.Interfaces;
using MyZoo.DataAccess.Core;


namespace MyZoo.Business.Services
{
    public class AnimalsServices : AnimalFactory
    {
        private readonly IAnimalRepository _animalRepository = new AnimalsRepository();
        private IAnimals _animals;
        private List<IAnimals> _animalsList; 

        public override void CreateAnimal(Dictionary<string, string> animalsListDictionary)
        {
            if(animalsListDictionary == null) 
                throw new Exception("Animals list musn't be empty!");

            foreach (var pair in animalsListDictionary)
            {
                switch (pair.Value)
                {
                    case "mammal":
                        _animals = new Mammals(pair.Value, pair.Key);
                        _animalRepository.Insert(_animals);
                        break;

                    case "bird":
                        _animals = new Birds(pair.Value, pair.Key);
                        _animalRepository.Insert(_animals);
                        break;

                    case "reptile":
                        _animals = new Reptiles(pair.Value, pair.Key);
                        _animalRepository.Insert(_animals);
                        break;
                }
            }
        }

        public List<IAnimals> GetAllAnimalsAsAList()
        {
            _animalsList = _animalRepository.GetAllAnimal();

            return _animalsList;
        }
    }
}
