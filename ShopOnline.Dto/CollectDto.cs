using System;

namespace ShopOnline.Dto
{
    public class CollectDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        
        public string UserName { get; set; }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; }


        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsRemove { get; set; }
    }
}