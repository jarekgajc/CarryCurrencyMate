using Backend.Models.Observers;

namespace Backend.Services.ObserverServices
{
    public interface IObserverService
    {
        Task<Observer> CreateObserver(int accountId, Observer observer);
        Task<bool> DeleteObserver(int accountId, long id);
        Task<List<Observer>> GetObservers(int accountId);
        Task<Observer> UpdateObserver(int accountId, long id, Observer observer);
    }
}