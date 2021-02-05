using System;
using System.Collections.Generic;
using System.Text;
using TavSystem.Models;

namespace TavSystem.Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAll();
        Response Add(ProductDto addproduct);
    }
}
