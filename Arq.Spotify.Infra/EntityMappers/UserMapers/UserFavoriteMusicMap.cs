using Arq.Spotify.Domain.Entities.Spotify;
using Arq.Spotify.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arq.Spotify.Infra.EntityMappers.UserMapers
{
    public class UserFavoriteMusicMap : IEntityTypeConfiguration<UserFavoriteMusic>
    {
        public void Configure(EntityTypeBuilder<UserFavoriteMusic> builder)
        {
            builder.ToTable("UserFavoriteMusics");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Music).WithMany();
            builder.HasOne(x => x.User).WithMany(x => x.FavoriteMusics);
        }
    }
}
