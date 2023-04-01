using WebApplication6.DAL.Entities;
using WebApplication6.Models;

namespace WebApplication6.BL.Interfaces
{
    public interface IDepartment
    {
        IQueryable<DepartmentVM> Get();
        DepartmentVM GetById(int id);
        void Add(DepartmentVM dept);
        void Edit(DepartmentVM dept);
        void Delete(int id);
    }
}
