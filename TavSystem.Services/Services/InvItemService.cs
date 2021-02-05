using AutoMapper;
using TavSystem.Services.Contracts;
using TavSystem.DataLayer.Repositories.Contracts;
using TavSystem.Entities;
using TavSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TavSystem.Services.Services
{
    public class InvItemService : IInvItemService
    {
        private readonly IMapper _mapper;
        private readonly IInvitemRepository _invitemRepository;
        private readonly IAccountingDocumentRepository _accountingDocument;
        private readonly IInventoryRepository _inventory;

        public InvItemService(IMapper mapper, IInvitemRepository invitemRepository, IAccountingDocumentRepository accountingDocument, IInventoryRepository inventory)
        {
            _mapper = mapper;
            _invitemRepository = invitemRepository;
            _accountingDocument = accountingDocument;
            _inventory = inventory;
        }

        public Response Add(InvitemInfoDto invitemInfo)
        {
            Response response = new Response();
            try
            {
                var inventory = _inventory.GetInventory(invitemInfo.ProductId);
                if (inventory - invitemInfo.Count >= 0)
                {
                    AddInvitem(invitemInfo);
                    response.Message = "ثبت با موفقیت انجام شد";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Errors = new Error("", "موجودی ناکافی");
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Errors = new Error("", "خطا در ثبت اطلاعات");
            }
            return response;
        }

        private void AddInvitem(InvitemInfoDto invitemInfo)
        {
            long invitmId = _invitemRepository.GetByCode(invitemInfo.InvitemNo)?.Id ?? 0;
            if (invitmId == 0)
            {
                var model = _mapper.Map<Invitem>(new InvitemDto
                { InvitemNo = invitemInfo.InvitemNo, InvitemDate = invitemInfo.InvitemDate, CustomerId = invitemInfo.CustomerId });
                invitmId = (long)_invitemRepository.Add(model);
            }
            if (invitmId > 0)
            {
                var detailmodel = _mapper.Map<InvitemDetail>(new InvitemDetailDto
                { Count = invitemInfo.Count, Price = invitemInfo.Price, Date = invitemInfo.InvitemDate, InvitemId = invitmId, ProductId = invitemInfo.ProductId });
                _invitemRepository.AddInvitemDetails(detailmodel);
                AddAccountingDocument(invitemInfo, invitmId);
            }
        }

        private void AddAccountingDocument(InvitemInfoDto invitemInfo, long invitmId)
        {
            var totalprice = _invitemRepository.CalculateSumPrice(invitmId);
            var accountingDoc = _accountingDocument.GetByInvitemId(invitmId) ;
            if (accountingDoc is null)
            {
                var MaxdocNo = _accountingDocument.GetMaxdocNo();
                var docNo =(Convert.ToInt64(MaxdocNo)+1) ;
                 
                var accountingDocument = _mapper.Map<AccountingDocument>(new AccountingDocDto
                { DocNo = docNo.ToString(), Date = DateTime.Now, Price = totalprice, InvitemId = invitmId });
                _accountingDocument.Add(accountingDocument);
            }
            else
            {
                accountingDoc.Price = totalprice;
                _accountingDocument.Update(accountingDoc);
            }
        }

    }
}
