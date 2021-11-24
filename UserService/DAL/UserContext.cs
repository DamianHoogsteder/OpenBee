using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace UserService.DAL
{
    public class UserContext : IdentityDbContext
    {
        public UserContext(DbContextOptions opt):base(opt)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
