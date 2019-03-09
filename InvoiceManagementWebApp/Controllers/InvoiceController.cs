using InvoiceManagementWebApp.Models.DatabaseModels;
using InvoiceManagementWebApp.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace InvoiceManagementWebApp.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly InvoiceRepository _repository;

        public InvoiceController(InvoiceRepository invoiceRepository)
        {
            _repository = invoiceRepository;
        }

        public ActionResult SalesInvoice()
        {
            return View();
        }

        public ActionResult PurchaseInvoice()
        {
            return View();
        }

        public ActionResult GetTable(InvoiceType type)
        {
            return PartialView("_TablePartialView", _repository.GetAll().Where(i => i.InvoiceType == type && i.State == State.Open));
        }

        public ActionResult GetCreatePartialView(InvoiceType type)
        {
            var invoice = new Invoice
            {
                InvoiceType = type,
                Lines = new List<InvoiceLine>(15)
            };

            for (int i = 0; i < 15; i++) invoice.Lines.Add(null);

            return PartialView("_CreateNewPartialView", invoice);
        }

        public ActionResult Create(Invoice invoice, bool save)
        {
            if (!save) invoice.State = State.Posted;

            var companies = _repository.GetCompanies();
            invoice.Lines.RemoveAll(line => string.IsNullOrEmpty(line.Name));
            invoice.Customer = companies.FirstOrDefault(c => c.CompanyId == invoice.Customer.CompanyId);
            invoice.Vendor = companies.FirstOrDefault(c => c.CompanyId == invoice.Vendor.CompanyId);
            ModelState.Clear();
            TryValidateModel(invoice);

            if (invoice.Customer == null) ModelState.AddModelError("", "Musisz wybrać nabywcę");
            if (invoice.Vendor == null) ModelState.AddModelError("", "Musisz wybrać dostawcę");

            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(invoice);
                }
                else
                {
                    int linesAmount = invoice.Lines.Count;
                    for (int i = 0; i < 15 - linesAmount; i++)
                    {
                        invoice.Lines.Add(null);
                    }
                    return PartialView("_CreateNewPartialView", invoice);
                }
            }

            return PartialView("_TablePartialView", _repository.GetAll().Where(i => i.InvoiceType == invoice.InvoiceType && i.State == State.Open));
        }

        public ActionResult Update(Invoice invoice, bool save)
        {
            if (!save) invoice.State = State.Posted;

            var companies = _repository.GetCompanies();
            invoice.Lines.RemoveAll(line => string.IsNullOrEmpty(line.Name));
            invoice.Customer = companies.FirstOrDefault(c => c.CompanyId == invoice.Customer.CompanyId);
            invoice.Vendor = companies.FirstOrDefault(c => c.CompanyId == invoice.Vendor.CompanyId);


            ModelState.Clear();
            TryValidateModel(invoice);

            if (invoice.Customer == null) ModelState.AddModelError("", "Musisz wybrać nabywcę");
            if (invoice.Vendor == null) ModelState.AddModelError("", "Musisz wybrać dostawcę");

            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(invoice);
                }
                else
                {
                    int linesAmount = invoice.Lines.Count;
                    for (int i = 0; i < 15 - linesAmount; i++)
                    {
                        invoice.Lines.Add(null);
                    }
                    return PartialView("_ModificationPartialView", invoice);
                }
            }

            return PartialView("_TablePartialView", _repository.GetAll().Where(i => i.InvoiceType == invoice.InvoiceType && i.State == State.Open));
        }

        public ActionResult GetSelectCompanyPartialView()
        {
            return PartialView("_ModalSelectCompanyPartialView", _repository.GetCompanies());
        }

        public ActionResult GetModificationPartialView(int id)
        {
            return PartialView("_ModificationPartialView", _repository.Get(id));
        }

        public ActionResult Remove(int id)
        {
            var type = _repository.Get(id).InvoiceType;
            _repository.Remove(id);

            return PartialView("_TablePartialView", _repository.GetAll().Where(i => i.InvoiceType == type && i.State == State.Open));

        }
    }
}