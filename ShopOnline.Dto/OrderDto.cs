using System;

namespace ShopOnline.Dto
{
    public class OrderDto
    {

        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid UserId { get; set; }

        public int PayState { get; set; }

        public Guid UserDistributionId { get; set; }

        public bool DeliverySate { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsRemove { get; set; }
    }
}