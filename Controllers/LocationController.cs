using System;
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
  public class LocationController : ControllerBase
  {
    public ActionResult<List<Location>> GetAllLocations()
    {
      var db = new DatabaseContext();
      var rv = db.Locations;
      return rv.ToList();
    }
    [HttpPost("shitshit")]
    public ActionResult<Location> PostAddLocation([FromBody] Location data)
    {
      var db = new DatabaseContext();
      db.Locations.Add(data);
      db.SaveChanges();
      return data;
    }
    [HttpGet("fk")]
    public ActionResult<List<CrudItem>> GetAllLocation([FromQuery] int LocationId)
    {
      var db = new DatabaseContext();
      var data = db.Locations.Include(i => i.CrudItems).FirstOrDefault(u => u.StoreNumber == LocationId);
      return data.CrudItems;
    }
    [HttpPut("{id}")]
    public ActionResult<Location> Put(int id, [FromBody]CrudItem value)
    {
      var db = new DatabaseContext();
      var oldCrud = db.Locations.FirstOrDefault(f => f.Id == id);
      oldCrud.StoreNumber = value.Id;
      db.SaveChanges();
      return oldCrud;
    }
    [HttpPost("addlocation")]
    public ActionResult<Location> PostAddCrud([FromBody] Location data)
    {
      var db = new DatabaseContext();
      db.Locations.Add(data);
      db.SaveChanges();
      return data;
    }
  }
}