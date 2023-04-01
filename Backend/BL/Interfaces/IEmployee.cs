using WebApplication6.DAL.Entities;
using WebApplication6.Models;

namespace WebApplication6.BL.Interfaces
{
    public interface IEmployee
    {
        IQueryable<EmployeeVM> Get();
        EmployeeVM GetById(int id);
        void Add(EmployeeVM emp);
        void Edit(EmployeeVM en);
        void Delete(int id);
    }
}
