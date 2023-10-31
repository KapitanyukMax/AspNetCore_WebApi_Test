using System.Net;
using Microsoft.AspNetCore.Identity;
using BusinessLogic.ApiModels.Accounts;
using BusinessLogic.Interfaces;
using BusinessLogic.Exceptions;
using DataAccess.Entities;

namespace BusinessLogic.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountsService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task RegisterAsync(RegisterRequest model)
        {
            var user = new User()
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Birthdate = model.Birthdate
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var message = string.Join(", ", result.Errors.Select(x => x.Description));

                throw new HttpException(message, HttpStatusCode.BadRequest);
            }
        }

        public async Task LoginAsync(LoginRequest model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                throw new HttpException("Invalid login or password!", HttpStatusCode.BadRequest);

            await _signInManager.SignInAsync(user, true);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
