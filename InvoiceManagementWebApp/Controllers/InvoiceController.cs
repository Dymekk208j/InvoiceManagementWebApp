using System.Web.Mvc;
using InvoiceManagementWebApp.Models.DatabaseModels;
using InvoiceManagementWebApp.Repository;

namespace InvoiceManagementWebApp.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly InvoiceRepository _repository;

        public InvoiceController(InvoiceRepository invoiceRepository)
        {
            _repository = invoiceRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetTable()
        {
            return PartialView("_TablePartialView", _repository.GetAll());
        }

        public ActionResult GetCreatePartialView()
        {
            return PartialView("_CreateNewPartialView", new Invoice());
        }

        public ActionResult Create(Invoice invoice)
        {
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(invoice);
                }
                else return PartialView("_CreateNewPartialView", invoice);
            }

            return PartialView("_TablePartialView", _repository.GetAll());
        }

    }
}