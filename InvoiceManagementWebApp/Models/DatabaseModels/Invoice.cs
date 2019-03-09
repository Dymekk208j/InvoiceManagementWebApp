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
        Posted
    }

    public class Invoice
    {
        public int InvoiceId { get; set; }

        [Display(Name = "Numer faktury")]
        [Required(ErrorMessage = "Numer faktury nie może być pusty")]
        public string InvoiceNo { get; set; }

        [Display(Name = "Kod waluty")]
        [Required(ErrorMessage = "Kod waluty nie może być pusty")]
        public string CurrencyCode { get; set; }

        [Display(Name = "Data księgowania")]
        [Required(ErrorMessage = "Data księgowania nie może być pusta")]
        public DateTime PostingDate { get; set; }

        [Display(Name = "Data dokumentu")]
        [Required(ErrorMessage = "Data dokumentu nie może być pusta")]
        public DateTime DocumentDate { get; set; }

        [Display(Name = "Termin płatności")]
        [Required(ErrorMessage = "Termin płatności nie może być pusta")]
        public DateTime PaymentDue { get; set; }

        [Display(Name = "Stan")]
        public State State { get; set; }

        [Display(Name = "Nabywca")]
        public Company Customer { get; set; }

        [Display(Name = "Dostawca")]
        public Company Vendor { get; set; }

        [Display(Name = "Wiersze faktury")]
        public virtual List<InvoiceLine> Lines { get; set; }

    }
}