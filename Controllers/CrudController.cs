﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crudstore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CrudController : ControllerBase
  {
    // GET api/values
    // Finished and working
    [HttpGet]
    public ActionResult<List<CrudItem>> GetAllCrud([FromQuery] int store_number)
    {

      var db = new DatabaseContext();
      var data = db.Locations.Include(i => i.CrudItems).FirstOrDefault(u => u.StoreNumber == store_number);
      return data.CrudItems;
    }

    // GET api/values/5
    // Finished Works with a SKU
    // .Find only works with an Primary key Id
    [HttpGet("{SKU}")]
    public ActionResult<CrudItem> GetSingleItemBySKU(int SKU)
    {
      var db = new DatabaseContext();
      var rv = db.CrudItems.FirstOrDefault(f => f.SKU == SKU);
      return rv;
    }
    [HttpGet("single/{Id}")]
    public ActionResult<CrudItem> GetSingleItem(int Id)
    {
      var db = new DatabaseContext();
      var rv = db.CrudItems.FirstOrDefault(f => f.Id == Id);
      return rv;
    }
    [HttpGet("outofstock")]
    public ActionResult<List<CrudItem>> GetOutOfStock()
    {
      var db = new DatabaseContext();
      var noStock = db.CrudItems.Where(w => w.NumberInStock == 0).ToList();
      return noStock;
    }
    // POST api/values
    // finished and working
    [HttpPost("location")]
    public ActionResult<Location> PostAddLocation([FromBody] Location data)
    {
      var db = new DatabaseContext();
      db.Locations.Add(data);
      db.SaveChanges();
      return data;
    }
    [HttpPost]
    public ActionResult<CrudItem> PostAddCrud([FromBody] CrudItem data)
    {
      var db = new DatabaseContext();
      db.CrudItems.Add(data);
      db.SaveChanges();
      return data;
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<CrudItem> PutCrudEdit(int id, [FromBody]CrudItem value)
    {
      var db = new DatabaseContext();
      var oldCrud = db.CrudItems.FirstOrDefault(f => f.Id == id);
      oldCrud.Description = value.Description;
      oldCrud.NumberInStock = value.NumberInStock;
      oldCrud.Price = value.Price;
      db.SaveChanges();
      return oldCrud;
    }

    // DELETE api/values/5
    [HttpDelete("delete/{SKU}")]
    public ActionResult DeleteCrud(int SKU)
    {
      var db = new DatabaseContext();
      var deleteCrud = db.CrudItems.FirstOrDefault(f => f.SKU == SKU);
      if (deleteCrud == null)
      {
        return NotFound();
      }
      else
      {
        db.CrudItems.Remove(deleteCrud);
        db.SaveChanges();
        return Ok();
      }
    }
  }
}
