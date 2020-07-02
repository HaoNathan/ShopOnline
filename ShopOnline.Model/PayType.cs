namespace ShopOnline.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PayType")]
    public partial class PayType:BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string PayTypeName { get; set; }

    }
}
