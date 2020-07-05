namespace ShopOnline.Model
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Collect")]
    public partial class Collect:BaseEntity
    {

        [ForeignKey(nameof(User))]

        public Guid UserId { get; set; }
        public User User { get; set; }


        [ForeignKey(nameof(Product))]

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

       
    }
}
