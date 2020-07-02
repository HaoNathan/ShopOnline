namespace ShopOnline.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Collect")]
    public partial class Collect:BaseEntity
    {

        [ForeignKey(nameof(User))]

        public Guid UserId { get; set; }
        public User User { get; set; }


        [ForeignKey(nameof(Product))]

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

       
    }
}
