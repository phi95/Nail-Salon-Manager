using AutoMapper;
using Nail_Salon_Manager.Dtos;
using Nail_Salon_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nail_Salon_Manager.Controllers.Api
{
    public class InventoryItemsController : ApiController
    {
        private ApplicationDbContext _context;

        public InventoryItemsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/inventoryitems
        public IHttpActionResult GetInventoryItems()
        {
            return Ok(_context.InventoryItems.ToList().Select(Mapper.Map<InventoryItem, InventoryItemDto>));
        }

        // GET /api/inventoryitems/1
        public IHttpActionResult GetInventoryItem(int id)
        {
            var inventoryItem = _context.InventoryItems.SingleOrDefault(x => x.Id == id);

            if (inventoryItem == null)
                return NotFound();

            return Ok(Mapper.Map<InventoryItem, InventoryItemDto>(inventoryItem));
        }

        // POST /api/inventoryitems
        [HttpPost]
        public IHttpActionResult CreateInventoryItem(InventoryItemDto inventoryItemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var inventoryItem = Mapper.Map<InventoryItemDto, InventoryItem>(inventoryItemDto);
            _context.InventoryItems.Add(inventoryItem);
            _context.SaveChanges();

            inventoryItemDto.Id = inventoryItem.Id;

            return Created(new Uri(Request.RequestUri + "/" + inventoryItem.Id), inventoryItemDto);
        }

        // PUT /api/inventoryitems/1
        [HttpPut]
        public IHttpActionResult UpdateInventoryItem(int id, InventoryItemDto inventoryItemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var inventoryItemInDb = _context.InventoryItems.SingleOrDefault(x => x.Id == id);
            if (inventoryItemInDb == null)
                return NotFound();

            Mapper.Map(inventoryItemDto, inventoryItemInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/inventoryitems/1
        [HttpDelete]
        public IHttpActionResult DeleteInventoryItem(int id)
        {
            var inventoryItemInDb = _context.InventoryItems.SingleOrDefault(x => x.Id == id);
            if (inventoryItemInDb == null)
                return NotFound();

            _context.InventoryItems.Remove(inventoryItemInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
