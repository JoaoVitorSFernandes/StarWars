using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecureIdentity.Password;
using StarWars.Extensions;
using StarWars.Interfaces.UserInterfaces;
using StarWars.Models;
using StarWars.Services;
using StarWars.ViewModels;
using StarWars.ViewModels.UserViewModel;

namespace StarWars.Controllers;

[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager _userManager;


    [HttpPost("v1/accounts/signin")]
    public async Task<IActionResult> SignIn(
        [FromBody] LoginViewModel model,
        [FromServices] TokenService tokenService
    )
    {
        var user = await _userManager.SignIn(model.Email);

        if (!model.IsValid(user))
            return NotFound(new ResultViewModel<string>("Email ou Password invalid.", null));

        var token = tokenService.GenerateToken(user);

        return Ok(new ResultViewModel<string>(token, null));
    }

    [HttpPost("v1/accounts/signup")]
    public async Task<IActionResult> SignUp(
        [FromBody] RegisterViewModel model,
        [FromServices] EmailService emailService)
    {
        var user = new User(
            model.Name,
            model.Email,
            model.Patent
        );

        var password = PasswordGenerator.Generate(25);
        user.Password = PasswordHasher.Hash(password);

        emailService.SendEmailSmtpGmail(user.Name,
                                        user.Email,
                                        "Acesso a plataforma",
                                        $"A seguir a senha de acesso a plataforma {password}");

        await _userManager.Insert(user);

        return Created($"v1/user/{user.Id}", new ResultViewModel<dynamic>(new
        {
            user.Email,
            password
        }));
    }
}