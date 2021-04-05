﻿// <auto-generated />
using System;
using AdminLTE.MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdminLTE.MVC.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201013205338_novocampohidro")]
    partial class novocampohidro
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdminLTE.MVC.Models.AguaApartamento", b =>
                {
                    b.Property<int>("AguaApartamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApartamentoId")
                        .HasColumnType("int");

                    b.Property<int?>("CondominioId")
                        .HasColumnType("int");

                    b.Property<string>("FotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Unidade")
                        .HasColumnType("int");

                    b.Property<double>("area_comum")
                        .HasColumnType("float");

                    b.Property<string>("bloco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dt_leitura_anterior")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dt_leitura_atual")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dt_leitura_proxima")
                        .HasColumnType("datetime2");

                    b.Property<double>("mes_anterior")
                        .HasColumnType("float");

                    b.Property<double>("mes_atual")
                        .HasColumnType("float");

                    b.Property<string>("tarifa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("total_unidade")
                        .HasColumnType("float");

                    b.Property<double>("total_unidade_condominio")
                        .HasColumnType("float");

                    b.Property<double>("vlr_agua")
                        .HasColumnType("float");

                    b.Property<double>("vlr_esgoto")
                        .HasColumnType("float");

                    b.Property<double>("volume_consumido")
                        .HasColumnType("float");

                    b.HasKey("AguaApartamentoId");

                    b.HasIndex("ApartamentoId");

                    b.HasIndex("CondominioId");

                    b.ToTable("AguaApartamento");
                });

            modelBuilder.Entity("AdminLTE.MVC.Models.AguaCondominio", b =>
                {
                    b.Property<int>("AguaCondominioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<int?>("BlocosId")
                        .HasColumnType("int");

                    b.Property<int>("CondominioId")
                        .HasColumnType("int");

                    b.Property<string>("FotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mes")
                        .HasColumnType("int");

                    b.Property<DateTime>("dt_leitura_atual")
                        .HasColumnType("datetime2");

                    b.Property<double>("re_leitura_atual")
                        .HasColumnType("float");

                    b.Property<long>("re_valor_atual")
                        .HasColumnType("bigint");

                    b.HasKey("AguaCondominioId");

                    b.HasIndex("BlocosId");

                    b.HasIndex("CondominioId");

                    b.ToTable("AguaCondominio");
                });

            modelBuilder.Entity("AdminLTE.MVC.Models.Apartamento", b =>
                {
                    b.Property<int>("ApartamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlocosId")
                        .HasColumnType("int");

                    b.Property<int?>("CondominioId")
                        .HasColumnType("int");

                    b.Property<string>("IdAspNetUsers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("apartamentos")
                        .HasColumnType("int");

                    b.HasKey("ApartamentoId");

                    b.HasIndex("BlocosId");

                    b.HasIndex("CondominioId");

                    b.ToTable("Apartamento");
                });

            modelBuilder.Entity("AdminLTE.MVC.Models.Blocos", b =>
                {
                    b.Property<int>("BlocosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bloco")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("CondominioId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("BlocosId");

                    b.HasIndex("CondominioId");

                    b.ToTable("Bloco");
                });

            modelBuilder.Entity("AdminLTE.MVC.Models.Condominio", b =>
                {
                    b.Property<int>("CondominioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sindico")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CondominioId");

                    b.ToTable("Condominio");
                });

            modelBuilder.Entity("AdminLTE.MVC.Models.HidroAutoSigfox", b =>
                {
                    b.Property<int>("HidroAutoSigfoxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("battery")
                        .HasColumnType("int");

                    b.Property<int>("counter01")
                        .HasColumnType("int");

                    b.Property<int>("counter02")
                        .HasColumnType("int");

                    b.Property<int>("counter03")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<string>("device")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emailConvidado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("humidity")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("rawdata")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int>("temperature")
                        .HasColumnType("int");

                    b.HasKey("HidroAutoSigfoxId");

                    b.ToTable("hidroAutoSigfox");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AdminLTE.MVC.Models.AguaApartamento", b =>
                {
                    b.HasOne("AdminLTE.MVC.Models.Apartamento", "Apartamento")
                        .WithMany("AguaApartamento")
                        .HasForeignKey("ApartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdminLTE.MVC.Models.Condominio", null)
                        .WithMany("AguaApartamentos")
                        .HasForeignKey("CondominioId");
                });

            modelBuilder.Entity("AdminLTE.MVC.Models.AguaCondominio", b =>
                {
                    b.HasOne("AdminLTE.MVC.Models.Blocos", null)
                        .WithMany("AguaCondominios")
                        .HasForeignKey("BlocosId");

                    b.HasOne("AdminLTE.MVC.Models.Condominio", "Condominio")
                        .WithMany("AguaCondominios")
                        .HasForeignKey("CondominioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdminLTE.MVC.Models.Apartamento", b =>
                {
                    b.HasOne("AdminLTE.MVC.Models.Blocos", "Blocos")
                        .WithMany("Apartamentos")
                        .HasForeignKey("BlocosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdminLTE.MVC.Models.Condominio", null)
                        .WithMany("Apartamentos")
                        .HasForeignKey("CondominioId");
                });

            modelBuilder.Entity("AdminLTE.MVC.Models.Blocos", b =>
                {
                    b.HasOne("AdminLTE.MVC.Models.Condominio", "Condominio")
                        .WithMany("Bloco")
                        .HasForeignKey("CondominioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
