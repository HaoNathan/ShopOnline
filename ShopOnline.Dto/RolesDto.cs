﻿using System;

namespace ShopOnline.Dto
{
    public class RolesDto
    {
        public Guid Id { get; set; }
        public string RolesName { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsRemove { get; set; }
    }
}