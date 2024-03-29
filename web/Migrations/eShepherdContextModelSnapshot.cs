﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using web.Data;

namespace web.Migrations
{
    [DbContext(typeof(eShepherdContext))]
    partial class eShepherdContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("web.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("web.Models.Creda", b =>
                {
                    b.Property<string>("CredeID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Opombe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CredeID");

                    b.ToTable("Crede");
                });

            modelBuilder.Entity("web.Models.Gonitev", b =>
                {
                    b.Property<int>("GonitevID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumGonitve")
                        .HasColumnType("datetime2");

                    b.Property<string>("Opombe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OvcaID")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("OvenID")
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("GonitevID");

                    b.HasIndex("OvcaID");

                    b.HasIndex("OvenID");

                    b.ToTable("Gonitev");
                });

            modelBuilder.Entity("web.Models.Jagenjcek", b =>
                {
                    b.Property<int>("skritIdJagenjcka")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CredaCredeID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdJagenjcka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("kotitevID")
                        .HasColumnType("int");

                    b.Property<string>("opombe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("stanje")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("skritIdJagenjcka");

                    b.HasIndex("CredaCredeID");

                    b.HasIndex("kotitevID");

                    b.ToTable("Jagenjcek");
                });

            modelBuilder.Entity("web.Models.Kotitev", b =>
                {
                    b.Property<int>("kotitevID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumKotitve")
                        .HasColumnType("datetime2");

                    b.Property<string>("Opombe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OvcaID")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("OvenID")
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("SteviloMrtvih")
                        .HasColumnType("int");

                    b.HasKey("kotitevID");

                    b.HasIndex("OvcaID");

                    b.HasIndex("OvenID");

                    b.ToTable("Kotitev");
                });

            modelBuilder.Entity("web.Models.Ovca", b =>
                {
                    b.Property<string>("OvcaID")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("CredaID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DatumRojstva")
                        .HasColumnType("datetime2");

                    b.Property<string>("Opombe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pasma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stanje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SteviloSorojencev")
                        .HasColumnType("int");

                    b.Property<string>("mamaID")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("oceID")
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("OvcaID");

                    b.HasIndex("CredaID");

                    b.HasIndex("mamaID");

                    b.HasIndex("oceID");

                    b.ToTable("Ovca");
                });

            modelBuilder.Entity("web.Models.Oven", b =>
                {
                    b.Property<string>("OvenID")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("CredaID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DatumRojstva")
                        .HasColumnType("datetime2");

                    b.Property<string>("Opombe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pasma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poreklo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stanje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SteviloSorojencev")
                        .HasColumnType("int");

                    b.Property<string>("mamaID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("oceID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OvenID");

                    b.HasIndex("CredaID");

                    b.ToTable("Oven");
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
                    b.HasOne("web.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("web.Models.ApplicationUser", null)
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

                    b.HasOne("web.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("web.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("web.Models.Gonitev", b =>
                {
                    b.HasOne("web.Models.Ovca", "ovca")
                        .WithMany("SeznamGonitev")
                        .HasForeignKey("OvcaID");

                    b.HasOne("web.Models.Oven", "oven")
                        .WithMany("vseGonitve")
                        .HasForeignKey("OvenID");
                });

            modelBuilder.Entity("web.Models.Jagenjcek", b =>
                {
                    b.HasOne("web.Models.Creda", null)
                        .WithMany("SeznamJagenjckov")
                        .HasForeignKey("CredaCredeID");

                    b.HasOne("web.Models.Kotitev", "kotitev")
                        .WithMany("jagenjcki")
                        .HasForeignKey("kotitevID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("web.Models.Kotitev", b =>
                {
                    b.HasOne("web.Models.Ovca", "Ovca")
                        .WithMany("SeznamKotitev")
                        .HasForeignKey("OvcaID");

                    b.HasOne("web.Models.Oven", "Oven")
                        .WithMany("vseKotitve")
                        .HasForeignKey("OvenID");
                });

            modelBuilder.Entity("web.Models.Ovca", b =>
                {
                    b.HasOne("web.Models.Creda", "creda")
                        .WithMany("SeznamOvac")
                        .HasForeignKey("CredaID");

                    b.HasOne("web.Models.Ovca", "mama")
                        .WithMany()
                        .HasForeignKey("mamaID");

                    b.HasOne("web.Models.Oven", "oce")
                        .WithMany("ovce")
                        .HasForeignKey("oceID");
                });

            modelBuilder.Entity("web.Models.Oven", b =>
                {
                    b.HasOne("web.Models.Creda", "creda")
                        .WithMany()
                        .HasForeignKey("CredaID");
                });
#pragma warning restore 612, 618
        }
    }
}
