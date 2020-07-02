namespace ShopOnline.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Roles:BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string RolesName { get; set; }

    }
}
