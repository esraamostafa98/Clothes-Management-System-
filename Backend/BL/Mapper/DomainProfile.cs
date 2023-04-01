using AutoMapper;
using WebApplication6.DAL.Entities;
using WebApplication6.Models;
using File = WebApplication6.DAL.Entities.File2;

namespace WebApplication6.BL.Mapper
{
    public class DomainProfile: Profile
    {
        public DomainProfile()
        {
            CreateMap<DepartmentVM, Department>();
            CreateMap<Department, DepartmentVM>();

            CreateMap<EmployeeVM, Employee>();
            CreateMap<Employee, EmployeeVM>();

            CreateMap<ProductVM, Product>();
            CreateMap<Product, ProductVM>();

            CreateMap<FilesVM, Files>();
            CreateMap<Files, FilesVM>();
        }
           
    }
}
