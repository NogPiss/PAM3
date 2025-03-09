/*
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RpgApi.Models;

namespace RpgApi.Data{

    public class DataContext : DbContext{

        public DataContext(DbContextOptions<DataContext> options) : base(options){

        }

        public DbSet<Personagem> TB_PERSONAGENS {get; set; }

        protected override void OModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personagem>().HasData()
        }
    }
}
*/