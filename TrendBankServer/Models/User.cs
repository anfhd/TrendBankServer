using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace TrendBankServer.Models
{
    public class User
    {
        [Column("UserId")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "First name is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the first name is 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the last name is 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is a required field.")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Phone number is a required field.")]
        [StringLength(9, ErrorMessage = "Length for the phone number is 9 characters.")]
        public string PhoneNumber { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum length for the email is 50 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Postal code is a required field.")]
        [StringLength(5, ErrorMessage = "Length for the postal code is 5 characters.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Password is a required field.")]
        [MinLength(4, ErrorMessage = "Length for the password is 4 characters.")]
        public string Password { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}