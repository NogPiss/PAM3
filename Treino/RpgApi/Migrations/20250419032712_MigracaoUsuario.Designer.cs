﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RpgApi.Data;

#nullable disable

namespace RpgApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250419032712_MigracaoUsuario")]
    partial class MigracaoUsuario
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RpgApi.Models.Arma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Dano")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("TB_ARMAS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Dano = 15,
                            Nome = "Espada Longa"
                        },
                        new
                        {
                            Id = 2,
                            Dano = 20,
                            Nome = "Machado de Guerra"
                        },
                        new
                        {
                            Id = 3,
                            Dano = 8,
                            Nome = "Arco Curto"
                        },
                        new
                        {
                            Id = 4,
                            Dano = 12,
                            Nome = "Adaga Envenenada"
                        },
                        new
                        {
                            Id = 5,
                            Dano = 18,
                            Nome = "Martelo Sagrado"
                        },
                        new
                        {
                            Id = 6,
                            Dano = 14,
                            Nome = "Lança de Gelo"
                        },
                        new
                        {
                            Id = 7,
                            Dano = 16,
                            Nome = "Cajado Arcano"
                        });
                });

            modelBuilder.Entity("RpgApi.Models.Personagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Classe")
                        .HasColumnType("int");

                    b.Property<int>("Defesa")
                        .HasColumnType("int");

                    b.Property<int>("Forca")
                        .HasColumnType("int");

                    b.Property<byte[]>("FotoPersonagem")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Inteligencia")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.Property<int>("PontosVida")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TB_PERSONAGENS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Classe = 1,
                            Defesa = 23,
                            Forca = 17,
                            Inteligencia = 33,
                            Nome = "Frodo",
                            PontosVida = 100,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 2,
                            Classe = 1,
                            Defesa = 25,
                            Forca = 15,
                            Inteligencia = 30,
                            Nome = "Sam",
                            PontosVida = 100,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 3,
                            Classe = 3,
                            Defesa = 21,
                            Forca = 18,
                            Inteligencia = 35,
                            Nome = "Galadriel",
                            PontosVida = 100,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 4,
                            Classe = 2,
                            Defesa = 18,
                            Forca = 18,
                            Inteligencia = 37,
                            Nome = "Gandalf",
                            PontosVida = 100,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 5,
                            Classe = 1,
                            Defesa = 17,
                            Forca = 20,
                            Inteligencia = 31,
                            Nome = "Hobbit",
                            PontosVida = 100,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 6,
                            Classe = 3,
                            Defesa = 25,
                            Forca = 15,
                            Inteligencia = 30,
                            Nome = "Celeborn",
                            PontosVida = 100,
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 7,
                            Classe = 2,
                            Defesa = 11,
                            Forca = 25,
                            Inteligencia = 35,
                            Nome = "Radagast",
                            PontosVida = 100,
                            UsuarioId = 1
                        });
                });

            modelBuilder.Entity("RpgApi.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAcesso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Perfil")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("varchar")
                        .HasDefaultValue("Jogador");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("TB_USUARIOS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "seuEmail@gmail.com",
                            Latitude = -23.520024100000001,
                            Longitude = -46.596497999999997,
                            PasswordHash = new byte[] { 82, 152, 70, 214, 27, 141, 196, 145, 24, 146, 116, 64, 121, 62, 21, 254, 212, 66, 123, 115, 221, 174, 210, 206, 42, 89, 46, 151, 237, 208, 93, 172, 185, 238, 135, 61, 40, 208, 156, 163, 233, 237, 75, 45, 4, 92, 122, 221, 138, 92, 206, 214, 40, 7, 109, 217, 193, 108, 174, 44, 76, 175, 51, 104 },
                            PasswordSalt = new byte[] { 174, 183, 187, 215, 199, 28, 139, 252, 66, 238, 112, 171, 26, 209, 70, 43, 110, 219, 190, 48, 1, 133, 216, 116, 249, 89, 88, 67, 50, 169, 176, 6, 112, 42, 202, 239, 2, 191, 249, 20, 219, 251, 103, 169, 140, 173, 250, 168, 144, 195, 102, 16, 4, 215, 13, 5, 145, 91, 186, 63, 127, 215, 44, 190, 78, 190, 148, 211, 79, 167, 14, 29, 201, 118, 90, 231, 57, 181, 163, 150, 251, 148, 12, 18, 159, 242, 117, 56, 183, 35, 94, 216, 176, 219, 53, 108, 197, 17, 46, 216, 100, 157, 57, 2, 17, 113, 109, 145, 152, 23, 29, 215, 198, 109, 146, 177, 250, 66, 44, 220, 69, 73, 78, 147, 82, 219, 29, 58 },
                            Perfil = "Admin",
                            Username = "UsuarioAdmin"
                        });
                });

            modelBuilder.Entity("RpgApi.Models.Personagem", b =>
                {
                    b.HasOne("RpgApi.Models.Usuario", "Usuario")
                        .WithMany("Personagens")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("RpgApi.Models.Usuario", b =>
                {
                    b.Navigation("Personagens");
                });
#pragma warning restore 612, 618
        }
    }
}
