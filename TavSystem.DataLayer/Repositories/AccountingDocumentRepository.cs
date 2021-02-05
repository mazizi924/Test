using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TavSystem.DataLayer.Repositories.Contracts;
using TavSystem.Entities;

namespace TavSystem.DataLayer.Repositories
{
    public class AccountingDocumentRepository : Repository<AccountingDocument>, IAccountingDocumentRepository
    {
        public AccountingDocumentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public AccountingDocument GetByInvitemId(long invitemId)
        {
            return TableNoTracking.Where(x => x.InvitemId == invitemId).FirstOrDefault();
        }

        public string GetMaxdocNo()
        {
            return TableNoTracking.Max(x=>x.DocNo);
        }
    }
}
