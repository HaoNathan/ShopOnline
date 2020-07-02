namespace ShopOnline.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Business")]
    public partial class Business:BaseEntity
    {

        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey(nameof(PayType))]
        public Guid PayTypeId { get; set; }
        public PayType PayType { get; set; }

        public int Number { get; set; }

     
    }
}
