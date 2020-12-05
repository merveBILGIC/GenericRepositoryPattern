using Microsoft.EntityFrameworkCore;
using MusicMarket.Core.Models;
using MusicMarket.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicMarket.Data
{
    public class BooksMarketDbContext : DbContext
    {
        public DbSet<Books> Books { get; set; }
        public DbSet<Writers>Writers { get; set; }

        public BooksMarketDbContext(DbContextOptions<BooksMarketDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new BooksConfiguration());

            builder
                .ApplyConfiguration(new WritersConfiguration());
        }
    }
    
}
