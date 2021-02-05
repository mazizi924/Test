using System.Collections.Generic;
using TavSystem.Entities;
using TavSystem.Models;

namespace TavSystem.DataLayer.Repositories.Contracts
{
    public interface IAccountingDocumentRepository :IRepository<AccountingDocument>
    {
        AccountingDocument GetByInvitemId(long invitemId);
        string GetMaxdocNo();
    }
}
