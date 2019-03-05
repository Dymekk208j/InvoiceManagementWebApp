using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using InvoiceManagementWebApp.Models.DatabaseModels;
using Unity.Attributes;

namespace InvoiceManagementWebApp.Repository
{
    public class InvoiceLineRepository : IRepository<InvoiceLine, int>
    {
        [Dependency]
        public ApplicationDbContext Context { get; set; }

        public InvoiceLineRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public List<InvoiceLine> GetAll()
        {
            return Context.InvoiceLines.Include("Invoice").ToList();
        }

        public InvoiceLine Get(int id)
        {
            return Context.InvoiceLines.Include("Invoice").First(c => c.InvoiceLineId == id);
        }

        public bool Add(InvoiceLine entity)
        {
            Context.InvoiceLines.Add(entity);
            Context.Entry(entity.Invoice).State = EntityState.Unchanged;

            return Context.SaveChanges() > 0;
        }

        public bool Remove(InvoiceLine entity)
        {
            try
            {
                InvoiceLine obj = Context.InvoiceLines.First(a => a.InvoiceLineId == entity.InvoiceLineId);
                Context.InvoiceLines.Remove(obj);
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
                InvoiceLine obj = Context.InvoiceLines.First(a => a.InvoiceLineId == id);
                Context.InvoiceLines.Remove(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return Context.SaveChanges() > 0;
        }

        public bool Update(InvoiceLine entity)
        {
            try
            {
                InvoiceLine invoiceLine = Context.InvoiceLines.Single(a => a.InvoiceLineId == entity.InvoiceLineId) ?? throw new Exception($"Not found id: {entity.InvoiceLineId}");
                invoiceLine.Name = entity.Name;
                invoiceLine.Quantity = entity.Quantity;
                invoiceLine.NetAmount = entity.NetAmount;
                invoiceLine.VatPrc = entity.VatPrc;
                invoiceLine.GrossAmount = entity.GrossAmount;
                invoiceLine.LineAmount = entity.LineAmount;

                invoiceLine.Invoice = Context.Invoices.Single(a => a.InvoiceId == entity.Invoice.InvoiceId);

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