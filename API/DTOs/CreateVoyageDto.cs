using System;
using System.Collections.Generic;
using API.Entities;

namespace API.DTOs
{
  public class CreateVoyageDto
  {
    public int Id { get; set; }

    public string Title { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public double TotalMileage { get; set; } = 0;

    public ICollection<Flight> Flights { get; set; }

    public ICollection<Plane> PlanesUsed { get; set; }
  }
}
