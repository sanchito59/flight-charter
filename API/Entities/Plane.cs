using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
  public class Plane
  {
    [Required()]
    public int Id { get; set; }

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
