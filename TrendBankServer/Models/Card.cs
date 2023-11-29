using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace TrendBankServer.Models
{
    public class Card
    {
        [Column("CardId")]
        public Guid Id { get; set; }

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

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }

        public ICollection<Transaction> TransactionsTo { get; set; }
        public ICollection<Transaction>? TransactionsFrom { get; set; }
    }
}