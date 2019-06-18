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
    // [HttpGet]
    // public ActionResult<List<CrudItem>> Get()
    // {
    //     return new string<List> { "value1", "value2" };
    // }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value";
    }

    // POST api/values
    // first thing I'm doing on this page to get a reading
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
