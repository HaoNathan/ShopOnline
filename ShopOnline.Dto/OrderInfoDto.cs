using System;

namespace ShopOnline.Dto
{
    public class OrderInfoDto
    {

        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid UserId { get; set; }

        public int PayState { get; set; }
        public string PayType { get; set; }

        public string Phone { get; set; }
        
        public string AcceptName { get; set; }
       
        public string Address { get; set; }

        public decimal TotalPrice { get; set; }
        public bool DeliverySate { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsRemove { get; set; }
    }
}