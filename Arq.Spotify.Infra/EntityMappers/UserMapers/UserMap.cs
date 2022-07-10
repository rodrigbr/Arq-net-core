using Arq.Spotify.Domain.Entities.Spotify;
using Arq.Spotify.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arq.Spotify.Infra.EntityMappers.UserMapers
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Photo).IsRequired().HasMaxLength(500);
            builder.Property(x => x.DateOfBirth).IsRequired();

            builder.OwnsOne(x => x.Email, p =>
            {
                p.Property(f => f.Value).HasColumnName("Email");
            });

            builder.OwnsOne(p => p.Password, f =>
            {
                f.Property(x => x.Value).HasColumnName("Password");
            });
            builder.OwnsOne(p => p.Cpf, f =>
            {
                f.Property(x => x.Value).HasColumnName("Cpf");
            });
        }
    }
}
