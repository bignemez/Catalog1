using Catalog1.Entities;
using Catalog1.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Catalog1.Dtos;

namespace Catalog1.Controllers
{
    [ApiController]
    [Route("Items")]
    public class ItemController : ControllerBase
    {
        private readonly IItemsRepository _repository;

        public ItemController(IItemsRepository repository)
        {
            _repository = repository;
        }

        // GET /items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems() => _repository.GetItems().Select(selector: item => item.AsDto());

        // GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = _repository.GetItem(id);
            if (item is null)
            {
                return NotFound();
            }

            return Ok(item.AsDto());
        }
    }
}