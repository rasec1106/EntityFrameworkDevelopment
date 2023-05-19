using System.ComponentModel.DataAnnotations;

namespace ApiCreditCard.Models
{
    public class CreditCard
    {
        [Key]
        public int CardId { get; set; }
        [Required]
        public string? CardNumber { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public string? CVV { get; set; }
    }
}
