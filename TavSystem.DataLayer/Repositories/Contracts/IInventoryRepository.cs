using System.Collections.Generic;
using TavSystem.Entities;
using TavSystem.Models;

namespace TavSystem.DataLayer.Repositories.Contracts
{
    public interface IInventoryRepository : IRepository<Delivery>
    {
        new Response<IEnumerable<InventoryInfoDto>> GetAll(int pageNumber, int pageSize);
        int GetInventory(long ProductId);
    }
}
