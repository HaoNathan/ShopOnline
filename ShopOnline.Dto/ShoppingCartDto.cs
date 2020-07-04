using System;

namespace ShopOnline.Dto
{
    public class ShoppingCartDto
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }
       
        public Guid UserId { get; set; }
     
        public Guid ColorId { get; set; }
       
        public Guid SizeId { get; set; }

        public int Number { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsRemove { get; set; }
    }
}