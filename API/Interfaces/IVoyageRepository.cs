using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
  public interface IVoyageRepository
  {
    Task<VoyageDto> GetVoyagesAsync();
    Task<Voyage> GetVoyageAsync();
  }
}
