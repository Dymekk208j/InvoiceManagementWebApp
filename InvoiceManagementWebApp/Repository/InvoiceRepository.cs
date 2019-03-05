using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using InvoiceManagementWebApp.Models.DatabaseModels;
using Unity.Attributes;

namespace InvoiceManagementWebApp.Repository
{
    public class InvoiceRepository : IRepository<Invoice, int>
    {
        [Dependency]
        public ApplicationDbContext Context { get; set; }

        public InvoiceRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public List<Invoice> GetAll()
        {
            return Context.Invoices.Include("Customer").Include("Vendor").Include("Lines").ToList();
        }

        public Invoice Get(int id)
        {
            return Context.Invoices.Include("Customer").Include("Vendor").Include("Lines").First(c => c.InvoiceId == id);
        }

        public bool Add(Invoice entity)
        {
            Context.Invoices.Add(entity);
            Context.Entry(entity.Customer).State = EntityState.Unchanged;
            Context.Entry(entity.Vendor).State = EntityState.Unchanged;
            Context.Entry(entity.Lines).State = EntityState.Unchanged;
            return Context.SaveChanges() > 0;
        }

        public bool Remove(Invoice entity)
        {
            try
            {
                Invoice obj = Context.Invoices.First(a => a.InvoiceId == entity.InvoiceId);
                Context.Invoices.Remove(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return Context.SaveChanges() > 0;
        }

        public bool Remove(int id)
        {
            try
            {
                Invoice obj = Context.Invoices.First(a => a.InvoiceId == id);
                Context.Invoices.Remove(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return Context.SaveChanges() > 0;
        }

        public bool Update(Invoice entity)
        {
            try
            {
                Invoice invoice = Context.Invoices.Single(a => a.InvoiceId == entity.InvoiceId) ?? throw new Exception($"Not found id: {entity.InvoiceId}");
                invoice.InvoiceNo = entity.InvoiceNo;
                invoice.CurrencyCode = entity.CurrencyCode;
                invoice.PostingDate = entity.PostingDate;
                invoice.DocumentDate = entity.DocumentDate;
                invoice.PaymentDue = entity.PaymentDue;
                invoice.State = entity.State;
                invoice.Customer = Context.Companies.Single(a => a.CompanyId == entity.Customer.CompanyId);
                invoice.Vendor = Context.Companies.Single(a => a.CompanyId == entity.Vendor.CompanyId);
                invoice.Lines = Context.InvoiceLines.Where(a => a.Invoice.InvoiceId == entity.InvoiceId).ToList();

                return Context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}