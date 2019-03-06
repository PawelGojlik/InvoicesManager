using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InvoicesManager.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name =" Customer name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Zip code")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "City")]
        [DataType(DataType.Text)]
        public string City { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Tax identifier")]
        public string NIP { get; set; }


        [MaxLength(20)]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [MaxLength(100)]
        [Display(Name = "Contact person")]
        public string ContactPerson { get; set; }
    }
}