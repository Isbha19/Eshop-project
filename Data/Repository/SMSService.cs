using Eshop.Model.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Eshop.Data.Repository
{
    public class SMSService : ISMSSenderService
    {
        private readonly TwilioSettings twilioSettings;

        public SMSService(IOptions<TwilioSettings> twilioSettings)
        {
            this.twilioSettings = twilioSettings.Value;
        }
        public async Task SendSMSAsync(string toPhone, string message)
        {
            TwilioClient.Init(twilioSettings.AccoundSID, twilioSettings.AuthToken);
            await MessageResource.CreateAsync(
                
                to:toPhone,
                from:twilioSettings.FromPhone,
                body:message


                );
        }
    }
}
