using System.Collections.Generic;

namespace InvoiceManagementWebApp.Repository
{
    public interface IRepository<TEnt, in TPk> where TEnt : class
    {
        List<TEnt> GetAll();
        TEnt Get(TPk id);
        bool Add(TEnt entity);
        bool Remove(TEnt entity);
        bool Remove(TPk id);
        bool Update(TEnt entity);
    }
}
