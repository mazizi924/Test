using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TavSystem.DataLayer.Repositories.Contracts;
using TavSystem.Entities;
using TavSystem.Models;

namespace TavSystem.DataLayer.Repositories
{
    public class InventoryRepository : Repository<Delivery>, IInventoryRepository
    {
        private readonly IInvitemRepository _invitemRepository;
        private readonly IProductRepository _productRepository;
        private DbSet<Invitem> _invitems;
        private DbSet<InvitemDetail> _invitemDetails;
        private DbSet<Product> _products;
        private DbSet<Delivery> _deliveries;

        public InventoryRepository(IUnitOfWork unitOfWork, IInvitemRepository invitemRepository, IProductRepository productRepository) : base(unitOfWork)
        {
            _invitems = unitOfWork.Set<Invitem>();
            _invitemDetails = unitOfWork.Set<InvitemDetail>();
            _products = unitOfWork.Set<Product>();
            _deliveries = unitOfWork.Set<Delivery>();
            _invitemRepository = invitemRepository;
            _productRepository = productRepository;
        }


        public new Response<IEnumerable<InventoryInfoDto>> GetAll(int pageNumber, int pageSize)
        {
            Response response = new Response();
            var queryResult = _products.Select(x => new InventoryInfoDto
            {
                Name = x.Name,
                ProductCode = x.ProductCode,
                MinInventory = x.MinInventory,
                CategoryName = x.Category.Name,
                //Inventory = x.Deliveries.Sum(d => d.Count) - x.invitemDetails.Sum(i => i.Count)
                dlv = x.Deliveries.Sum(d => d.Count),
                inv = x.invitemDetails.Sum(i => i.Count)
            });
            
            var total = queryResult.Count();
            var result = queryResult.Skip(pageSize * (pageNumber-1)).Take(pageSize).ToList() ;
             
            return new Response<IEnumerable<InventoryInfoDto>>()
            {
                Data=  result  ,
                Paging=new Paging() { PageNumber=pageNumber,PageSize=pageSize,Total=total},
            }; 
        }

        public int GetInventory(long ProductId)
        { 
            var result =_products.Where(x => x.Id == ProductId).Select(x =>new {dlv= x.Deliveries.Sum(d => d.Count),inv= x.invitemDetails.Sum(i => i.Count) }).FirstOrDefault();
            return result.dlv-result.inv;
        }
    }
}
