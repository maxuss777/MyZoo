using System.Collections.Generic;
using MyZoo.Common.Interfaces;


namespace MyZoo.Common.ZooItems
{
    public abstract class AnimalFactory
    {
        public abstract void CreateAnimals(IEnumerable<IAnimal> animals);
    }
}