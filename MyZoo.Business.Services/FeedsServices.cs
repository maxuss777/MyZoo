using System;
using System.Collections.Generic;
using MyZoo.Common.Animal.Factories;
using MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces;
using MyZoo.Common.Animal.Interfaces.DataAccess.Core.Interfaces;
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

        public IEnumerable<IFeed> GetAllExistingFeeds()
        {
            return _feedsRepository.GetAllItems();
        }

        public void CreateFeedsRandomly(Type baseClass)
        {
            var random = new Random();
            var feedsList = new List<IFeed>();
            var derivedClasses = Services.GetAllDerivedTypesOf(baseClass);
                
            feedsList.Add(new Feed(0, derivedClasses[random.Next(0, derivedClasses.Count)].Name));

            CreateFeeds(feedsList);
        }
    }
}