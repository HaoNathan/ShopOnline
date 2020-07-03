using System;
using System.IO.Compression;

namespace ShopOnline.Dto
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public decimal ProductCost { get; set; }

        public string ProductImagePath { get; set; }

        public int ProductNumber { get; set; }

        public string ProductDescription { get; set; }
       
        public Guid ColorId { get; set; }

        public string ColorName { get; set; }

        public Guid SizeId { get; set; }

        public string SizeName { get; set; }

        public Guid FirstProductCategoryId { get; set; }

        public string FirstProductCategoryName { get; set; }

        public Guid SecondProductCategoryId { get; set; }

        public string SecondProductCategoryName { get; set; }

        public Guid ThirdProductCategoryId { get; set; }

        public string ThirdProductCategoryName { get; set; }

        public int GS1Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsRemove { get; set; }

    }
}