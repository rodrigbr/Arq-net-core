using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arq.Spotify.Domain.Entities.Spotify;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arq.Spotify.Infra.EntityMappers.SpotifyMapping
{
    public class AlbumMap : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Album");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Backdrop).IsRequired().HasMaxLength(1024);

            builder.OwnsOne(p => p.Band, f =>
            {
                f.Property(x => x.Name).HasColumnName("BandName");
            });

            builder.HasMany(x => x.Musics).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
