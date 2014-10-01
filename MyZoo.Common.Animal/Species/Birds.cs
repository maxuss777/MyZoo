
namespace MyZoo.Common.Animal.Species
{
    public class Birds : Base.Animal
    {
        public Birds(string specie, string kind) : base(specie,kind)
        {
        }

        public override string Specie
        {
            get { return _specie; }
        }

        public override string Kind
        {
            get { return _kind; }
        }
    }
}
