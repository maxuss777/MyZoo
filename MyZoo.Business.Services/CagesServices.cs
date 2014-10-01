using MyZoo.Common.Cages;
using MyZoo.Common.Factories;
using MyZoo.DataAccess.Core;

namespace MyZoo.Business.Services
{
    public class CagesServices : CageFactory
    {
        readonly CagesRepository _cagesRepository = new CagesRepository();

        public override void CreateCage(Cages cages)
        {
          _cagesRepository.Insert(cages);  
        }
    }
}
