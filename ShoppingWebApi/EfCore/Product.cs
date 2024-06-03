using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingWebApi.EfCore
{
    [Table("Product")]
    public class Product
    {
        [Key,Required]
        public int id { get; set; }

        public string name { get; set; } = string.Empty;
        public string brand { get; set; } = string.Empty;
        public int Size { get; set; }

        public decimal price { get; set; }
    }
}
