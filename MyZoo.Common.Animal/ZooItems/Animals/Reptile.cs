

namespace MyZoo.Common.ZooItems
{
    public sealed class Reptile : Animal
    {
        public Reptile(int id, string kind) : base(id, kind)
        {
        }

        public Reptile(int id, string kind, string name, string food, int cageId)
            : base(id, kind, name, food, cageId)
        {
        }
    }
}