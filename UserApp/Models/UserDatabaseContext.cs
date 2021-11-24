using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserApp.Models
{
    public class UserDatabaseContext : IdentityDbContext
    {
        public UserDatabaseContext(DbContextOptions opt) : base(opt)
        {

        }

        public DbSet<User> ApplicationUsers { get; set; }
    }
}
