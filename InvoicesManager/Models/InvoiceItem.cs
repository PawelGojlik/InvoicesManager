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
        [RegularExpression(@"^[0 - 9] *\.[0-9]{2}$", ErrorMessage = "Inappropriate format")]
        [Range(0.01,double.MaxValue)]
        public double UnitPrice { get; set; }

        [Required]
        [RegularExpression(@"^[0 - 9] *\.[0-9]{2}$", ErrorMessage = "Inappropriate format")]
        [Range(1,int.MaxValue)]
        public double Quantity { get; set; }

        [Required]
        [RegularExpression(@"^[0 - 9] *\.[0-9]{2}$", ErrorMessage = "Inappropriate format")]
        [Range(0,100)]
        public double VATRate { get; set; }

        //below are calculated properties
        public double  TotalNet
        {
            get
            {
                return UnitPrice * Quantity;
            }
        }

        public double VAT
        {
            get
            {
                return TotalNet * VATRate/100;
            }
        }

        public double TotalGross
        {
            get
            {
                return TotalNet + VAT;
            }
        }
    }
}