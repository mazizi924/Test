using System.Collections.Generic;
using TavSystem.Entities;
using TavSystem.Models;

namespace TavSystem.DataLayer.Repositories.Contracts
{
    public interface IProductRepository : IRepository<Product>
    { 
        Product GetByInfo(Product product); 
        IEnumerable<Product> GetByCategoryID(int CategoryId);
    }
}
