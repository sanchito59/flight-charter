using System.Threading.Tasks;

namespace API.Interfaces
{
  public interface IUnitOfWork
  {
    IUserRepository UserRepository { get; }
    IVoyageRepository VoyageRepository { get; }
    Task<bool> Complete();
    bool HasChanges();
  }
}
