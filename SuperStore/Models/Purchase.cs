using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SuperStore.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
