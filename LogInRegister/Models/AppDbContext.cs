using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LogInRegister.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserModel> user { get; set; }
    }
}