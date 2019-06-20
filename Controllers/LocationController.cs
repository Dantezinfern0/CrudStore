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
    [HttpPost("location")]
    public ActionResult<Location> PostAddLocation([FromBody] Location data)
    {
      var db = new DatabaseContext();
      db.Locations.Add(data);
      db.SaveChanges();
      return data;
    }
    [HttpGet]
    public ActionResult<List<Location>> GetAllLocation()
    {
      var db = new DatabaseContext();
      var rv = db.Locations;
      return rv.ToList();
    }
  }
}