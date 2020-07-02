namespace ShopOnline.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserDistribution")]
    public partial class UserDistribution:BaseEntity
    {
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [Required]
        [StringLength(40)]
        public string ConsigneeAddress { get; set; }

        [Required]
        [StringLength(11)]
        public string ConsigneePhone { get; set; }

        [Required]
        [StringLength(10)]
        public string ConsigneeName { get; set; }

    }
}
