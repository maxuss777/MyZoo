namespace MyZoo.Common.ZooItems.Species
{
    public sealed class Bird : BaseClasses.Animal
    {
        public Bird(string kind) : base(kind)
        {
        }

        public Bird(string kind, string name, string food, int cageId)
            : base(kind, name, food, cageId)
        {
        }

        public override string[] ShowDetails()
        {
            return base.ShowDetails();
        }
    }
}