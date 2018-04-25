using Microsoft.Xrm.Sdk;
using SummitEmea.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypedEntities;

namespace SummitEmea.Shared.Commands.PhoneCallHistoryCommands
{
    public class PhoneCallCreateHistoryCommand : XrmCommandBase
    {
        public PhoneCall PhoneCall { get; set; }

        protected override GenericResult ConcreteExecute(IOrganizationService service)
        {

                var contact = PhoneCall.RegardingObjectId;
                var phoneNumber = PhoneCall.PhoneNumber;

                //query to create a phone history only if the pair [phonenumber, contact] doesn't exist
                using (var ctx = new XrmServiceContext(service))
                {
                    var exists = (from ph in ctx.CreateQuery<ultra_phonecallhistory>()
                                  where ph.ultra_contactid.Id == contact.Id
                                  where ph.ultra_phonenumber == phoneNumber
                                  select ph).FirstOrDefault() != null;

                    if(!exists)
                    {
                        //Create phone history record
                        var phoneHistory = new ultra_phonecallhistory()
                        {
                            ultra_contactid = contact,
                            ultra_phonenumber = phoneNumber,
                            ultra_lastcalldate = DateTime.Now
                        };
                        phoneHistory.Id = service.Create(phoneHistory);

                    //Phonecall then assigned to the created phonecall history
                    PhoneCall.ultra_phonecallhistoryid = phoneHistory.ToEntityReference();

                    }
                    
                }

            return GenericResult.Succeed();
                    
        }
        
    }
}
