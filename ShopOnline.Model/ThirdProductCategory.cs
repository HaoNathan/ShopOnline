namespace ShopOnline.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThirdProductCategory")]
    public partial class ThirdProductCategory:BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string ThirdProductCategoryName { get; set; }

    }
}
