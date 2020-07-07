namespace ShopOnline.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User:BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string UserName { get; set; }

        [Required]
        [StringLength(35)]
        public string UserPassword { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(11)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string ImagePath { get; set; }

        public bool IsMember { get; set; }

    }
}
