using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace API.Entities
{
  public class AppUser : IdentityUser<int>
  {
    [Required()]
    public string Username { get; set; }

    [Required()]
    public string PhotoUrl { get; set; }

    [Required()]
    public string City { get; set; }

    public string State { get; set; }

    [Required()]
    public string Country { get; set; }

    [Required()]
    public string HomeAirport { get; set; }

    public Plane FavoritePlane { get; set; }

    [Required()]
    public DateTime Created { get; set; } = DateTime.Now;

    [Required()]
    public DateTime LastActive { get; set; } = DateTime.Now;
    public ICollection<AppUserRole> UserRoles { get; set; }
    public ICollection<Voyage> Voyages { get; set; }
  }
}
