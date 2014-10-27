using System.Collections.Generic;
using MyZoo.Common.Animal.Interfaces.Common_Layer_interfaces;

namespace MyZoo.Common.ZooItems.Factories
{
    public abstract class AnimalFactory
    {
        public abstract void CreateAnimals(IEnumerable<IAnimals> animalsList);
    }
}