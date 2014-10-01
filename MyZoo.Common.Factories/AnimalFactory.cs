using System.Collections.Generic;

namespace MyZoo.Common.Factories
{
    public abstract class AnimalFactory
    {
        public abstract void CreateAnimal(Dictionary<string, string> animalsListDictionary);
    }
}
