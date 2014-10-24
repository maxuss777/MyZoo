using System;
using System.Collections.Generic;

namespace MyZoo.Common.Interfaces
{
    public interface IAnimalRepository
    {
        void Insert(IAnimals animal);

        List<IAnimals> GetAllAnimal();

        IAnimals GetLastCreatedAnimal();

    }
}
