using System.Collections.Generic;
using MyZoo.Common.Animal.Interfaces.Common_Layer_interfaces;

namespace MyZoo.Common.Animal.Interfaces.Data_Access_Layer_Interfaces
{
    public interface IAnimalsRepository
    {
        void Insert(IAnimals animal);
        List<IAnimals> GetAllAnimal();
        IAnimals GetLastCreatedAnimal();
    }
}
