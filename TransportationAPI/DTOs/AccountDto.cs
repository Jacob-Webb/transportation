using System.ComponentModel.DataAnnotations;
using TransportationAPI.Attributes;

namespace TransportationAPI.DTOs
{
    #pragma warning disable SA1649 // File name should match first type name
    public class AuthenticationDto : PhoneNumberDto
    #pragma warning restore SA1649 // File name should match first type name
    {
        [Required(ErrorMessage = "A password is required")]
        [StringLength(255)]
        [NoMap]
        public string Password { get; set; }
    }

    #pragma warning disable SA1402 // File may only contain a single type
    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }

    public class PhoneNumberDto
    {
        [Required(ErrorMessage = "A phone number is required")]
        [Phone]
        [StringLength(maximumLength: 10, ErrorMessage = "Phone number is too long")]
        public string PhoneNumber { get; set; }
    }

    public class PhoneVerificationDto : PhoneNumberDto
    {
        public string Code { get; set; }
    }

    public class RegisterUserDto : AuthenticationDto
    {
        [Required(ErrorMessage = "A first name is required")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "A last name is required")]
        [StringLength(50)]
        public string LastName { get; set; }

        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "An address is required")]
        [StringLength(60)]
        public string Address1 { get; set; }

        [StringLength(60)]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "A city is required")]
        [StringLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "A zip code is required")]
        [StringLength(11)]
        public string ZipCode { get; set; }
    }

    public class ResetPasswordDto : AuthenticationDto
    {
        public string Token { get; set; }
    }
    #pragma warning restore SA1402 // File may only contain a single type
}
