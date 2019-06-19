using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace crudstore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CrudController : ControllerBase
  {
    // GET api/values
    [HttpGet]
    public ActionResult<List<CrudItem>> Get()
    {
      var db = new DatabaseContext();
      var rv = db.CrudItems;
      return rv.ToList();
    }

    // GET api/values/5
    // current proj
    [HttpGet("{Id}")]
    public ActionResult<CrudItem> GetSingleItem(int Id)
    {
      var db = new DatabaseContext();
      var rv = db.CrudItems.Find(Id);
      return rv;
    }

    // POST api/values
    // finished and working
    [HttpPost]
    public ActionResult<CrudItem> Post([FromBody] CrudItem data)
    {
      var db = new DatabaseContext();
      db.CrudItems.Add(data);
      db.SaveChanges();
      return data;
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
