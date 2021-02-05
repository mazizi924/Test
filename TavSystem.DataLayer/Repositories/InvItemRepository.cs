using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TavSystem.DataLayer.Repositories.Contracts;
using TavSystem.Entities;

namespace TavSystem.DataLayer.Repositories
{
      
    public class InvitemRepository : Repository<Invitem>, IInvitemRepository
    {
        private readonly IAccountingDocumentRepository _accountingDoc;
        private DbSet<InvitemDetail> _invitemDetails;
        public InvitemRepository(IUnitOfWork unitOfWork, IAccountingDocumentRepository accountingDoc) : base(unitOfWork)
        {
            _invitemDetails = unitOfWork.Set<InvitemDetail>();
            _accountingDoc = accountingDoc;
        } 
        public new object Add(Invitem model)
        {
            Entities.Add(model);
            UnitOfWork.SaveChanges();
            return model.Id;
        }
        public void AddInvitemDetails(InvitemDetail model)
        {
            _invitemDetails.Add(model);
            UnitOfWork.SaveChanges();
        }
        public long CalculateSumPrice(long invitemId)
        {
           return _invitemDetails.Where(x=>x.InvitemId== invitemId).Sum(x=>x.Price);
        }  
        public void AddAccountingDo(AccountingDocument model)
        {
            _accountingDoc.Add(model); 
        }

        public Invitem GetByCode(string code)
        {
            return TableNoTracking.Where(x => x.InvitemNo == code).FirstOrDefault();
        }
    }
}
