using System;
using System.ComponentModel.DataAnnotations;

namespace petStoreWebAPI.Models
{
    public class AnimalPurchaseCategory
    {
        public int AnimalPurchaseCategoryId { get; set; } //the primary key for the database

        [Required]
        public string? Category { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime TimeStamp { get; set; }
    }
}