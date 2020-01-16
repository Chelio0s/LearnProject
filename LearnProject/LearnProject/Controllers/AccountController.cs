using System;
using System.Text;
using System.Threading.Tasks;
using LearnProject.Areas.Identity.Pages.Account;
using LearnProject.Data.BlogData;
using LearnProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace LearnProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender _emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            this._emailSender = _emailSender;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                ErrorViewModel error = new ErrorViewModel()
                {
                    RequestId = "confirmation was unsuccessful"
                };
                return View("Error", error);
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            { 
                ErrorViewModel error = new ErrorViewModel()
                {
                    RequestId = "User not found"
                };
                return View("Error", error);
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            else
            {
                ErrorViewModel error = new ErrorViewModel()
                {
                    RequestId = "Invalid token"
                };
                return View("Error", error);
            }
        }

        public async Task<IActionResult> ConfirmationEmail(string email)
        {
            if (email == null)
            {
                return Content("error");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user==null)
            {
                ErrorViewModel error = new ErrorViewModel()
                {
                    RequestId = "confirmation was unsuccessful"
                };
                return View("Error", error);
            }
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                var callbackUrl = Url.Action(
                    "ConfirmEmail",
                    "Account",
                    new { userId = user.Id, code = code },
                    protocol: HttpContext.Request.Scheme);
                await _emailSender.SendEmailAsync(email, "Confirm your email for Learn Project",
                    $"Please confirm your account by <a href='{callbackUrl}'>clicking here</a>.");
            
        
            return  View("InfoView", new InformationViewModel(){Message = "Email was sent, please check it!", Header = "Confirmation"});
        }
    }
}