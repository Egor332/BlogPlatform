﻿using BlogPlatform.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<UserPage> UserPages;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
