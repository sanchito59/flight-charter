using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
  [Table("Voyages")]
  public class Voyage
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
    public double TotalMileage { get; set; } = 0;

    [Required()]
    public ICollection<Flight> Flights { get; set; }

    public ICollection<Plane> PlanesUsed { get; set; }

    [Required()]
    public int AppUserID { get; set; }

    [Required()]
    public DateTime Created { get; set; } = DateTime.Now;
  }
}
