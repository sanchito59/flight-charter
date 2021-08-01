using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
  // override default primary key of string
  public class AppRole : IdentityRole<int>
  {
    public ICollection<AppUserRole> UserRoles { get; set; }
  }
}
