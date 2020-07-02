using System;

namespace ShopOnline.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }
      
        public string Email { get; set; }

        public string Phone { get; set; }

        public string ImagePath { get; set; }

        public bool IsMember { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsRemove { get; set; }
    }
}