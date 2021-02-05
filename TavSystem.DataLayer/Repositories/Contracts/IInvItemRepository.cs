using System.Collections.Generic;
using TavSystem.Entities;
using TavSystem.Models;

namespace TavSystem.DataLayer.Repositories.Contracts
{
    public interface IInvitemRepository : IRepository<Invitem>
    {
        Invitem GetByCode(string code);
        new object Add(Invitem model);
        void AddInvitemDetails(InvitemDetail model);
        long CalculateSumPrice(long invitemId);
        void AddAccountingDo(AccountingDocument model);
    }
}
