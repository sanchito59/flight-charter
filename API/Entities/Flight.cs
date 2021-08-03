using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
  public class Flight
  {
    [Required()]
    public int Id { get; set; }

    [Required()]
    public string Title { get; set; }

    [Required()]
    public DateTime StartDate { get; set; }

    [Required()]
    public DateTime EndDate { get; set; }

    [Required()]
    public Plane Plane { get; set; }

    [Required()]
    public Cooridinate StartLocation { get; set; }

    [Required()]
    public Cooridinate EndLocation { get; set; }

    [Required()]
    public double Distance { get; set; } = 0;

    public string FlightLog { get; set; }
  }
}
