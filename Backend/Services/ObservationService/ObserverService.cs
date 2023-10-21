using Backend.Data;
using Backend.Models.Accounts;
using Backend.Models.Exceptions;
using Backend.Models.Observers;
using Backend.Services.AccountServices;
using Common.Models.Error.Api;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.ObserverServices
{
    public class ObserverService : IObserverService
    {
        private readonly DataContext _dataContext;
        private readonly IAccountService _accountService;

        public ObserverService(DataContext dataContext, IAccountService accountService)
        {
            _dataContext = dataContext;
            _accountService = accountService;
        }

        public async Task<List<Observer>> GetObservers(int accountId)
        {
            Account account = await _accountService.GetAccountIncludeObservers(accountId);
            return account.Observers;
        }

        public async Task<Observer?> GetObserver(int accountId, long id)
        {
            Account account = await _accountService.GetAccountIncludeObservers(accountId);
            return account.Observers.Find(observer => id == observer.Id);
        }

        public async Task<Observer> CreateObserver(int accountId, Observer observer)
        {
            Account account = await _accountService.GetAccountIncludeObservers(accountId);
            account.Observers.Add(observer);
            await _dataContext.SaveChangesAsync();

            return observer;
        }

        public async Task<Observer> UpdateObserver(int accountId, long id, Observer observer)
        {
            if (id != observer.Id)
            {
                throw new ApiException(new ResourceDoesNotExist());
            }
            Observer current = (await GetObserver(accountId, id)) ?? throw new ApiException(new ResourceDoesNotExist());
            _dataContext.Entry(current).CurrentValues.SetValues(observer);
            await _dataContext.SaveChangesAsync();

            return current;
        }

        public async Task<bool> DeleteObserver(int accountId, long id)
        {
            Observer? current = (await GetObserver(accountId, id));
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
