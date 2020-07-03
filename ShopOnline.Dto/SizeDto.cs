using System;

namespace ShopOnline.Dto
{
    public class SizeDto
    {

        public Guid Id { get; set; }

        public string SizeName { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public bool IsRemove { get; set; }
    }
}