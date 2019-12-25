﻿// <auto-generated />
using System;
using Euro.ContextDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Euro.ContextDb.Migrations
{
    [DbContext(typeof(EuroContext))]
    [Migration("20191225191442_AddGroupSeeders")]
    partial class AddGroupSeeders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Euro.ContextDb.Models.ApplicationUser", b =>
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

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("Euro.Domain.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("GroupId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupId = 1,
                            Name = "A"
                        },
                        new
                        {
                            GroupId = 2,
                            Name = "B"
                        },
                        new
                        {
                            GroupId = 3,
                            Name = "C"
                        },
                        new
                        {
                            GroupId = 4,
                            Name = "D"
                        },
                        new
                        {
                            GroupId = 5,
                            Name = "E"
                        },
                        new
                        {
                            GroupId = 6,
                            Name = "F"
                        },
                        new
                        {
                            GroupId = 7,
                            Name = "G"
                        },
                        new
                        {
                            GroupId = 8,
                            Name = "H"
                        },
                        new
                        {
                            GroupId = 9,
                            Name = "I"
                        },
                        new
                        {
                            GroupId = 10,
                            Name = "J"
                        },
                        new
                        {
                            GroupId = 11,
                            Name = "Round of 16"
                        },
                        new
                        {
                            GroupId = 12,
                            Name = "Quaterfinal"
                        },
                        new
                        {
                            GroupId = 13,
                            Name = "Semifinal"
                        },
                        new
                        {
                            GroupId = 14,
                            Name = "Final"
                        });
                });

            modelBuilder.Entity("Euro.Domain.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("GuestScored")
                        .HasColumnType("int");

                    b.Property<int>("GuestTeamId")
                        .HasColumnType("int");

                    b.Property<int>("HostScored")
                        .HasColumnType("int");

                    b.Property<int>("HostTeamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PlayDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("MatchId");

                    b.HasIndex("GroupId");

                    b.HasIndex("GuestTeamId");

                    b.HasIndex("HostTeamId");

                    b.ToTable("Matches");

                    b.HasData(
                        new
                        {
                            MatchId = 1,
                            GroupId = 9,
                            GuestScored = 0,
                            GuestTeamId = 7,
                            HostScored = 3,
                            HostTeamId = 6,
                            PlayDateTime = new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MatchId = 2,
                            GroupId = 9,
                            GuestScored = 0,
                            GuestTeamId = 9,
                            HostScored = 5,
                            HostTeamId = 8,
                            PlayDateTime = new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MatchId = 3,
                            GroupId = 3,
                            GuestScored = 0,
                            GuestTeamId = 11,
                            HostScored = 2,
                            HostTeamId = 10,
                            PlayDateTime = new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MatchId = 4,
                            GroupId = 3,
                            GuestScored = 0,
                            GuestTeamId = 13,
                            HostScored = 4,
                            HostTeamId = 12,
                            PlayDateTime = new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MatchId = 5,
                            GroupId = 5,
                            GuestScored = 0,
                            GuestTeamId = 15,
                            HostScored = 2,
                            HostTeamId = 14,
                            PlayDateTime = new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MatchId = 6,
                            GroupId = 5,
                            GuestScored = 1,
                            GuestTeamId = 17,
                            HostScored = 2,
                            HostTeamId = 16,
                            PlayDateTime = new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MatchId = 7,
                            GroupId = 7,
                            GuestScored = 1,
                            GuestTeamId = 19,
                            HostScored = 1,
                            HostTeamId = 18,
                            PlayDateTime = new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MatchId = 8,
                            GroupId = 7,
                            GuestScored = 1,
                            GuestTeamId = 21,
                            HostScored = 3,
                            HostTeamId = 20,
                            PlayDateTime = new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MatchId = 9,
                            GroupId = 3,
                            GuestScored = 1,
                            GuestTeamId = 23,
                            HostScored = 0,
                            HostTeamId = 22,
                            PlayDateTime = new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MatchId = 10,
                            GroupId = 9,
                            GuestScored = 1,
                            GuestTeamId = 25,
                            HostScored = 3,
                            HostTeamId = 24,
                            PlayDateTime = new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Euro.Domain.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FlagImage")
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("TeamId");

                    b.HasIndex("GroupId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamId = 1,
                            FlagImage = "eng.png",
                            GroupId = 1,
                            Name = "England"
                        },
                        new
                        {
                            TeamId = 2,
                            FlagImage = "cze.png",
                            GroupId = 1,
                            Name = "Chech Republic"
                        },
                        new
                        {
                            TeamId = 3,
                            FlagImage = "bul.png",
                            GroupId = 1,
                            Name = "Bulgaria"
                        },
                        new
                        {
                            TeamId = 4,
                            FlagImage = "mne.png",
                            GroupId = 1,
                            Name = "Montenegro"
                        },
                        new
                        {
                            TeamId = 5,
                            FlagImage = "kos.png",
                            GroupId = 1,
                            Name = "Kosovo"
                        },
                        new
                        {
                            TeamId = 6,
                            FlagImage = "kaz.png",
                            GroupId = 9,
                            Name = "Kazakhstan"
                        },
                        new
                        {
                            TeamId = 7,
                            FlagImage = "sco.png",
                            GroupId = 9,
                            Name = "Scotland"
                        },
                        new
                        {
                            TeamId = 8,
                            FlagImage = "cyp.png",
                            GroupId = 9,
                            Name = "Cyprus"
                        },
                        new
                        {
                            TeamId = 9,
                            FlagImage = "smr.png",
                            GroupId = 9,
                            Name = "San Marino"
                        },
                        new
                        {
                            TeamId = 10,
                            FlagImage = "nir.png",
                            GroupId = 3,
                            Name = "Northern Ireland"
                        },
                        new
                        {
                            TeamId = 11,
                            FlagImage = "est.png",
                            GroupId = 3,
                            Name = "Estonia"
                        },
                        new
                        {
                            TeamId = 12,
                            FlagImage = "ned.png",
                            GroupId = 3,
                            Name = "Netherlands"
                        },
                        new
                        {
                            TeamId = 13,
                            FlagImage = "blr.png",
                            GroupId = 3,
                            Name = "Belarus"
                        },
                        new
                        {
                            TeamId = 14,
                            FlagImage = "svk.png",
                            GroupId = 5,
                            Name = "Slovkia"
                        },
                        new
                        {
                            TeamId = 15,
                            FlagImage = "hun.png",
                            GroupId = 5,
                            Name = "Hungary"
                        },
                        new
                        {
                            TeamId = 16,
                            FlagImage = "cro.png",
                            GroupId = 5,
                            Name = "Croatia"
                        },
                        new
                        {
                            TeamId = 17,
                            FlagImage = "aze.png",
                            GroupId = 5,
                            Name = "Azerbaijan"
                        },
                        new
                        {
                            TeamId = 18,
                            FlagImage = "isr.png",
                            GroupId = 7,
                            Name = "Israel"
                        },
                        new
                        {
                            TeamId = 19,
                            FlagImage = "svn.png",
                            GroupId = 7,
                            Name = "Slovenia"
                        },
                        new
                        {
                            TeamId = 20,
                            FlagImage = "mkd.png",
                            GroupId = 7,
                            Name = "North Macedonia"
                        },
                        new
                        {
                            TeamId = 21,
                            FlagImage = "lva.png",
                            GroupId = 7,
                            Name = "Latvia"
                        },
                        new
                        {
                            TeamId = 22,
                            FlagImage = "aut.png",
                            GroupId = 7,
                            Name = "Austria"
                        },
                        new
                        {
                            TeamId = 23,
                            FlagImage = "pol.png",
                            GroupId = 7,
                            Name = "Poland"
                        },
                        new
                        {
                            TeamId = 24,
                            FlagImage = "bel.png",
                            GroupId = 9,
                            Name = "Belgium"
                        },
                        new
                        {
                            TeamId = 25,
                            FlagImage = "rus.png",
                            GroupId = 9,
                            Name = "Russia"
                        },
                        new
                        {
                            TeamId = 26,
                            FlagImage = "por.png",
                            GroupId = 2,
                            Name = "Portugal"
                        },
                        new
                        {
                            TeamId = 27,
                            FlagImage = "ukr.png",
                            GroupId = 2,
                            Name = "Ukraine"
                        },
                        new
                        {
                            TeamId = 28,
                            FlagImage = "lux.png",
                            GroupId = 2,
                            Name = "Luxembourg"
                        },
                        new
                        {
                            TeamId = 29,
                            FlagImage = "ltu.png",
                            GroupId = 2,
                            Name = "Lithuania"
                        },
                        new
                        {
                            TeamId = 30,
                            GroupId = 8,
                            Name = "Moldova"
                        },
                        new
                        {
                            TeamId = 31,
                            GroupId = 8,
                            Name = "France"
                        },
                        new
                        {
                            TeamId = 32,
                            GroupId = 8,
                            Name = "Andora"
                        },
                        new
                        {
                            TeamId = 33,
                            GroupId = 8,
                            Name = "Iceland"
                        },
                        new
                        {
                            TeamId = 34,
                            GroupId = 8,
                            Name = "Albania"
                        },
                        new
                        {
                            TeamId = 35,
                            GroupId = 8,
                            Name = "Turkey"
                        },
                        new
                        {
                            TeamId = 36,
                            GroupId = 4,
                            Name = "Georgia"
                        },
                        new
                        {
                            TeamId = 37,
                            GroupId = 4,
                            Name = "Switzerland"
                        },
                        new
                        {
                            TeamId = 38,
                            GroupId = 4,
                            Name = "Gibraltar"
                        },
                        new
                        {
                            TeamId = 39,
                            GroupId = 4,
                            Name = "Republic of Ireland"
                        },
                        new
                        {
                            TeamId = 40,
                            GroupId = 6,
                            Name = "Sweden"
                        },
                        new
                        {
                            TeamId = 41,
                            GroupId = 6,
                            Name = "Romania"
                        },
                        new
                        {
                            TeamId = 42,
                            GroupId = 6,
                            Name = "Malta"
                        },
                        new
                        {
                            TeamId = 43,
                            GroupId = 6,
                            Name = "Faroe Islands"
                        },
                        new
                        {
                            TeamId = 44,
                            GroupId = 6,
                            Name = "Spain"
                        },
                        new
                        {
                            TeamId = 45,
                            GroupId = 6,
                            Name = "Norway"
                        },
                        new
                        {
                            TeamId = 46,
                            GroupId = 10,
                            Name = "Liechtenstein"
                        },
                        new
                        {
                            TeamId = 47,
                            GroupId = 10,
                            Name = "Greece"
                        },
                        new
                        {
                            TeamId = 48,
                            GroupId = 10,
                            Name = "Italy"
                        },
                        new
                        {
                            TeamId = 49,
                            GroupId = 10,
                            Name = "Fineland"
                        },
                        new
                        {
                            TeamId = 50,
                            GroupId = 10,
                            Name = "Bosnia and Herzegovina"
                        },
                        new
                        {
                            TeamId = 51,
                            GroupId = 10,
                            Name = "Armenia"
                        });
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Euro.Domain.Match", b =>
                {
                    b.HasOne("Euro.Domain.Group", "Group")
                        .WithMany("Matches")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Euro.Domain.Team", "GuestTeam")
                        .WithMany()
                        .HasForeignKey("GuestTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Euro.Domain.Team", "HostTeam")
                        .WithMany()
                        .HasForeignKey("HostTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Euro.Domain.Team", b =>
                {
                    b.HasOne("Euro.Domain.Group", "Group")
                        .WithMany("Teams")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict)
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
                    b.HasOne("Euro.ContextDb.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Euro.ContextDb.Models.ApplicationUser", null)
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

                    b.HasOne("Euro.ContextDb.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Euro.ContextDb.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
