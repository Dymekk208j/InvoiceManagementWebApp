using System;
using System.Collections.Generic;
using System.Linq;
using InvoiceManagementWebApp.Models;
using InvoiceManagementWebApp.Models.DatabaseModels;
using Unity.Attributes;

namespace InvoiceManagementWebApp.Repository
{
    public class CompanyRepository : IRepository<Company, int>
    {
        [Dependency]
        public ApplicationDbContext Context { get; set; }

        public CompanyRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public IEnumerable<Company> GetAll()
        {
            return Context.Companies.ToList();
        }

        public Company Get(int id)
        {
            return Context.Companies.First(c => c.CompanyId == id);
        }

        public bool Add(Company entity)
        {
            Context.Companies.Add(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Remove(Company entity)
        {
            try
            {
                Company obj = Context.Companies.First(a => a.CompanyId == entity.CompanyId);
                Context.Companies.Remove(obj);
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
                Company obj = Context.Companies.First(a => a.CompanyId == id);
                Context.Companies.Remove(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return Context.SaveChanges() > 0;
        }

        public bool Update(Company entity)
        {
            try
            {
                Company company = Context.Companies.Single(a => a.CompanyId == entity.CompanyId) ?? throw new Exception($"Not found id: {entity.CompanyId}");
                company.Name = entity.Name;
                company.Address = entity.Address;
                company.Address2 = entity.Address2;
                company.Nip = entity.Nip;
                company.Regon = entity.Regon;
                company.City = entity.City;
                company.PostCode = entity.PostCode;
                company.PhoneNumber = entity.PhoneNumber;
                company.Type = entity.Type;

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