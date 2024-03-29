﻿using Microsoft.EntityFrameworkCore;
using valven_deneme.Entity;

namespace valven_deneme.Repository
{
    public class DataContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DataContext(DbContextOptions<DataContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

        public DbSet<Commit> Commits { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
