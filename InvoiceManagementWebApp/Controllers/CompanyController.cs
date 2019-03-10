
using InvoiceManagementWebApp.Models.DatabaseModels;
using InvoiceManagementWebApp.Repository;
using System.Web.Mvc;

namespace InvoiceManagementWebApp.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        private readonly CompanyRepository _repository;

        public CompanyController(CompanyRepository companyRepository)
        {        
           _repository = companyRepository;
        }

        public ActionResult CustomerManagement()
        {
            return View();
        }

        public ActionResult VendorManagement()
        {
            return View();
        }

        public ActionResult GetTable(RelationType relation)
        {
            return PartialView("_TablePartialView", _repository.GetAll(relation));
        }

        public ActionResult GetCreatePartialView(RelationType relation)
        {
            var company = new Company()
            {
                Relation = relation
            };

            return PartialView("_CreatePartialView", company);
        }

        public ActionResult GetModificationPartialView(int companyId)
        {
            return PartialView("_ModificationPartialView", _repository.Get(companyId));
        }

        public ActionResult Create(Company company)
        {
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(company);
                }
                else return PartialView("_CreatePartialView", company);
            }

            return PartialView("_TablePartialView", _repository.GetAll(company.Relation));
        }

        public ActionResult Update(Company company)
        {
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(company);
                }
                else return PartialView("_ModificationPartialView", company);
            }

            return PartialView("_TablePartialView", _repository.GetAll(company.Relation));
        }

        public ActionResult Remove(int companyId)
        {
            var company = _repository.Get(companyId);
            _repository.Remove(company);

            return PartialView("_TablePartialView", _repository.GetAll(company.Relation));
        }
    }
}