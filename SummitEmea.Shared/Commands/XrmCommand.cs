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
            try
            {
                return ConcreteExecute(service); 
            }
            catch (Exception e)
            {
                return new GenericResult()
                {
                    Succeeded = false,
                    ErrorMessage = e.ToString()
                };
            }
        }


        protected virtual GenericResult ConcreteExecute(IOrganizationService service)
        {
            throw new NotImplementedException();
        }

    }
}
