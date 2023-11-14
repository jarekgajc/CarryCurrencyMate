using Backend.Models.Exchangers;

namespace Backend.Services.ExchangerServices
{
    public interface IExchangerService
    {
        Task<Exchanger> CreateExchanger(int accountId, Exchanger exchanger);
        Task<bool> DeleteExchanger(int accountId, long id);
        Task<List<Exchanger>> GetExchangers(int accountId);
        Task<Exchanger> UpdateExchanger(int accountId, long id, Exchanger exchanger);
    }
}