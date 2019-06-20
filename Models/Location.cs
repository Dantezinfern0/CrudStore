using System;
using System.Collections.Generic;

namespace crudstore.Models
{
  public class Location
  {
    public int Id { get; set; }
    public string Address { get; set; }
    public string ManagerName { get; set; }
    public string PhoneNumber { get; set; }
    public int StoreNumber { get; set; } = 1234;
     public List<CrudItem> CrudItems { get; set; } = new List<CrudItem>();

  }
}