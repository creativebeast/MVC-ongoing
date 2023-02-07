﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplication1.Models.Exercise> Exercise { get; set; }
        public DbSet<WebApplication1.Models.Session> Session { get; set; }
        public DbSet<WebApplication1.Models.SE> SE { get; set; }
    }
}