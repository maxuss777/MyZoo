namespace MyZoo.Common.Animal.ZooItems.Animals
{
    public sealed class Bird : Animal
    {
        public Bird(int id, string kind) : base(id, kind)
        {
        }

        public Bird(int id, string kind, string name, string food, int cageId)
            : base(id, kind, name, food, cageId)
        {
        }
    }
}