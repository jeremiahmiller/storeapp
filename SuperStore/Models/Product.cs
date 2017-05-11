using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperStore.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int ProductID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0, 5)]
        public int Price { get; set; }

        public int DepartmentID { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
