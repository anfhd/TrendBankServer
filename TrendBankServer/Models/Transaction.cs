using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace TrendBankServer.Models
{
    public class Transaction
    {
        [Column("TransactionId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Card))]
        public Guid CardFromId { get; set; }
        public Card CardFrom { get; set; }

        
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Card? CardTo { get; set; }

        [ForeignKey(nameof(Card))]
        public Guid? CardToId { get; set; }

        [Required(ErrorMessage = "Amount is a required field.")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Date is a required field.")]
        public DateTime Date { get; set; }
    }
}
