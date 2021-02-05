using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TavSystem.DataLayer.Repositories.Contracts;
using TavSystem.Entities;
using TavSystem.Models;

namespace TavSystem.DataLayer.Repositories
{

    public class ProductRepository :Repository<Product>, IProductRepository
    {
        public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Product GetByInfo(Product product)
        {
            return TableNoTracking.Where(x => (x.ProductCode == product.ProductCode) || (x.CategoryId == product.CategoryId && x.Name == product.Name)).FirstOrDefault();
        } 
        public IEnumerable<Product> GetByCategoryID(int CategoryId)
        {
            return Table.Where(x => x.CategoryId == CategoryId);
        }
    }
}
