using System;
using System.Collections.Generic;
using Catalog1.Entities;

namespace Catalog1.Repositories
{
    public interface IItemsRepository
    {
        IEnumerable<Item> GetItems();
        Item              GetItem(Guid    id);
        void              CreateItem(Item item);
    }
}