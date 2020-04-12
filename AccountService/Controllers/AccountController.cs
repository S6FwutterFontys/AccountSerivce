using System.Threading.Tasks;
using AccountService.Domain;
using AccountService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateAccount(Account account)
        {
            await _accountService.CreateAccount(account);
            return Ok(account);
        }
        
        [AllowAnonymous]
        [HttpPost("get")]
        public async Task<IActionResult> GetAccount(Account account)
        {
            var acc = await _accountService.GetAccount(account.Email);
            return Ok(acc);
        }

        [AllowAnonymous]
        [HttpPost("update")]
        public async Task<IActionResult> UpdateAccount(Account account)
        {
            await _accountService.UpdateAccount(account.Email, account);
            return Ok(GetAccount(account));
        }
        [AllowAnonymous]
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAccount([FromBody] string email)
        {
            await _accountService.DeleteAccount(email);
            return Ok();
        }
    }
}