using System.ComponentModel.DataAnnotations;

namespace smallStore.Models
{
    public class Receipt
    {
        [Key]
        public int Id { get; set; }
        public List<SoldProduct> SoldProducts { get; set; }
        public string ClientName { get; set; }
        public DateTime DayDate { get; set; }

    }
}
