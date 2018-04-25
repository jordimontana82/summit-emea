using Microsoft.Xrm.Sdk;
using SummitEmea.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SummitEmea.Shared.Commands
{
    public interface IXrmCommand
    {
        GenericResult Execute(IOrganizationService service);
    }
}
