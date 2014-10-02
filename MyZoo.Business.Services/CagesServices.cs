using System;
using System.Collections.Generic;
using MyZoo.Common.Cages;
using MyZoo.Common.Factories;
using MyZoo.DataAccess.Core;

namespace MyZoo.Business.Services
{
    public class CagesServices : CageFactory
    {
        readonly CagesRepository _cagesRepository = new CagesRepository();

        public override void CreateCage(List<Cages> cages)
        {
            if(cages == null)
                throw new Exception("Cages list musn't be empty!");

            foreach (var cage in cages)
            {
                switch (cage)
                {
                    case Cages.ForBird:
                        _cagesRepository.Insert(Cages.ForBird);
                        break;
                    case Cages.ForMammal:
                        _cagesRepository.Insert(Cages.ForMammal);
                        break;
                    case Cages.ForReptile:
                        _cagesRepository.Insert(Cages.ForReptile);
                        break;
                }
            }
        }

        public List<Cages> GetAllExistingCages()
        {
            return _cagesRepository.GetAll();
        }
    }
}
