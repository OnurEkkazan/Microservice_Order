using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Order : IEntity
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string CustomerId { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
