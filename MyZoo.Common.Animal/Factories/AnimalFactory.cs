using System.Collections.Generic;

namespace MyZoo.Common.Factories
{
    public abstract class AnimalFactory
    {
        public abstract void CreateAnimals(Dictionary<string, string> animalsListDictionary);
    }
}
