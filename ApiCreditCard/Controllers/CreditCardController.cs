using ApiCreditCard.Models;
using ApiCreditCard.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiCreditCard.Controllers
{
    [ApiController]
    [Route("/api/creditCard")]
    public class CreditCardController
    {
        private ICreditCardRepository creditCardRepository;

        public CreditCardController(ICreditCardRepository creditCardRepository)
        {
            this.creditCardRepository = creditCardRepository;
        }

        [Route("/GetCreditCards")]
        [HttpGet]
        public async Task<IEnumerable<CreditCard>> GetCreditCards()
        {
            return await creditCardRepository.GetCreditCards();
        }

        [Route("/GetCreditCardById/{id}")]
        [HttpGet]
        public async Task<CreditCard> GetCreditCardById(int id)
        {
            return await creditCardRepository.GetCreditCardById(id);
        }

        [Route("/CreateCreditCard")]
        [HttpPost]
        public async Task<CreditCard> CreateCreditCard(CreditCard creditCard)
        {
            return await creditCardRepository.CreateCreditCard(creditCard);
        }

        [Route("/UpdateCreditCard")]
        [HttpPut]
        public async Task<CreditCard> UpdateCreditCard(CreditCard creditCard)
        {
            return await creditCardRepository.UpdateCreditCard(creditCard);
        }

        [Route("/DeleteCreditCard")]
        [HttpDelete]
        public async Task<bool> DeleteCreditCard(int id)
        {
            return await creditCardRepository.DeleteCreditCard(id);
        }
    }
}
