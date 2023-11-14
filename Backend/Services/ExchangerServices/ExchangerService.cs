using Backend.Data;
using Backend.Models.Accounts;
using Backend.Models.Exceptions;
using Backend.Models.Exchangers;
using Backend.Services.AccountServices;
using Common.Models.Error.Api;

namespace Backend.Services.ExchangerServices
{
    public class ExchangerService : IExchangerService
    {
        private readonly DataContext _dataContext;
        private readonly IAccountService _accountService;

        public ExchangerService(DataContext dataContext, IAccountService accountService)
        {
            _dataContext = dataContext;
            _accountService = accountService;
        }

        public async Task<List<Exchanger>> GetExchangers(int accountId)
        {
            Account account = await _accountService.GetAccountIncludeExchangers(accountId);
            return account.Exchangers;
        }

        public async Task<Exchanger?> GetExchanger(int accountId, long id)
        {
            Account account = await _accountService.GetAccountIncludeExchangers(accountId);
            return account.Exchangers.Find(exchanger => id == exchanger.Id);
        }

        public async Task<Exchanger> CreateExchanger(int accountId, Exchanger exchanger)
        {
            Account account = await _accountService.GetAccountIncludeExchangers(accountId);
            account.Exchangers.Add(exchanger);
            await _dataContext.SaveChangesAsync();

            return exchanger;
        }

        public async Task<Exchanger> UpdateExchanger(int accountId, long id, Exchanger exchanger)
        {
            if (id != exchanger.Id)
            {
                throw new ApiException(new ResourceDoesNotExist());
            }

            Exchanger current = (await GetExchanger(accountId, id)) ?? throw new ApiException(new ResourceDoesNotExist());
            
            if (current.SourceAuth.Id != exchanger.SourceAuth.Id)
            {
                throw new ApiException(new ResourceDoesNotExist());
            }

            current.Update(exchanger);
            await _dataContext.SaveChangesAsync();

            return current;
        }

        public async Task<bool> DeleteExchanger(int accountId, long id)
        {
            Exchanger? current = (await GetExchanger(accountId, id));
            if (current == null)
            {
                return false;
            }

            _dataContext.Exchangers.Remove(current);
            await _dataContext.SaveChangesAsync();

            return true;
        }

    }
}
