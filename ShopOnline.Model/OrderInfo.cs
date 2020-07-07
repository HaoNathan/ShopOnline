namespace ShopOnline.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderInfo")]
    public partial class OrderInfo:BaseEntity
    {

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }

        public int PayState { get; set; }
        [StringLength(11)]
        public string Phone { get; set; }

        public string AcceptName { get; set; }
        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        public bool DeliverySate { get; set; }
    }
}
