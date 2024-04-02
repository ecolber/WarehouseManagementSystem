using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmt.Domain.Entities;

namespace WarehouseMgmt.Infrastructure.Data.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductTypeEntity> productTypes { get; set; }
        public DbSet<MetricUnitEntity> metricUnits { get; set; }
        public DbSet<UserEntity> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserSeeds());

            modelBuilder.Entity<ProductEntity>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.categoryId);
        }

        public override int SaveChanges()
        {
            try
            {
                AddAuditoryAttributes();
                //List<AuditEntry> auditEntries = GetAuditEntries();
                int response = base.SaveChanges();
                //SaveAuditOtherDB(auditEntries);
                return response;
            }
            catch (Exception ex)
            {
                this.ChangeTracker.Clear();
                throw ex;
            }
        }

        private void AddAuditoryAttributes()
        {
            this.ChangeTracker.DetectChanges();
            var added = this.ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Added)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in added)
            {
                if (entity is BaseEntity)
                {
                    var track = entity as BaseEntity;
                    track.CreatedDate = DateTime.Now;
                    track.CreatedBy = 1;
                    track.Status = true;
                }
            }

            var modified = this.ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Modified)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in modified)
            {
                if (entity is BaseEntity)
                {
                    var track = entity as BaseEntity;
                    track.UpdatedDate = DateTime.Now;
                    track.UpdatedBy = 1;
                }
            }
        }

    }
}
