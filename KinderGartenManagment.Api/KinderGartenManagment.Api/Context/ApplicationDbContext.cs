using KinderGartenManagment.Api.Models;
using KinderGartenManagment.Api.ViewModels;
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
        public DbSet<ParentConvention> ParentConventions { get; set; }
        public DbSet<EleveParent> EleveParents { get; set; }
        public DbSet<EleveEnrollement> EleveEnrollements { get; set; }
        public DbSet<Enrollement> Enrollements { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<ConventionFee> ConventionFees { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Payement> Payements { get; set; }
        public DbSet<PayementEnrollement> PayementEnrollements { get; set; }
        public DbSet<Modalite> Modalites { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EleveParent>()
            .HasKey(ep => new { ep.EleveId, ep.ParentId });
            modelBuilder.Entity<ParentConvention>()
            .HasKey(pc => new { pc.ParentId, pc.ConventionId, pc.DateDeDebut });
            modelBuilder.Entity<EleveEnrollement>()
            .HasIndex(ee => new { ee.EleveId, ee.EnrollementId, ee.DateDeDebut }).IsUnique();
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
            modelBuilder.Query<UnpaidViewModel>();
            modelBuilder.Query<DatesViewModel>();
            modelBuilder.Query<EleveViewModel>();
            //modelBuilder.Entity<Classe>()   
            //    .HasMany(c => c.Enrollements)
            //    .WithOne(e => e.Classe);
        }
    }
}
