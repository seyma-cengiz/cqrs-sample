using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStorage.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStorage.Infrastructure
{
    public class BookStorageDbContext : DbContext
    {
        public BookStorageDbContext(DbContextOptions<BookStorageDbContext> opts) 
        : base(opts)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}