using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorProj.Models
{
    public class Customer
    {
        [Key]

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int ZipCode { get; set; }

        public DayOfWeek PickUpDay { get; set; }

        public DateTime ExtraPickUp { get; set; }

        public double BalanceOwed { get; set; }

        public DateTime SupendPickUpStart { get; set; }

        public DateTime SuspendPickUpEnd { get; set; }

    }
}
