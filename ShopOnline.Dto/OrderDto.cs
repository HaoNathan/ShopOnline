using System;

namespace ShopOnline.Dto
{
    public class OrderDto
    {

        public Guid Id { get; set; }

        public Guid OrderId { get; set; }
      
        public Guid ProductId { get; set; }
   
        public string Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsRemove { get; set; }

    }
}