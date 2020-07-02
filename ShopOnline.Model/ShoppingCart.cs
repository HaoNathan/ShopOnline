namespace ShopOnline.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShoppingCart")]
    public partial class ShoppingCart:BaseEntity
    {

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(Color))]
        public Guid ColorId { get; set; }
        public Color Color { get; set; }

        [ForeignKey(nameof(Size))]
        public Guid SizeId { get; set; }
        public Size Size { get; set; }

        public int Number { get; set; }

    }
}
