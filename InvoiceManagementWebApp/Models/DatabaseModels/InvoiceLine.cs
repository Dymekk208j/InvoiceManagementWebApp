using System.ComponentModel.DataAnnotations;

namespace InvoiceManagementWebApp.Models.DatabaseModels
{
    public class InvoiceLine
    {
        public int InvoiceLineId { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Ilość")]
        public decimal Quantity { get; set; }

        [Display(Name = "Kwota netto")]
        public decimal NetAmount { get; set; }

        [Display(Name = "VAT %")]
        public int VatPrc { get; set; }

        [Display(Name = "Kwota brutto")]
        public decimal GrossAmount { get; set; }

        [Display(Name = "Kwota wiersza")]
        public decimal LineAmount { get; set; }

        public Invoice Invoice { get; set; }
    }
}