using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TransportationAPI.Helpers;
using Twilio.Exceptions;
using Twilio.Rest.Lookups.V1;

namespace TransportationAPI.Middleware
{
    public class TwilioSettings
    {
        public string VerificationServiceSID { get; set; }

        public static async Task<HttpStatus> FormatPhoneNumber(string numberToFormat)
        {
            try
            {
                var numberDetails = await PhoneNumberResource.FetchAsync(
                    pathPhoneNumber: new Twilio.Types.PhoneNumber(numberToFormat),
                    countryCode: "US",
                    type: new List<string> { "carrier" });
                if (numberDetails?.Carrier != null
                    && numberDetails.Carrier.TryGetValue("type", out var phoneNumberType)
                    && phoneNumberType == "landline")
                {
                    return new HttpStatus
                    {
                        Code = HttpStatusCode.NotAcceptable,
                        Response = $"The number you entered does not appear to be capable of receiving SMS ({phoneNumberType}). Please enter a different number and try again",
                    };
                }

                return new HttpStatus
                {
                    Code = HttpStatusCode.Accepted,
                    Response = numberDetails?.PhoneNumber.ToString(),
                };
            }
            catch (ApiException ex)
            {
                return new HttpStatus
                {
                    Code = HttpStatusCode.NotAcceptable,
                    Response = $"The number you entered was not valid (Twilio code {ex.Code}), please check it and try again",
                };
            }
        }
    }
}
