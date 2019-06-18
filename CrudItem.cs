using System;

namespace crudstore
{
  public class CrudItem
  {
    public int Id { get; set; }
    public int SKU { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } = "gross";
    public int NumberInStock { get; set; } = 1;
    public decimal Price { get; set; } = 10.00m;
    public DateTime DateOrdered { get; set; } = DateTime.Now;
  }
}