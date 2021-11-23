using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.DAL
{
    public class UserDatabaseContext : IdentityDbContext
    {
        public UserDatabaseContext(DbContextOptions options):base(options.ToString())
        {

        }
    }
}
