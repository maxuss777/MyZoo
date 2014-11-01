using System;
using System.Collections.Generic;
using MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces;
using MyZoo.Common.Interfaces;
using MyZoo.Common.ZooItems;
using MyZoo.DataAccess.Core;


namespace MyZoo.Business.Services
{
    public class FeedsServices : FeedFactory
    {
        private readonly IZooItemsRepository<IFeed> _feedsRepository = new FeedsRepository();

        public override void CreateFeeds(IEnumerable<IFeed> feeds)
        {
            if (feeds == null)
                throw new Exception("Feeds list musn't be empty!");

            foreach (var feed in feeds)
            {
                _feedsRepository.Insert(feed);
            }
        }

        public List<IFeed> GetAllExistinfFeeds()
        {
            return (List<IFeed>) _feedsRepository.GetAllItems();
        }
    }
}