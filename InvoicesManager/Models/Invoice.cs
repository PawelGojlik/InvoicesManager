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
        public Invoice()
        {
                InvoiceItems = new List<InvoiceItem>();   
        }
        
        public int Id { get; set; }

        
        public Customer Customer { get; set; }

        [Required]
        [Display(Name = "Customer name")]
        public int CustomerId { get; set; }

        [Display(Name ="Invoice Number")]
        public int InvoiceNumber { get; set; }

        
        public Company Company { get; set; }

        [Required]
        [Display(Name ="Company name")]
        public int CompanyId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Issue date")]
        public DateTime IssueDate { get; set; }
        

        public IList<InvoiceItem> InvoiceItems;


        //below are calculated properties
        public decimal TotalNet
        {
            get
            {
                if (InvoiceItems == null)
                    return 0;
                else
                    return InvoiceItems.Sum(i => i.TotalNet);
            }
        }

        public decimal TotalGross
        {
            get
            {
                if (InvoiceItems.Count == 0)
                    return 0;
                else
                    return InvoiceItems.Sum(i => i.TotalGross);
            }
        }

    }
}