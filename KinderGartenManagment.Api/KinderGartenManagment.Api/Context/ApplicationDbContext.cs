using KinderGartenManagment.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace KinderGartenManagment.Api.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
    UserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Convention> Conventions { get; set; }
        public DbSet<Eleve> Eleves { get; set; }
        public virtual DbSet<ParentConvention> ParentConventions { get; set; }
        public DbSet<EleveParent> EleveParents { get; set; }
        public DbSet<EleveEnrollement> EleveEnrollements { get; set; }
        public DbSet<Enrollement> Enrollements { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ConventionFee> ConventionFees { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Payement> Payements { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EleveParent>()
            .HasKey(o => new { o.EleveId, o.ParentId });
            modelBuilder.Entity<EleveEnrollement>()
            .HasKey(o => new { o.EleveId, o.EnrollementId });
            modelBuilder.Entity<ParentConvention>()
            .HasKey(o => new { o.ParentId, o.ConventionId, o.DateDeDebut });
            //modelBuilder.Entity<BookCategory>()
            //.HasKey(o => new { o.BookId, o.CategoryId });
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
            //modelBuilder.Entity<Classe>()   
            //    .HasMany(c => c.Enrollements)
            //    .WithOne(e => e.Classe);
        }
    }
}
