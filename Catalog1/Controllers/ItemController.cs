using Catalog1.Entities;
using Catalog1.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Catalog1.Controllers
{
    [ApiController]
    [Route("Items")]
    public class ItemController
    {
        private readonly InMemItemsRepository repository;

        public ItemController()
        {
            repository = new InMemItemsRepository();
        }

        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return repository.GetItems();
        }
    }
}
