using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xrm.Sdk;
using SummitEmea.Shared.Models;

namespace SummitEmea.Shared.Commands
{
    public class XrmCommandBase : IXrmCommand
    {
        public GenericResult Execute(IOrganizationService service)
        {
            throw new NotImplementedException();
        }
    }
}
