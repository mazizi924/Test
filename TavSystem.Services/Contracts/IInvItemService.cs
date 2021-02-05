using System;
using System.Collections.Generic;
using System.Text;
using TavSystem.Entities;
using TavSystem.Models;

namespace TavSystem.Services.Contracts
{
    public interface IInvItemService
    { 
        Response Add(InvitemInfoDto invitemInfo);
    }
}
