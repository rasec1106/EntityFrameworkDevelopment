using ApiCreditCard.Models;

namespace ApiCreditCard.Repository
{
    public interface ICreditCardRepository
    {
        public Task<IEnumerable<CreditCard>> GetCreditCards();
        public Task<CreditCard> GetCreditCardById(int id);
        public Task<CreditCard> CreateCreditCard(CreditCard creditCard);
        public Task<CreditCard> UpdateCreditCard(CreditCard creditCard);
        public Task<bool> DeleteCreditCard(int id);
    }
}
