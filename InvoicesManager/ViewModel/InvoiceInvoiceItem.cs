using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InvoicesManager.Models;

namespace InvoicesManager.ViewModel
{
    public class InvoiceInvoiceItem
    {
        public Invoice Invoice { get; set; }

        public InvoiceItem InvoiceItem { get; set; }
    }
}