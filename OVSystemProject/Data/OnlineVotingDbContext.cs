using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OVSystemProject.Models;
using System.Reflection.Emit;

namespace OVSystemProject.Data
{
    public class OnlineVotingDbContext : IdentityDbContext
    {
        public OnlineVotingDbContext(DbContextOptions<OnlineVotingDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUsers> ApplicationUsers { get; set; }

        public DbSet<Admin> Admin { get; set; }

        public DbSet<Voters> Voters { get; set; }

        public DbSet<Addresses> Addresses { get; set; }

        public DbSet<Positions> Positions { get; set; }

        public DbSet<Candidates> Candidates { get; set; }

        public DbSet<ElectionEvent> ElectionEvent { get; set; }

        public DbSet<VoteTransactions> VoteTransactions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Change the table names for IdentityUser, IdentityRole, and IdentityUserRole
            builder.Entity<IdentityUser>(entity => entity.ToTable("Users"));
            builder.Entity<IdentityRole>(entity => entity.ToTable("Roles"));
            builder.Entity<IdentityUserRole<string>>(entity => entity.ToTable("UserRoles"));

            // Change the table names for IdentityUserClaim, IdentityRoleClaim, and IdentityUserLogin
            builder.Entity<IdentityUserClaim<string>>(entity => entity.ToTable("UserClaims"));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.ToTable("RoleClaims"));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.ToTable("UserLogins"));

            // Change the table name for IdentityUserToken
            builder.Entity<IdentityUserToken<string>>(entity => entity.ToTable("UserTokens"));

            builder.Entity<ApplicationUsers>()
            .Property(s => s.RegisteredDate)
            .HasDefaultValueSql("GETDATE()");

            builder.Entity<Admin>()
                .HasOne(v => v.applicationUser)
                .WithOne()
                .HasForeignKey<Admin>(v => v.UserId);

            builder.Entity<Voters>()
                .HasOne(v => v.applicationUser)
                .WithOne()
                .HasForeignKey<Voters>(v => v.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Addresses>()
                .HasOne(v => v.voter)
                .WithOne()
                .HasForeignKey<Addresses>(v => v.VoterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Candidates>()
                .HasOne(c => c.Positions) 
                .WithMany(p => p.Candidates)
                .OnDelete(DeleteBehavior.Cascade);


            //builder.Entity<ApplicationUsers>()
            //  .HasMany<Voters>(c => c.Id)
            //  .WithOptional(x => x.ApplicationUserds)
            //  .WillCascadeOnDelete(true);
        }
    }
}
