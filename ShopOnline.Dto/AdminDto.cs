using System;

namespace ShopOnline.Dto
{
    public class AdminDto
    {
        public Guid Id { get; set; }
        public string AdminName { get; set; }
        public string AdminPassword { get; set; }
        public string ImagePath { get; set; }
        public string RolesName { get; set; }
        public Guid RolesId { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsRemove { get; set; }

    }
}