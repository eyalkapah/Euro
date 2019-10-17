﻿// <auto-generated />
using System;
using Euro.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Euro.Context.Migrations
{
    [DbContext(typeof(EuroContext))]
    [Migration("20191017132837_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                });

            modelBuilder.Entity("Euro.Domain.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("MatchId");

                    b.HasIndex("GuestTeamId");

                    b.HasIndex("HostTeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Euro.Domain.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool>("IsHostTeam")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("TeamId");

                    b.HasIndex("GroupId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Euro.Domain.Match", b =>
                {
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

                    b.HasOne("Euro.Domain.Team", null)
                        .WithMany("Matches")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Euro.Domain.Team", b =>
                {
                    b.HasOne("Euro.Domain.Group", "Group")
                        .WithMany("Teams")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
