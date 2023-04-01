using WebApplication6.Models;

namespace WebApplication6.BL.Interfaces
{
    public interface IProduct
    {

        IQueryable<ProductVM> Get();
        ProductVM GetById(int id);
        void Add(ProductVM prod);
        void Edit(ProductVM prod);
        void Delete(int id);
    }
}
