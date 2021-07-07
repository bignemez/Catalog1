using Catalog1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog1.Repositories
{
  public class InMemItemsRepository : IItemsRepository
  {
    private readonly List<Item> _items = new()
                                         {
                                           new Item {Id = Guid.NewGuid(), Name = "Poison", Price        = 9, CreatedDate  = DateTimeOffset.Now},
                                           new Item {Id = Guid.NewGuid(), Name = "Iron Sword", Price    = 19, CreatedDate = DateTimeOffset.Now},
                                           new Item {Id = Guid.NewGuid(), Name = "Silver Shield", Price = 14, CreatedDate = DateTimeOffset.Now},
                                         };

    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
      return await Task.FromResult(_items);
    }

    public async Task<Item> GetItemAsync(Guid id)
    {
      return await Task.FromResult(_items.SingleOrDefault(item => item.Id == id));
    }

    public Task CreateItemAsync(Item item)
    {
      _items.Add(item);
      return Task.CompletedTask;
    }

    public Task UpdateItemAsync(Item item)
    {
      var index = _items.FindIndex(existingItem => existingItem.Id == item.Id);
      _items[index] = item;
      return Task.CompletedTask;
    }

    public Task DeleteItemAsync(Guid id)
    {
      var index = _items.FindIndex(existingItem => existingItem.Id == id);
      _items.RemoveAt(index);
      return Task.CompletedTask;
    }
  }
}