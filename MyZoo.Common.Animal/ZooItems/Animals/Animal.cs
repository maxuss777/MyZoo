using System.Globalization;
using MyZoo.Common.Interfaces;

namespace MyZoo.Common.ZooItems.BaseClasses
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string kind)
        {
            Kind = kind;
            Food = string.Empty;
            Name = string.Empty;
            CageId = 0;
        }

        protected Animal(string kind, string name, string food, int cageId)
        {
            Food = food;
            Name = name;
            CageId = cageId;
            Kind = kind;
        }

        public int CageId { get; private set; }
        public string Name { get; private set; }
        public string Kind { get; private set; }
        public string Food { get; private set; }

        public virtual string[] ShowDetails()
        {
            return new[]
                {
                    GetType().Name,
                    Kind,
                    Name,
                    Food,
                    CageId.ToString(CultureInfo.InvariantCulture)
                };
        }
    }
}