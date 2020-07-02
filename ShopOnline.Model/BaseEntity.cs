using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Model
{
    public class BaseEntity
    {
        public Guid Id { get; set; } =Guid.NewGuid();
        public DateTime CreateTime { get; set; }=DateTime.Now;
        public DateTime UpdateTime { get; set; }=DateTime.Now;
        public bool IsRemove { get; set; }
    }
}
