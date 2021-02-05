using AutoMapper; 
using TavSystem.Services.Contracts;
using TavSystem.DataLayer.Repositories.Contracts;
using TavSystem.Entities;
using TavSystem.Models;
using System.Collections.Generic;
using System;

namespace TavSystem.Services.Services
{
    public class InventoryService: IInventoryService
    {
        private readonly IMapper _mapper;
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IMapper mapper, IInventoryRepository inventoryRepository)
        {
            _mapper = mapper;
            _inventoryRepository = inventoryRepository;
        }
        public Response Add(DeliveryDto deliveryDto)
        {
            Response response = new Response();
            try
            {
                var model = _mapper.Map<Delivery>(deliveryDto); 
                _inventoryRepository.Add(model);
                response.Message = "ثبت با موفقیت انجام شد";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Errors = new Error("", "خطا در ثبت اطلاعات");
            }
            return response; 
        }

        public Response<IEnumerable<InventoryInfoDto>> GetAll(int pageNumber, int pageSize)
        {
            var result= _inventoryRepository.GetAll(pageNumber, pageSize); 
            return result;
        }
    }
}
