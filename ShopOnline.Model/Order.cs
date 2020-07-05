
namespace ShopOnline.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class Order:BaseEntity
    {
        [ForeignKey(nameof(OrderInfo))]
        public Guid OrderId { get; set; }
        public OrderInfo OrderInfo { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public string Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }
}