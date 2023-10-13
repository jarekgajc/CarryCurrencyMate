using Backend.Data;
using Backend.Models.Exceptions;
using Common.Models.Observers;
using Common.Models.Error.Api;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.ObserverServices
{
    public class ObserverService : IObserverService
    {
        private readonly DataContext _dataContext;

        public ObserverService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Observer>> GetObservers()
        {
            return await _dataContext.Observers.ToListAsync();
        }

        public async Task<Observer?> GetObserver(long id)
        {
            return await _dataContext.Observers.FindAsync(id);
        }

        public async Task<Observer> CreateObserver(Observer observer)
        {
            _dataContext.Observers.Add(observer);
            await _dataContext.SaveChangesAsync();

            return observer;
        }

        public async Task<Observer> UpdateObserver(long id, Observer observer)
        {
            if (id != observer.Id)
            {
                throw new ApiException(new ResourceDoesNotExist());
            }
            var current = await _dataContext.Observers.FindAsync(id) ?? throw new ApiException(new ResourceDoesNotExist());
            await _dataContext.SaveChangesAsync();

            return current;
        }

        public async Task<bool> DeleteObserver(long id)
        {
            var current = await _dataContext.Observers.FindAsync(id);
            if (current == null)
            {
                return false;
            }

            _dataContext.Observers.Remove(current);
            await _dataContext.SaveChangesAsync();

            return true;
        }

    }
}
