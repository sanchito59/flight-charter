namespace API.Entities
{
  public class AppUser
  {
    public int Id { get; set; }
    public int Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string HomeAirport { get; set; }
    public string FavoritePlane { get; set; }
  }
}
