using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog1.Entities;

namespace Catalog1.Repositories
{
    public interface IItemsRepository
    {
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<Item>              GetItemAsync(Guid    id);
        Task                    CreateItemAsync(Item item);
        Task                    UpdateItemAsync(Item item);
        Task                    DeleteItemAsync(Guid id);
    }
}