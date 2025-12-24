using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "b5d1e9f6-6c10-4c8a-9e1d-111111111111",
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = "b5d1e9f6-6c10-4c8a-9e1d-222222222222",
                    Name = "Editor",
                    NormalizedName = "EDITOR"
                },
                new IdentityRole
                {
                    Id = "b5d1e9f6-6c10-4c8a-9e1d-333333333333",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );
        }
    }
}
