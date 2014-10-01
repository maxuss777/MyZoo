
namespace MyZoo.Common.Animal.Species
{
    public class Reptiles : Base.Animal
    {
          public Reptiles(string specie, string kind) : base(specie, kind)
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
