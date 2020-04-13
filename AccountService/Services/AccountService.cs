using System;
using System.Threading.Tasks;
using AccountService.Domain;
using AccountService.Repositories;

namespace AccountService.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            this._repository = repository;
        }

        public async Task CreateAccount(Account account)
        {
            var acc = await _repository.Get(account.Email);
            if (acc != null) return;

            await _repository.Create(new Account()
            {
                Id = Guid.NewGuid(),
                Email = account.Email,
                isDelegate = account.isDelegate,
                isDAppOwner = account.isDAppOwner
            });
        }

        public async Task UpdateAccount(string email, Account account)
        {
            var acc = await GetAccount(email);
            await _repository.Update(acc.Id, account);
        }

        public async Task AddRole(Account account, bool isDelegate, bool isDAppOwner)
        {
            var acc = await GetAccount(account.Email);
            
            acc.isDelegate = account.isDelegate;
            acc.isDAppOwner = account.isDAppOwner;

            await _repository.Update(acc.Id, acc);
        }

        public async Task<Account> GetAccount(string email)
        {
            var acc = await _repository.Get(email);
            return acc;
        }

        public async Task DeleteAccount(string email)
        {
            var acc = await _repository.Get(email);
            await _repository.Remove(acc.Id);
        }
    }
}