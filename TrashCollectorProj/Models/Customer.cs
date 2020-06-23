using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorProj.Models
{
    public class Customer
    {
        [Key]

        public int CustomerID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int ZipCode { get; set; }

        public DayOfWeek PickUpDay { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExtraPickUp { get; set; }

        public double BalanceOwed { get; set; }

        [DataType(DataType.Date)]
        public DateTime SupendPickUpStart { get; set; }

        [DataType(DataType.Date)]
        public DateTime SuspendPickUpEnd { get; set; }

        [ForeignKey("IdentityUser")]

        public string IdentityUserID { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
