using System;
using System.ComponentModel.DataAnnotations;

namespace petStoreWebAPI.Models
{
    public class Session
    {
        public int SessionId { get; set; } //the primary key for the database

        [Required]
        public int PageID { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime Start_TimeStamp { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime End_TimeStamp { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime Request_TimeStamp { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
