using Microsoft.AspNetCore.Mvc;
using StarWars.Interfaces.UserInterfaces;
using StarWars.Models;
using StarWars.ViewModels;
using StarWars.ViewModels.UserViewModel;

namespace StarWars.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly UserManager _userManager;

    [HttpGet("v1/user/")]
    public async Task<IActionResult> GetAllAsync()
    {
        var users = await _userManager.GetAll();

        if (users == null)
            return NotFound(new ResultViewModel<User>("It looks like we couldn't find any users in our registry."));

        return Ok(new ResultViewModel<IEnumerable<User>>(users));
    }


    [HttpGet("v1/user/{id:int}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] int id)
    {
        var user = await _userManager.GetById(id);

        if (user == null)
            return NotFound(new ResultViewModel<User>("It looks like we couldn't find any user in our registry."));

        return Ok(new ResultViewModel<User>(user));
    }


    [HttpPut("v1/user/{id:int}")]
    public async Task<IActionResult> PutAsync(
        [FromRoute] int id,
        [FromBody] RegisterViewModel model)
    {
        var user = await _userManager.GetById(id);

        if (user == null)
            return NotFound(new ResultViewModel<User>("It looks like we couldn't find any user in our registry."));

        user.Name = model.Name;
        user.Email = model.Email;
        user.Patent = model.Patent;

        await _userManager.Update(id, user);

        return Ok(new ResultViewModel<User>(user));
    }


    [HttpDelete("v1/user/{id:int}")]
    public async Task<IActionResult> DeleteAsync(
        [FromRoute] int id)
    {
        await _userManager.Delete(id);
        return Ok(new ResultViewModel<string>("User registration successfully deleted", null));
    }
}