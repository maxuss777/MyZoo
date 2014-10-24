using System;
using System.Collections.Generic;
using System.Linq;
using MyZoo.Common.ZooItems;
using MyZoo.Common.ZooItems.Interfaces.Common_Layer_interfaces;
using MyZoo.DataAccess.Core;
using System.Reflection;

namespace MyZoo.Business.Services
{
    public class CagesServices : CageFactory
    {
        readonly CagesRepository _cagesRepository = new CagesRepository();

        public override void CreateCages(IEnumerable<ICages> cages)
        {
            if(cages == null)
                throw new Exception("Cages list musn't be empty!");

            foreach (var cage in cages)
            {
                _cagesRepository.Insert(cage);
            }
        }

        public IEnumerable<ICages> CreateRandomFilledCagesList()
        {
            var cagesList = new List<ICages>();
            var random = new Random();
            var type = Type.GetType("MyZoo.Common.BaseClasses.Cage");
            var members = default(MemberInfo[]);

            if (type != null)
            {
               members = type.GetMembers();
            }

            if (members != null)
            {
                cagesList.AddRange(members.Select(t => (ICages) members.GetValue(random.Next(members.Length - 1))));
            }
            return cagesList;
        }

       /* public List<ICages> GetAllExistingCages()
        {
            return _cagesRepository.GetAll();
        }*/
    }
}
