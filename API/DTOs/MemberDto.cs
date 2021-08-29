using System;
using System.Collections.Generic;
using API.Entities;

namespace API.DTOs
{
  public class MemberDto
  {
    public int Id { get; set; }
    public string UserName { get; set; }
    public string PhotoUrl { get; set; }
    public string KnownAs { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastActive { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string HomeAirport { get; set; }
    public Plane FavoritePlane { get; set; }
    public ICollection<VoyageDto> Voyages { get; set; }
  }
}
