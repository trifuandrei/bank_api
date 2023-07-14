using Bank.Entities;

namespace Bank.Interfaces
{
    public interface ICoinRepository
    {
        void CreateCoin(Coin coin);
        Coin GetCoinById(int id);
        //GetAll
        List<Coin> GetAll();
        //GetByName
        Coin GetCoinByName(string name);
        //Edit
        Coin Edit(Coin coin);
        //Delete
        void Delete(int id);

    }
}
