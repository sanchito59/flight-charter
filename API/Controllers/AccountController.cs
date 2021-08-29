using System;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  public class AccountController : BaseApiController
  {
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IMapper mapper)
    {
      _mapper = mapper;
      _tokenService = tokenService;
      _signInManager = signInManager;
      _userManager = userManager;
    }

    //  POST - api/account/register
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
      if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");

      var user = _mapper.Map<AppUser>(registerDto);

      user.UserName = registerDto.Username.ToLower();

      var result = await _userManager.CreateAsync(user, registerDto.Password);

      if (!result.Succeeded) return BadRequest(result.Errors);

      var roleResult = await _userManager.AddToRoleAsync(user, "Member");

      if (!result.Succeeded) return BadRequest(result.Errors);

      return new UserDto
      {
        Token = await _tokenService.CreateToken(user),
        Username = user.UserName,
        PhotoUrl = user.PhotoUrl,
        City = user.City,
        State = user.State,
        Country = user.Country,
        HomeAirport = user.HomeAirport,
        FavoritePlane = user.FavoritePlane
      };
    }

    [HttpPost("Login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
      var user = await _userManager.Users.SingleOrDefaultAsync(credentials => credentials.UserName == loginDto.Username.ToLower());

      if (user == null) return Unauthorized("Username doesn't exist");

      var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

      if (!result.Succeeded) return Unauthorized();

      return new UserDto
      {
        Token = await _tokenService.CreateToken(user),
        Username = user.UserName,
        PhotoUrl = user.PhotoUrl,
        City = user.City,
        State = user.State,
        Country = user.Country,
        HomeAirport = user.HomeAirport,
        FavoritePlane = user.FavoritePlane
      };
    }

    private async Task<bool> UserExists(string username)
    {
      return await _userManager.Users.AnyAsync(user => user.UserName == username.ToLower());
    }
  }
}
