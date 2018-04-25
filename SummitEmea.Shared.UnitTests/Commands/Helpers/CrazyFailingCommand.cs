using Microsoft.Xrm.Sdk;
using SummitEmea.Shared.Commands;
using SummitEmea.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummitEmea.Shared.UnitTests.Commands.Helpers
{
    public class CrazyFailingCommand: XrmCommandBase
    {
        protected override GenericResult ConcreteExecute(IOrganizationService service)
        {
            throw new Exception("Crazy exception");
        }
    }
}
