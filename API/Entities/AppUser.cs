using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
namespace API.Entities
{
  public class AppUser : IdentityUser<int>
  {
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string HomeAirport { get; set; }
    public string FavoritePlane { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime LastActive { get; set; } = DateTime.Now;
    public ICollection<AppUserRole> UserRoles { get; set; }
  }
}
