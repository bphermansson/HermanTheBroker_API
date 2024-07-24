using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityTest
{
    [NotMapped]

    public class AspNetUsers: IdentityUser
    {
    }
}
