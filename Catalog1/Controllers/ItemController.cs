using Catalog1.Entities;
using Catalog1.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Catalog1.Controllers
{
    [ApiController]
    [Route("Items")]
    public class ItemController:ControllerBase
    {
        private readonly InMemItemsRepository repository;

        public ItemController()
        {
            repository = new InMemItemsRepository();
        }

        // GET /items
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return repository.GetItems();
        }

        // GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
           var item= repository.GetItem(id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
