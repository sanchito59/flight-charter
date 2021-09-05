using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Authorize] // TODO: Assess if this should be protected
  public class UsersController : BaseApiController
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _mapper = mapper;
      _unitOfWork = unitOfWork;
    }

    // GET all users - api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
      var users = await _unitOfWork.UserRepository.GetUsersAsync();

      return Ok(users);
    }

    // GET user - api/users/:id
    [HttpGet("{username}", Name = "GetUser")]
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
      return await _unitOfWork.UserRepository.GetMemberAsync(username);
    }

    // PUT user - api/users
    // [HttpPut]
    // public async Task<ActionResult<MemberDto>> UpdateUser(MemberUpdateDto memberUpdateDto)
    // {
    //   var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());

    //   _mapper.Map(memberUpdateDto, user);
    //   _unitOfWork.UserRepository.Update(user);

    //   if (await _unitOfWork.Complete()) return NoContent();

    //   return BadRequest("Failed to update user");
    // }
  }
}
