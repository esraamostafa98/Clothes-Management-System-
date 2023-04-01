using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication6.BL.helper;
using WebApplication6.BL.Interfaces;
using WebApplication6.DAL.Database;
using WebApplication6.DAL.Entities;
using WebApplication6.Models;

namespace WebApplication6.BL.Repository
{
    public class ProductRep : IProduct
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        public ProductRep(DbContainer db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public void Add(ProductVM prod)
        {
            var data = mapper.Map<Product>(prod);
            data.PhotoName = UploadFile.SaveFile(prod.PhotoUrl, "assets");
            db.Product.Add(data);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = db.Product.Find(id);
            db.Product.Remove(data);
            db.SaveChanges();

        }

        public void Edit(ProductVM prod)
        {
            //var data = mapper.Map<Product>(prod);
            var record = db.Product.Find(prod.id);
            if(prod.ProductName!= null)
            {
                record.ProductName=prod.ProductName;
            }
            if (prod.Price != null)
            {
                record.Price =(int) prod.Price;
            }
            if (prod.PhotoUrl!= null) 
            { record.PhotoName = UploadFile.SaveFile(prod.PhotoUrl, "assets"); }
           
            db.Entry(record).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IQueryable<ProductVM> Get()
        {
            var data = db.Product.Select(c => new ProductVM
            {
                id = c.id,
                ProductName = c.ProductName,
                Price = c.Price,
                PhotoName = c.PhotoName,
             
            });
            return data;
        }

        public ProductVM GetById(int id)
        {
            var data = db.Product.Where(a => a.id == id).Select(c => new ProductVM
            {
                id = c.id,
                ProductName = c.ProductName,
                Price = c.Price,
                PhotoName = c.PhotoName,
            }).FirstOrDefault();
            return data;
        }
    }
}
