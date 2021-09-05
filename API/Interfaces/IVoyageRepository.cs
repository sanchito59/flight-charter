using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
  public interface IVoyageRepository
  {
    Task<PagedList<VoyageDto>> GetVoyagesAsync(UserParams userParams);
    Task<Voyage> GetVoyageAsync(int id);
  }
}
