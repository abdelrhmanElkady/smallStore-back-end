using System.ComponentModel.DataAnnotations;

namespace smallStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductCost { get; set; }
        public int ProductAmount { get; set; }


    }
}
