using System.Threading.Tasks;
using AccountService.Domain;

namespace AccountService.Services
{
    public interface IAccountService
    {
        Task CreateAccount(Account account);
        Task UpdateAccount(string email, Account account);
        Task AddRole(Account account, bool isDelegate, bool isDAppOwner);
        Task<Account> GetAccount(string email);
        Task DeleteAccount(string email);
    }
}