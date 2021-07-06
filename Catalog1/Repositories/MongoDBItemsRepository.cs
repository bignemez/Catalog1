using System;
using System.Collections.Generic;
using Catalog1.Dtos;
using Catalog1.Entities;
using MongoDB.Driver;

namespace Catalog1.Repositories
{
    public class MongoDBItemsRepository : IItemsRepository
    {
        private const string                 DatabaseName   = "catalog";
        private const string                 CollectionName = "items";
        private       IMongoCollection<Item> _itemsCollection;

        public MongoDBItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
            _itemsCollection = database.GetCollection<Item>(CollectionName);
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public void CreateItem(Item item)
        {
            _itemsCollection.InsertOne(item);
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}