using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Authorize]
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

    [HttpPost("add-voyage")]
    public async Task<ActionResult<VoyageDto>> AddVoyage(CreateVoyageDto createVoyageDto)
    {
      var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());

      var voyage = new Voyage
      {
        Title = createVoyageDto.Title,
        TotalMileage = createVoyageDto.TotalMileage,
        StartDate = createVoyageDto.StartDate,
        EndDate = createVoyageDto.EndDate,
        Flights = createVoyageDto.Flights,
        PlanesUsed = createVoyageDto.PlanesUsed
      };

      user.Voyages.Add(voyage);

      if (await _unitOfWork.Complete())
      {
        // return CreatedAtRoute("/", new { username = user.UserName }, _mapper.Map<VoyageDto>(voyage)); // TODO: Need Angular client for this
        return _mapper.Map<VoyageDto>(voyage);
      }

      return BadRequest("Problem saving voyage");
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
