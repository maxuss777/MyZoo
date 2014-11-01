namespace MyZoo.Common.ZooItems.Species
{
    public sealed class Reptile : BaseClasses.Animal
    {
        public Reptile(string kind) : base(kind)
        {
        }

        public Reptile(string kind, string name, string food, int cageId)
            : base(kind, name, food, cageId)
        {
        }
        
        public override string[] ShowDetails()
        {
            return base.ShowDetails();
        }
    }
}