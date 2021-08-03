using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
  [Table("Coorindates")]
  public class Cooridinate
  {
    [Required()]
    public int Id { get; set; }

    [Required()]
    public double Latitude { get; set; }

    [Required()]
    public double Longitude { get; set; }

    [Required()]

    public CoordinateType TypeOfCoordinate { get; set; }

    public enum CoordinateType
    {
      StartingPoint,
      EndPoint,
      PointOfInterest
    }
  }
}
