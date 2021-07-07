using Catalog1.Entities;
using Catalog1.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<ItemDto>> GetItemsAsync() => (await _repository.GetItemsAsync()).Select(selector: item => item.AsDto());

        // GET /items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
        {
            var item = await _repository.GetItemAsync(id);
            return item is null ? NotFound() : Ok(item.AsDto());
        }

        // Post /items
        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto)
        {
            Item item = new()
                        {
                            Id          = Guid.NewGuid(),
                            Name        = itemDto.Name,
                            Price       = itemDto.Price,
                            CreatedDate = DateTimeOffset.Now
                        };
           await _repository.CreateItemAsync(item);
            return CreatedAtAction(nameof(GetItemAsync), new {id = item.Id}, item.AsDto());
        }

        // Put /items/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = await _repository.GetItemAsync(id);
            if (existingItem is null) return NotFound();
            Item updatedItem = existingItem with {Name = itemDto.Name, Price = itemDto.Price};
            await _repository.UpdateItemAsync(updatedItem);
            return NoContent();

        }
        
        // Delete /items/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
           
            var existingItem = await _repository.GetItemAsync(id);
            if (existingItem is null) return NotFound();
            await _repository.DeleteItemAsync(existingItem.Id);
            return NoContent();

        }
    }
}