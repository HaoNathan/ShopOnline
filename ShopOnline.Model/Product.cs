namespace ShopOnline.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product:BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string ProductName { get; set; }

        [Column(TypeName = "money")]
        public decimal ProductPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal ProductCost { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string ProductImagePath { get; set; }

        public int ProductNumber { get; set; }

        [Column(TypeName = "text")]
        public string ProductDescription { get; set; }

        [ForeignKey(nameof(Color))]
        public Guid ColorId { get; set; }
        public Color Color { get; set; }

        [ForeignKey(nameof(Size))]
        public Guid SizeId { get; set; }
        public Size Size { get; set; }

        [ForeignKey(nameof(FirstProductCategory))]
        public Guid FirstProductCategoryId { get; set; }
        public FirstProductCategory FirstProductCategory { get; set; }

        [ForeignKey(nameof(SecondProductCategory))]
        public Guid SecondProductCategoryId { get; set; }
        public SecondProductCategory SecondProductCategory { get; set; }

        [ForeignKey(nameof(ThirdProductCategory))]
        public Guid ThirdProductCategoryId { get; set; }
        public ThirdProductCategory ThirdProductCategory { get; set; }

        public int GS1Id { get; set; }

    }
}
