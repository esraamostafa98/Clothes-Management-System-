using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication6.BL.Interfaces;
using WebApplication6.DAL.Database;
using WebApplication6.DAL.Entities;
using WebApplication6.Models;

namespace WebApplication6.BL.Repository
{
    public class DepartmentRep : IDepartment
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        public DepartmentRep(DbContainer db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void Add(DepartmentVM dept)
        {
            var data = mapper.Map<Department>(dept);
            db.Department.Add(data);
            db.SaveChanges();


        }

        public void Delete(int id)
        {
            var data = db.Department.Find(id);
            db.Department.Remove(data);
            db.SaveChanges();
        }

        public void Edit(DepartmentVM dept)
        {
            var data = mapper.Map<Department>(dept);
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IQueryable<DepartmentVM> Get()
        {
            var data = db.Department.Select(c => new DepartmentVM
            {
                Id = c.Id,
                DepartmentName=c.DepartmentName
            });
            return data;
        }

        public DepartmentVM GetById(int id)
        {
            var data = db.Department.Where(a => a.Id == id).Select(c => new DepartmentVM
            {
                Id = c.Id,
                DepartmentName = c.DepartmentName
            }).FirstOrDefault();
            return data;
        }
    }
}
