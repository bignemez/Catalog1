using Catalog1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalog1.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> _items = new()
                                             {
                                                 new Item { Id=Guid.NewGuid(),Name="Poison",Price=9,CreatedDate=DateTimeOffset.Now},
                                                 new Item { Id=Guid.NewGuid(),Name="Iron Sword",Price=19,CreatedDate=DateTimeOffset.Now},
                                                 new Item { Id=Guid.NewGuid(),Name="Silver Shield",Price=14,CreatedDate=DateTimeOffset.Now},
                                             };

        public IEnumerable<Item> GetItems()
        {
            return _items;
        }
        public Item GetItem(Guid id)
        {
            return _items.SingleOrDefault(item => item.Id == id);
        }

        public void CreateItem(Item item)
        {
            _items.Add(item);
        }
    }
}
