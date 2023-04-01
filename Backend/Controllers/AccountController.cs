using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System.Text;
using WebApplication6.BL.helper;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ILogger<AccountController> logger;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }


        [HttpPost("registeration")]
        public async Task<IActionResult> Registeration(RegistrationVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = model.Email,
                    Email = model.Email
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return Ok(model);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return Ok(model);
                }
                else
                {

                    ModelState.AddModelError("", "Invalid Username or Password");

                }
            }
            return BadRequest(ModelState);
        }


        [HttpPost("forgetpassword")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    //var encodedToken = Encoding.UTF8.GetBytes(token);
                    //var validToken = WebEncoders.Base64UrlEncode(encodedToken);

                    var passwordResetLink = Url.Action(nameof(ResetPassword), "Account", new { Email = model.Email, Token = token }, Request.Scheme);

                    //MailHelper.sendMail("Password Reset Link", passwordResetLink);
                    logger.Log(LogLevel.Warning, passwordResetLink);

                    return Ok(model);
                }

                return BadRequest(model);

            }
            return BadRequest(model);
        }


        [HttpGet("resetpassword")]
        public async Task<IActionResult> ResetPassword(string Email, string Token)
        {
            if (Email == null || Token == null)
            {
                ModelState.AddModelError("", "Ivalid Data");
            }
            var model = new ResetPasswordVM { Email = Email, Token = Token };
            return Ok(model);
        }
        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);

                    if (result.Succeeded)
                    {
                        return Ok(model);
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return BadRequest(ModelState);
                }

                return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
        }

    }
}
