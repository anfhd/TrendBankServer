using System.ComponentModel.DataAnnotations;

namespace TrendBankServer.Models.DataTransferObjects
{
    public class CardForCreationDto
    {
        [Required(ErrorMessage = "Card number is a required field.")]
        [StringLength(16, ErrorMessage = "Length for the number is 16 characters.")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Expiration date is a required field.")]
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "CVV is a required field.")]
        [StringLength(3, ErrorMessage = "Length for the CVV is 3 characters.")]
        public string CVV { get; set; }

        [Required(ErrorMessage = "Balance is a required field.")]
        public double Balance { get; set; }
    }
}
