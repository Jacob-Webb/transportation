using System;
using System.ComponentModel.DataAnnotations;

namespace TransportationAPI.DTOs
{
    
    public class LoginUserDto
    {
        [Required(ErrorMessage = "A phone number is required")]
        [Phone]
        [StringLength(maximumLength: 12, ErrorMessage = "Phone number is too long")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "A password is required")]
        [StringLength(255)]
        public string Password { get; set; }
    }

    public class RegisterUserDto : LoginUserDto
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
        [StringLength(60)]
        public string Address1 { get; set; }
        [StringLength(60)]
        public string Address2 { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(11)]
        public string ZipCode { get; set; }
        public string Role { get; set; }
    }

    public class PhoneVerificationDto
    {
        public string Code { get; set; }
    }

    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }

}
