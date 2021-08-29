using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
  [NotMapped]
  [Keyless]
  public class Plane
  {
    [Required()]
    public string Name { get; set; }
    [Required()]
    public int CruiseSpeed { get; set; }
    [Required()]
    public int MaxAltitude { get; set; }
    [Required()]
    public int Endurance { get; set; }
    [Required()]
    public int Range { get; set; }
  }
}
