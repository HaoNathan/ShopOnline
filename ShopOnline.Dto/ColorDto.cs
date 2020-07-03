using System;

namespace ShopOnline.Dto
{
    public class ColorDto
    {
        public Guid Id { get; set; }

        public string ColorName { get; set; }

        public DateTime CreateTime { get; set; } 

        public DateTime UpdateTime { get; set; } 

        public bool IsRemove { get; set; }
    }
}