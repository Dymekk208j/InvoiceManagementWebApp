using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceManagementWebApp.Models.DatabaseModels
{
    public enum State
    {
        [Display(Name = "Otwarta")]
        Open,
        [Display(Name = "Zaksięgowana")]
        Posted,
        [Display(Name = "Anulowana")]
        Canceled,
        [Display(Name = "Korekta")]
        Correction
    }

    public class Invoice
    {
        public int InvoiceId { get; set; }

        [Display(Name = "Numer faktury")]
        public string InvoiceNo { get; set; }

        [Display(Name = "Kod waluty")]
        public string CurrencyCode { get; set; }

        [Display(Name = "Data księgowania")]
        public DateTime PostingDate { get; set; }

        [Display(Name = "Data dokumentu")]
        public DateTime DocumentDate { get; set; }

        [Display(Name = "Termin płatności")]
        public DateTime PaymentDue { get; set; }

        [Display(Name = "Stan")]
        public State State { get; set; }

        [Display(Name = "Nabywca")]
        public Company Customer { get; set; }

        [Display(Name = "Dostawca")]
        public Company Vendor { get; set; }

        [Display(Name = "Wiersze faktury")]
        public virtual IEnumerable<InvoiceLine> Lines { get; set; }

    }
}