using API.Entities;

namespace API.DTOs
{
  public class UserDto
  {
    public string Username { get; set; }
    public string Token { get; set; }
    public string PhotoUrl { get; set; }
    public string City { get; set; }

    public string State { get; set; }
    public string Country { get; set; }

    public string HomeAirport { get; set; }

    public Plane FavoritePlane { get; set; }
  }
}
