using Microsoft.EntityFrameworkCore;
using MinhaPrimeiraApi.Data.Configuration;
using MinhaPrimeiraApi.Entities;

namespace MinhaPrimeiraApi.Data
{
    public class ApiRestContext : DbContext
    {
        public ApiRestContext()
        {
            
        }
        public ApiRestContext(DbContextOptions<ApiRestContext> options) : base(options){}
        public DbSet<Product> Produto{get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //new UserConfiguration().Configure(modelBuilder.Entity<User>);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
            
        }
    }
}