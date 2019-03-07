using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InvoicesManager.Models;

namespace InvoicesManager.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public Company Company { get; set; }

        public int CompanyId { get; set; }

        public int CurrentMonthId { get; set; }
    }
}