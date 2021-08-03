using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;

namespace API.Data
{
  public class VoyageRepository : IVoyageRepository
  {
    public Task<Voyage> GetVoyageAsync()
    {
      throw new System.NotImplementedException();
    }

    public Task<VoyageDto> GetVoyagesAsync()
    {
      throw new System.NotImplementedException();
    }
  }
}
