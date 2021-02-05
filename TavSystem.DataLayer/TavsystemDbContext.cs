using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TavSystem.Entities;

namespace TavSystem.DataLayer
{
    public class TavsystemDbContext:DbContext, IUnitOfWork
    {
        public IDbContextTransaction _transaction;
        public TavsystemDbContext( DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<AccountingDocument> accountingDocuments { get; set; } 
        public DbSet<Customer> customers { get; set; } 
        public DbSet<Invitem> invitems { get; set; } 
        public DbSet<InvitemDetail> invitemDetails { get; set; } 
        public DbSet<Product>  products { get; set; }
        public DbSet<Delivery>  deliveries { get; set; }

        public int SaveAllChanges()
        {
            return base.SaveChanges();
        }
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            ChangeTracker.AutoDetectChangesEnabled = false;
            var result = base.SaveChanges();
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ChangeTracker.DetectChanges();
            ChangeTracker.AutoDetectChangesEnabled = false;
            var result = base.SaveChanges(acceptAllChangesOnSuccess);
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken=new CancellationToken() )
        {
            ChangeTracker.DetectChanges();
            ChangeTracker.AutoDetectChangesEnabled = false;
            var result = base.SaveChangesAsync(cancellationToken);
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();
            ChangeTracker.AutoDetectChangesEnabled = false;
            var result = base.SaveChangesAsync(acceptAllChangesOnSuccess,cancellationToken);
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }
        public void BeginTransaction()
        {
            _transaction = Database.BeginTransaction(); 
        }

        public void CommitTransaction()
        {
            if (_transaction == null)
            {
                throw new NullReferenceException("Please call `BeginTransaction()` method first.");
            }
            _transaction.Commit();
        }

        public void RollbackTransaction()
        {
            if (_transaction == null)
            {
                throw new NullReferenceException("Please call `BeginTransaction()` method first.");
            }
            _transaction.Rollback();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly); 
        }

        public override void Dispose()
        {
            _transaction?.Dispose();
            base.Dispose();
        }
    }
}
