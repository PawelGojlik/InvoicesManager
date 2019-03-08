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

        public int CustomerId { get; set; }

        public int CurrentMonthNumber { get; set; }

        public Company Company { get; set; }

        public int CompanyId { get; set; }

        public DateTime? IssueDate { get; set; }

    }
}