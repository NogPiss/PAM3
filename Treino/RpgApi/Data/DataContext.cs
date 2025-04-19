using Microsoft.EntityFrameworkCore;
using RpgApi.Models;
using RpgApi.Models.Enuns;
using RpgApi.Utils;

namespace RpgApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){

        }

        public DbSet<Personagem> TB_PERSONAGEM { get; set; }
        public DbSet<Arma> TB_ARMAS { get; set;}
        public DbSet<Usuario> TB_USUARIOS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personagem>().ToTable("TB_PERSONAGENS");
            modelBuilder.Entity<Arma>().ToTable("TB_ARMAS");
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");

            modelBuilder.Entity<Usuario>().HasMany(e => e.Personagens).WithOne(e => e.Usuario).HasForeignKey(e => e.UsuarioId).IsRequired(false);


            modelBuilder.Entity<Personagem>().HasData(
                new Personagem() {Id = 1, Nome = "Frodo",PontosVida = 100, Forca = 17, Defesa = 23, Inteligencia = 33, Classe = ClasseEnum.Cavaleiro, UsuarioId = 1},
                new Personagem() {Id = 2, Nome = "Sam",PontosVida = 100, Forca = 15, Defesa = 25, Inteligencia = 30, Classe = ClasseEnum.Cavaleiro, UsuarioId = 1},
                new Personagem() {Id = 3, Nome = "Galadriel",PontosVida = 100, Forca = 18, Defesa = 21, Inteligencia = 35, Classe = ClasseEnum.Clerigo, UsuarioId = 1},
                new Personagem() {Id = 4, Nome = "Gandalf",PontosVida = 100, Forca = 18, Defesa = 18, Inteligencia = 37, Classe = ClasseEnum.Mago, UsuarioId = 1},
                new Personagem() {Id = 5, Nome = "Hobbit",PontosVida = 100, Forca = 20, Defesa = 17, Inteligencia = 31, Classe = ClasseEnum.Cavaleiro, UsuarioId = 1},
                new Personagem() {Id = 6, Nome = "Celeborn",PontosVida = 100, Forca = 15, Defesa = 25, Inteligencia = 30, Classe = ClasseEnum.Clerigo, UsuarioId = 1},
                new Personagem() {Id = 7, Nome = "Radagast",PontosVida = 100, Forca = 25, Defesa = 11, Inteligencia = 35, Classe = ClasseEnum.Mago, UsuarioId = 1}
            );

            
            modelBuilder.Entity<Arma>().HasData(
                new Arma() { Id = 1, Nome = "Espada Longa", Dano = 15 },
                new Arma() { Id = 2, Nome = "Machado de Guerra", Dano = 20 },
                new Arma() { Id = 3, Nome = "Arco Curto", Dano = 8 },
                new Arma() { Id = 4, Nome = "Adaga Envenenada", Dano = 12 },
                new Arma() { Id = 5, Nome = "Martelo Sagrado", Dano = 18 },
                new Arma() { Id = 6, Nome = "Lança de Gelo", Dano = 14 },
                new Arma() { Id = 7, Nome = "Cajado Arcano", Dano = 16 }
            );

            Usuario user = new Usuario();
            Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[] salt);
            user.Id = 1;
            user.Username = "UsuarioAdmin";
            user.PasswordString = string.Empty;
            user.PasswordHash= hash;
            user.PasswordSalt = salt;
            user.Perfil = "Admin";
            user.Email = "seuEmail@gmail.com";
            user.Latitude = -23.5200241;
            user.Longitude = -46.596498;

            modelBuilder.Entity<Usuario>().HasData(user);
            modelBuilder.Entity<Usuario>().Property(u => u.Perfil).HasDefaultValue("Jogador");
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(200);
        }


    }
}