using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TavSystem.Entities;
using TavSystem.Entities.BaseClass;

namespace TavSystem.DataLayer.Repositories.Contracts
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }

        void Add(TEntity model);
        IEnumerable<TEntity> GetAll();
        TEntity GetByID(int Id);
        void Update(TEntity model);

        void AddAsync(TEntity model);
        IEnumerable<TEntity> GetAllAsync();
        TEntity GetByIDAsync(int Id); 
    }
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly IUnitOfWork UnitOfWork;
        public DbSet<TEntity> Entities { get; }
        public virtual IQueryable<TEntity> Table => Entities;
        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();
        public Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Entities = UnitOfWork.Set<TEntity>();
        }

        #region sync Method
        public virtual void Add(TEntity model)
        {
            Entities.Add(model);
            UnitOfWork.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Entities.ToList();
        }

        public virtual TEntity GetByID(int Id)
        {
            return Entities.Find(Id);
        }

        public void Update(TEntity model)
        {
            Entities.Update(model);
            UnitOfWork.SaveChanges();
        }
        #endregion

        #region Async Method
        public void AddAsync(TEntity model)
        {
            Entities.Add(model);
            UnitOfWork.SaveChanges();
        }

        public IEnumerable<TEntity> GetAllAsync()
        {
            return Entities.ToList();
        }

        public TEntity GetByIDAsync(int Id)
        {
            return Entities.Find(Id);
        }
         
        #endregion 
         
    }
}
