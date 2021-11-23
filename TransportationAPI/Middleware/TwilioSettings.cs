using System;
using Twilio.Rest.Lookups.V1;

namespace TransportationAPI.Middleware
{
    public class TwilioSettings
    {
        public string VerificationServiceSID { get; set; }

        public static string FormatPhoneNumber(string numberToFormat)
        {
            var phoneNumber = PhoneNumberResource.Fetch(
                    countryCode: "US",
                    pathPhoneNumber: new Twilio.Types.PhoneNumber(numberToFormat)
                );

            return phoneNumber.PhoneNumber.ToString();
        }
    }
}
