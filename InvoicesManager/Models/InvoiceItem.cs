using System.ComponentModel.DataAnnotations;

namespace InvoicesManager.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; }

        public Invoice Invoice { get; set; }

        [Display(Name = "Invoice ID")]
        public int InvoiceId { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        [Required]
        [Range(0,100)]
        public decimal VATRate { get; set; }

        //below are calculated properties
        public decimal  TotalNet
        {
            get
            {
                return UnitPrice * Quantity;
            }
        }

        public decimal VAT
        {
            get
            {
                return TotalNet * VATRate/100;
            }
        }

        public decimal TotalGross
        {
            get
            {
                return TotalNet + VAT;
            }
        }
    }
}