﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Collections.Specialized;
using EntityWords;

namespace EFUserContext
{
    class UserContext : DbContext
    {
        public DbSet<Words> Words { get; set; }
                
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["Dictionary"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Words>().HasKey(w => w.Id);
            modelBuilder.Entity<Words>().HasIndex(u => u.Word).IsUnique();
        }


    }

}
