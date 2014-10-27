using System.Collections.Generic;
using MyZoo.Common.Interfaces;
using MyZoo.Common.ZooItems.BaseClasses;

namespace MyZoo.Common.ZooItems.Factories
{
    public abstract class AnimalFactory
    {
        public abstract void CreateAnimals(IEnumerable<IZooItems<Animal>> animalsList);
    }
}