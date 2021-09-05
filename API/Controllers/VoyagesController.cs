using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class VoyagesController : BaseApiController
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public VoyagesController(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _mapper = mapper;
      _unitOfWork = unitOfWork;
    }

    // GET all voyages - api/voyages
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VoyageDto>>> GetVoyages([FromQuery] UserParams userParams)
    {
      var voyages = await _unitOfWork.VoyageRepository.GetVoyagesAsync(userParams);

      Response.AddPaginationHeader(voyages.CurrentPage, voyages.PageSize, voyages.TotalCount, voyages.TotalPages);

      return Ok(voyages);
    }

    // GET user - api/voyages/:id
    [HttpGet("{id}", Name = "GetVoyage")]
    public async Task<ActionResult<Voyage>> GetVoyage(int id)
    {
      return await _unitOfWork.VoyageRepository.GetVoyageAsync(id);
    }
  }
}
