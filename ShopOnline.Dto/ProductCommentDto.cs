using System;

namespace ShopOnline.Dto
{
    public class ProductCommentDto
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string Comment { get; set; }

        public Guid UserId { get; set; }
        
        public int Praise { get; set; }

        public int Oppose { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsRemove { get; set; }
    }
}