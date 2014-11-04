using System;
using System.Collections.Generic;
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
                throw new Exception("Cages list mustn't be empty!");

            foreach (var cage in cages)
            {
                _cagesRepository.Insert(cage);
            }
        }

        public IEnumerable<ICage> GetAllExistingCages()
        {
            return _cagesRepository.GetAllItems();
        }

        public void CreateCageRandomly(Type baseClass)
        {
            var random = new Random();
            var cagesList = new List<ICage>();
            var derivedClasses = Services.GetAllDerivedTypesOf(baseClass);
                
            cagesList.Add(new Cage(0, derivedClasses[random.Next(0, derivedClasses.Count)].Name));

            CreateCages(cagesList);
        }
    }
}