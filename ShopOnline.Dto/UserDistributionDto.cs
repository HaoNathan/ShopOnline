using System;

namespace ShopOnline.Dto
{
    public class UserDistributionDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
       
        public string ConsigneeAddress { get; set; }
   
        public string ConsigneePhone { get; set; }

        public string ConsigneeName { get; set; }
    }
}