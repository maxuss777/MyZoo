

namespace MyZoo.Common.ZooItems
{
    public sealed class Mammal : Animal
    {
       public Mammal(int id, string kind) : base(id, kind)
       {
       }

       public Mammal(int id, string kind, string name, string food, int cageId)
           : base(id, kind, name, food, cageId)
       {
       }
    }
}