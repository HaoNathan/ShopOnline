namespace ShopOnline.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SecondProductCategory")]
    public partial class SecondProductCategory:BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string SecondProductCategoryName { get; set; }

       
    }
}
