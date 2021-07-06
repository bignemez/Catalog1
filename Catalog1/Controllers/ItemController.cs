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

        // Post /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
                        {
                            Id          = Guid.NewGuid(),
                            Name        = itemDto.Name,
                            Price       = itemDto.Price,
                            CreatedDate = DateTimeOffset.Now
                        };
            _repository.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item.AsDto());
        }

        // Put /items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = _repository.GetItem(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with {Name = itemDto.Name, Price = itemDto.Price};
            _repository.UpdateItem(updatedItem);
            return NoContent();
        }
        
        // Delete /items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
           
            var existingItem = _repository.GetItem(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            _repository.DeleteItem(existingItem.Id);
            return NoContent();
        }
    }
}