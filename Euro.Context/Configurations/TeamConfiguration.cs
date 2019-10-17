using Euro.Domain;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro.Context.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Teams");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(64);

            builder.HasOne(x => x.Group)
                .WithMany(p => p.Teams)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}