using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrazabilidadAPI.Domain.Entities;

namespace TrazabilidadAPI.Infrastructure.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<DataSet> DataSets { get; set; }
        public DbSet<Field> Fields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación muchos a muchos: UserRole
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserID);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleID);

            // Relaciones en Procedure
            modelBuilder.Entity<Procedure>()
                .HasOne(p => p.CreatedByUser)
                .WithMany(u => u.CreatedProcedures)
                .HasForeignKey(p => p.CreatedByUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Procedure>()
                .HasOne(p => p.LastModifiedUser)
                .WithMany(u => u.ModifiedProcedures)
                .HasForeignKey(p => p.LastModifiedUserID)
                .OnDelete(DeleteBehavior.Restrict);

            // Relaciones en DataSet
            modelBuilder.Entity<DataSet>()
                .HasOne(ds => ds.Procedure)
                .WithMany(p => p.DataSets!)
                .HasForeignKey(ds => ds.ProcedureID);

            modelBuilder.Entity<DataSet>()
                .HasOne(ds => ds.Field)
                .WithMany(f => f.DataSets)
                .HasForeignKey(ds => ds.FieldID);
        }


    }
}
