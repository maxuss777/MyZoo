using System;
using System.Collections.Generic;
using MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces;
using MyZoo.Common.Interfaces;
using MyZoo.Common.ZooItems;
using MyZoo.DataAccess.Core;


namespace MyZoo.Business.Services
{
    public class CagesServices : CageFactory
    {
        private readonly IZooItemsRepository<ICage> _cagesRepository = new CagesRepository();

        public override void CreateCages(IEnumerable<ICage> cages)
        {
            if(cages == null)
                throw new Exception("Cages list musn't be empty!");

            foreach (var cage in cages)
            {
                _cagesRepository.Insert(cage);
            }
        }

        public IEnumerable<ICage> GetAllExistingCages()
        {
            return _cagesRepository.GetAllItems();
        }
    }
}
