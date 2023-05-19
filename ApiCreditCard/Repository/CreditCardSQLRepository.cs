using ApiCreditCard.DbContexts;
using ApiCreditCard.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCreditCard.Repository
{
    public class CreditCardSQLRepository : ICreditCardRepository
    {
        private AppDbContext dbContext;

        public CreditCardSQLRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<CreditCard> CreateCreditCard(CreditCard creditCard)
        {
            this.dbContext.CreditCards.Add(creditCard);
            await this.dbContext.SaveChangesAsync();
            return creditCard;
        }

        public async Task<bool> DeleteCreditCard(int id)
        {
            var result = await this.dbContext.CreditCards.FirstOrDefaultAsync(card => card.CardId == id);
            if (result != null)
            {
                this.dbContext.CreditCards.Remove(result);
                await this.dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<CreditCard> GetCreditCardById(int id)
        {
            return await this.dbContext.CreditCards.Where(card => card.CardId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CreditCard>> GetCreditCards()
        {
            return await this.dbContext.CreditCards.ToListAsync();
        }

        public async Task<CreditCard> UpdateCreditCard(CreditCard creditCard)
        {
            this.dbContext.CreditCards.Update(creditCard);
            await this.dbContext.SaveChangesAsync();
            return creditCard;
        }
    }
}
