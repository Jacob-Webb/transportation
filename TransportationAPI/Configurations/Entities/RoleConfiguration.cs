using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TransportationAPI.Configurations.Entities
{
    /// <summary>
    /// Role Configuration class that instantiates the database with the listed roles.
    /// </summary>
    /// <remarks>
    /// <list type="number">
    /// <item>
    /// <term>SuperAdmin</term>
    /// <description>
    /// Highest level of permissions. Access to all lower roles' permissions plus:
    /// <list type="bullet">
    /// <item><term>Manage Administrators.</term></item>
    /// </list>
    /// </description>
    /// </item>
    /// <item>
    /// <term>Administrator</term>
    /// <description>
    /// Access to Driver and User permissions plus:
    /// <list type="bullet">
    /// <item><term>Manage Church Gatherings</term></item>
    /// <item><term>Manage Vehicle Fleet</term></item>
    /// <item><term>Manage Drivers</term></item>
    /// <item><term>Manage Users</term></item>
    /// </list>
    /// </description>
    /// </item>
    /// <item>
    /// <term>Driver</term>
    /// <description>
    /// Access to User permissions plus:
    /// <list type="bullet">
    /// <item><term>Manage Gathering Routes</term></item>
    /// </list>
    /// </description>
    /// </item>
    /// <item>
    /// <term>User</term>
    /// <description>
    /// <list type="bullet">
    /// <item><term>Manage Profile</term></item>
    /// <item><term>Reset Password</term></item>
    /// <item><term>Schedule a ride for Gatherings</term></item>
    /// </list>
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1413:Use trailing comma in multi-line initializers", Justification = "Reviewed")]
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN"
                },
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Name = "Driver",
                    NormalizedName = "DRIVER"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            );
        }
    }
}
