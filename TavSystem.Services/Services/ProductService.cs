using AutoMapper;
using System;
using System.Collections.Generic;
using TavSystem.DataLayer.Repositories.Contracts;
using TavSystem.Entities;
using TavSystem.Models;
using TavSystem.Services.Contracts;

namespace TavSystem.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper,IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public IEnumerable<ProductDto> GetAll()
        {
            var result = _mapper.Map<IEnumerable<ProductDto>>(_productRepository.GetAll());

            return result;
        }
        public Response Add(ProductDto addproduct)
        {
            Response response = new Response();
            try
            {
                var model = _mapper.Map<Product>(addproduct);
                var product = _productRepository.GetByInfo(model);
                if (product is null)
                {
                    _productRepository.Add(model);
                    response.Message = "ثبت با موفقیت انجام شد"; 
                }
                else
                {
                    response.IsSuccess = false;
                    response.Errors = new Error("", "اطلاعات کالا تکراری می باشد");
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Errors = new Error("", "خطا در ثبت اطلاعات");
            } 
            return response;
        }
    }
}
