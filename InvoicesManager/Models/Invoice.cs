using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InvoicesManager.Models;
using System.ComponentModel.DataAnnotations;

namespace InvoicesManager.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        public Customer Customer { get; set; }

        [Display(Name = "Customer name")]
        public int CustomerId { get; set; }

        [Display(Name ="Invoice ID")]
        public int CurrentMonthNumber { get; set; }

        public Company Company { get; set; }

        [Display(Name ="Company name")]
        public int CompanyId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Issue date")]
        public DateTime IssueDate { get; set; }

    }
}