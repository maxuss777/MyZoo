using System.Collections.Generic;
using MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces;

namespace MyZoo.Common.Animal.Factories
{
    public abstract class AnimalFactory
    {
        public abstract void CreateAnimals(IEnumerable<IAnimal> animals);
    }
}