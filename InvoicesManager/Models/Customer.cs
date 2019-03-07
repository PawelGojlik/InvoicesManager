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
        [MaxLength(6)]
        [Display(Name = "Zip code")]
        [RegularExpression(@"[0-9]{2}[-][0-9]{3}", ErrorMessage = "Inappropriate format")]
        public string ZipCode { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "City")]
        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "Inappropriate format")]
        public string City { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Tax identifier")]
        [RegularExpression(@"[0-9]{10}", ErrorMessage = "Inappropriate format")]
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