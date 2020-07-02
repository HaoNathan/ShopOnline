namespace ShopOnline.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin:BaseEntity
    {

        [Required]
        [StringLength(30)]
        public string AdminName { get; set; }

        [Required]
        [StringLength(30)]
        public string AdminPassword { get; set; }

        [Required]
        [StringLength(120)]
        public string ImagePath { get; set; }

        [ForeignKey(nameof(Roles))]
        public Guid RolesId { get; set; }
        public Roles Roles { get; set; }

    }
}
