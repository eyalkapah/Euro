﻿using Euro.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro.Context.Configurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.ToTable("Matches");

            builder.Property(p => p.HostScored)
                .IsRequired();

            builder.Property(p => p.GuestScored)
                .IsRequired();

            builder.HasOne(p => p.HostTeam)
                .WithMany()
                .HasForeignKey(p => p.HostTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.GuestTeam)
                .WithMany()
                .HasForeignKey(p => p.GuestTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Group)
                .WithMany(g => g.Matches)
                .HasForeignKey(p => p.GroupId);
        }
    }
}