using System.Collections.Generic;
using MyZoo.Common.Interfaces;

namespace MyZoo.Common.ZooItems.Factories
{
    public abstract class AnimalFactory
    {
        public abstract void CreateAnimals(IEnumerable<IAnimals> animalsList);
    }
}