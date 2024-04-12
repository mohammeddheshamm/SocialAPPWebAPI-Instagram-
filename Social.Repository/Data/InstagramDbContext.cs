using Microsoft.EntityFrameworkCore;
using Social.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Social.Repository.Data
{
    public class InstagramDbContext : DbContext
    {
        public InstagramDbContext(DbContextOptions<InstagramDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // This line runs every class that implement the interface IEntityTypeConfiguration
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Post> Posts { get; set; }
    }
}
