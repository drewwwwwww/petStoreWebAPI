using System;
using System.ComponentModel.DataAnnotations;

namespace petStoreWebAPI.Models
{
    public class OrderState
    {
        public int OrderStateId { get; set; } //the primary key for the database

        [Required]
        public string? State { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime TimeStamp { get; set; }
    }
}
