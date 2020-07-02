using System;

namespace ShopOnline.Dto
{
    public class BusinessDto
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }

        public Guid ProductId { get; set; }
      
        public Guid PayTypeId { get; set; }

        public int Number { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsRemove { get; set; }
    }
}