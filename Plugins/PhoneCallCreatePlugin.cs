using Microsoft.Xrm.Sdk;
using SummitEmea.Shared.Commands.PhoneCallHistoryCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypedEntities;

namespace SummitEmea.Plugins
{
    public class PhoneCallCreatePlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            #region Boilerplate
            // Obtain the execution context from the service provider.
            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));

            // Obtain the organization service reference.
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
            #endregion

            if (context.InputParameters.Contains("Target") &&
                context.InputParameters["Target"] is Entity)
            {
                var target = context.InputParameters["Target"] as Entity;
                var phoneCall = target.ToEntity<PhoneCall>();

                var contact = phoneCall.RegardingObjectId;
                var phoneNumber = phoneCall.PhoneNumber;

                var cmd = new PhoneCallCreateHistoryCommand()
                {
                    PhoneCall = phoneCall
                };

                var result = cmd.Execute(service);
                
            }
        }
    }
}
