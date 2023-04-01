using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication6.BL.helper;
using WebApplication6.BL.Interfaces;
using WebApplication6.DAL.Database;
using WebApplication6.DAL.Entities;
using WebApplication6.Models;

namespace WebApplication6.BL.Repository
{
    public class EmployeeRep : IEmployee
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        public EmployeeRep(DbContainer db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public void Add(EmployeeVM emp)
        {
            var data = mapper.Map<Employee>(emp);
            data.PhotoName = UploadFile.SaveFile(emp.PhotoUrl, "Photos");
            db.Employee.Add(data);
            db.SaveChanges();
            
        }

        public void Delete(int id)
        {
            var data = db.Employee.Find(id);
            db.Employee.Remove(data);
            db.SaveChanges();
            
        }

        public void Edit(EmployeeVM emp)
        {
            var data = mapper.Map<Employee>(emp);
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();

        }

        public IQueryable<EmployeeVM> Get()
        {
            var data = db.Employee.Select(c => new EmployeeVM
            {
                Id = c.Id,
                Name = c.Name,
              Email= c.Email,
              Phone= c.Phone,
              Salary= c.Salary,
              PhotoName= c.PhotoName,
              DepartmentId= c.DepartmentId,
              DepartmentName=c.Department.DepartmentName
            });
            return data;
        }

        public EmployeeVM GetById(int id)
        {
            var data = db.Employee.Where(a => a.Id == id).Select(c => new EmployeeVM
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                Salary = c.Salary,
                PhotoName=c.PhotoName,
                DepartmentId = c.DepartmentId,
                DepartmentName = c.Department.DepartmentName
            }).FirstOrDefault();
            return data;
        }
    }
}





