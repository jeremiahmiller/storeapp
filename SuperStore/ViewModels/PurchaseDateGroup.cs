using System;
using System.ComponentModel.DataAnnotations;

namespace SuperStore.ViewModels
{
    public class PurchaseDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? PurchaseDate { get; set; }

        public int CustomerCount { get; set; }
    }
}
