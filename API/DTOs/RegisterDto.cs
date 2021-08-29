using System.ComponentModel.DataAnnotations;
using API.Entities;

namespace API.DTOs
{
  public class RegisterDto
  {
    [Required]
    public string Username { get; set; }

    [Required]
    [StringLength(16, MinimumLength = 4)]
    public string Password { get; set; }

    [Required]
    public string City { get; set; }
    public string State { get; set; }

    [Required]
    public string Country { get; set; }

    [Required]
    public string PhotoUrl { get; set; }

    // TODO: Make required with user interface and data
    public string HomeAirport { get; set; }

    public Plane FavoritePlane { get; set; }
  }
}
