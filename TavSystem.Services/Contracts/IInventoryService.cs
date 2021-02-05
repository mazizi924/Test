using System;
using System.Collections.Generic;
using System.Text;
using TavSystem.Models;

namespace TavSystem.Services.Contracts
{
    public interface IInventoryService
    {
        Response<IEnumerable<InventoryInfoDto>> GetAll(int pageNumber, int pageSize);
        Response Add(DeliveryDto addDelivery);

    }
}
