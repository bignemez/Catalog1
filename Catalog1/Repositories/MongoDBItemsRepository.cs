using System;
using System.Collections.Generic;
using Catalog1.Dtos;
using Catalog1.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog1.Repositories
{
    public class MongoDBItemsRepository : IItemsRepository
    {
        private const    string                        DatabaseName   = "catalog";
        private const    string                        CollectionName = "items";
        private readonly IMongoCollection<Item>        _itemsCollection;
        private          FilterDefinitionBuilder<Item> _filterBuilder = Builders<Item>.Filter;
        public MongoDBItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
            _itemsCollection = database.GetCollection<Item>(CollectionName);
        }

        public IEnumerable<Item> GetItems()
        {
            return _itemsCollection.Find(new BsonDocument()).ToList();
        }

        public Item GetItem(Guid id)
        {
            var filter = _filterBuilder.Eq(item => item.Id , id);
            return _itemsCollection.Find(filter).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            _itemsCollection.InsertOne(item);
        }

        public void UpdateItem(Item item)
        {
            var filter = _filterBuilder.Eq(existingItem => existingItem.Id , item.Id);
            _itemsCollection.ReplaceOne(filter, item);
        }

        public void DeleteItem(Guid id)
        {
            var filter = _filterBuilder.Eq(item => item.Id , id);
            _itemsCollection.DeleteOne(filter);
        }
    }
}