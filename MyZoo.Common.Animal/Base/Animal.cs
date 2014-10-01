using MyZoo.Common.Interfaces;

namespace MyZoo.Common.Animal.Base
{
    public abstract class Animal : IAnimals
    {
        protected readonly string _specie;
        protected readonly string _kind;

        protected Animal(string specie, string kind)
        {
            _specie = specie;
            _kind = kind;
        }

        public abstract string Specie { get; }
        public abstract string Kind { get; }
    }
}
