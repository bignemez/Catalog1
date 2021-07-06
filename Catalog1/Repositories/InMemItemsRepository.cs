using Catalog1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalog1.Repositories
{
    public class InMemItemsRepository
    {
        List<Item> items = new()
        {
            new Item { Id=Guid.NewGuid(),Name="Poison",Price=9,CreatedDate=DateTimeOffset.Now},
            new Item { Id=Guid.NewGuid(),Name="Iron Sword",Price=19,CreatedDate=DateTimeOffset.Now},
            new Item { Id=Guid.NewGuid(),Name="Silver Shield",Price=14,CreatedDate=DateTimeOffset.Now},
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }
        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }
    }
}
