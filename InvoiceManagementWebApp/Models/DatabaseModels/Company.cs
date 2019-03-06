using System.ComponentModel.DataAnnotations;

namespace InvoiceManagementWebApp.Models.DatabaseModels
{
    public enum RelationType
    {
        [Display(Name = "Nabywca")]
        Customer,
        [Display(Name = "Dostawca")]
        Vendor
    }

    public class Company
    {
        public int CompanyId { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Adres 2")]
        public string Address2 { get; set; }

        [Display(Name = "NIP")]
        public string Nip { get; set; }

        [Display(Name = "REGON")]
        public string Regon { get; set; }

        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Display(Name = "Kod pocztowy")]
        public string PostCode { get; set; }

        [Display(Name = "Numer telefonu")]
        public string PhoneNumber { get; set; }

        public RelationType Relation { get; set; }
    }
}