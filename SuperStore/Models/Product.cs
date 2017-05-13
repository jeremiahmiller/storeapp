using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperStore.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
