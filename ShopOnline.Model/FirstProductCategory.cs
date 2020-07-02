namespace ShopOnline.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FirstProductCategory")]
    public partial class FirstProductCategory:BaseEntity
    {
 

        [Required]
        [StringLength(50)]
        public string FirstProductCategoryName { get; set; }

       
    }
}
