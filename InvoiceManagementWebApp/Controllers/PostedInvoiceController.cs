using System.Linq;
using System.Web.Mvc;
using InvoiceManagementWebApp.Models.DatabaseModels;
using InvoiceManagementWebApp.Repository;

namespace InvoiceManagementWebApp.Controllers
{
    [Authorize]
    public class PostedInvoiceController : Controller
    {
        private readonly InvoiceRepository _repository;

        public PostedInvoiceController(InvoiceRepository invoiceRepository)
        {
            _repository = invoiceRepository;
        }

        public ActionResult SalesInvoicesManagement()
        {
            return View();
        }

        public ActionResult PurchaseInvoicesManagement()
        {
            return View();
        }

        public ActionResult GetTable(InvoiceType type)
        {
            return PartialView("_TablePartialView", _repository.GetAll().Where(i => i.InvoiceType == type && i.State == State.Posted));
        }

        public ActionResult GetDetailsFormPartialView(int id)
        {
            return PartialView("_DetailsFormPartialView", _repository.Get(id));
        }
    }
}