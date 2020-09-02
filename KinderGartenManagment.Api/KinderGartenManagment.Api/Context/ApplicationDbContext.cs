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
        //public DbSet<Club> Clubs { get; set; }
        public DbSet<Convention> Conventions { get; set; }
        public DbSet<Eleve> Eleves { get; set; }
        public virtual DbSet<ParentConvention> ParentConventions { get; set; }
        public DbSet<EleveParent> EleveParents { get; set; }
        public DbSet<EleveGroupe> EleveGroupes { get; set; }
        //public DbSet<EleveClub> EleveClubs { get; set; }
        public DbSet<Groupe> Groupes { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EleveParent>()
            .HasKey(o => new { o.EleveId, o.ParentId });
            modelBuilder.Entity<EleveGroupe>()
            .HasKey(o => new { o.EleveId, o.GroupeId });
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
            //    .HasMany(c => c.Groupes)
            //    .WithOne(e => e.Classe);
        }
    }
}
