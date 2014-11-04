using MyZoo.Common.Interfaces;


namespace MyZoo.Common.ZooItems
{
    public abstract class Animal : IAnimal
    {
        protected Animal(int id, string kind)
        {
            Id = id;
            Kind = kind;
            Food = string.Empty;
            Name = string.Empty;
            CageId = 0;
        }

        protected Animal(int id, string kind, string name, string food, int cageId)
        {
            Id = id;
            Food = food;
            Name = name;
            CageId = cageId;
            Kind = kind;
        }

        public int CageId { get; private set; }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Kind { get; private set; }
        public string Food { get; private set; }

        public virtual string[] ShowDetails()
        {
            return new[]
                {
                    Id.ToString(),
                    GetType().Name,
                    Kind,
                    Name,
                    Food,
                    CageId.ToString()
                };
        }
    }
}