using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
  public class VoyageRepository : IVoyageRepository
  {
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public VoyageRepository(DataContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public async Task<Voyage> GetVoyageAsync(int id)
    {
      return await _context.Voyages.FindAsync(id);
    }

    public async Task<PagedList<VoyageDto>> GetVoyagesAsync(UserParams userParams)
    {
      var voyageQuery = _context.Voyages.AsQueryable();
      voyageQuery = voyageQuery.OrderByDescending(p => p.Created);

      return await PagedList<VoyageDto>.CreateAsync(voyageQuery.ProjectTo<VoyageDto>(_mapper.ConfigurationProvider).AsNoTracking(), userParams.PageNumber, userParams.
      PageSize);
    }
  }
}
