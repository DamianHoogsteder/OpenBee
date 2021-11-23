using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.DAL
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions opt):base(opt)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
