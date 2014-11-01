namespace MyZoo.Common.ZooItems.Species
{
    public sealed class Mammal : BaseClasses.Animal
    {
       public Mammal(string kind) : base(kind)
       {
       }

       public Mammal(string kind, string name, string food, int cageId)
           : base(kind, name, food, cageId)
       {
       }

       public override string[] ShowDetails()
       {
           return base.ShowDetails();
       }
    }
}