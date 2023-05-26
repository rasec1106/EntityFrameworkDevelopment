using Test_Practice02_01.Models;

namespace Test_Practice02_01.Repository
{
    public interface IShipRepository
    {
        public Task<bool> createShipDocument(ShipDocument shipDocument);
    }
}
