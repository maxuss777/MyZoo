using System;
using System.Collections.Generic;
using MyZoo.Common.Interfaces;
using MyZoo.Common.ZooItems;
using MyZoo.Common.ZooItems.BaseClasses;
using MyZoo.DataAccess.Core;
using System.Reflection;


namespace MyZoo.Business.Services
{
    public class CagesServices : CageFactory
    {
        readonly CagesRepository _cagesRepository = new CagesRepository();

        public override void CreateCages(IEnumerable<IZooItems<Cage>> cages)
        {
            if(cages == null)
                throw new Exception("Cages list musn't be empty!");

            foreach (var cage in cages)
            {
                _cagesRepository.Insert(cage);
            }
        }

        public List<IZooItems<Cage>> CreateRandomFilledCagesList()
        {
            var cagesList = new List<IZooItems<Cage>>();
            var type = Type.GetType("MyZoo.Common.BaseClasses.Cage");
            var members = default(MemberInfo[]);

            if (type != null)
            {
               members = type.GetMembers();
            }

            if (members != null)
            {
            }
            return cagesList;
        }

        public IEnumerable<IZooItems<Cage>> GetAllExistingCages()
        {
            return _cagesRepository.GetAllItems();
        }
    }
}
