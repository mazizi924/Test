using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TavSystem.Entities;

namespace TavSystem.DataLayer.Repositories.Contracts
{
    public interface ITest
    {
        void AddTestData();
    }

    public class Test : ITest
    {
        protected readonly IUnitOfWork UnitOfWork;
        public DbSet<Category> _categories;
        public DbSet<Customer> _customers;
        public Test(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public void AddTestData()
        {
            _categories = UnitOfWork.Set<Category>();
            _customers = UnitOfWork.Set<Customer>();
            var categorycount = _categories.Count();
            if (categorycount == 0)
            {
                List<Category> categorie = new List<Category>();
                categorie.Add(new Category { Name = "Category1", ParentId = null });
                categorie.Add(new Category { Name = "Category2", ParentId = null });
                categorie.Add(new Category { Name = "Category3", ParentId = null });

                foreach (var item in categorie)
                {
                    _categories.Add(item);
                    UnitOfWork.SaveChanges();
                }
                List<Category> categories = new List<Category>();
                categories.Add(new Category { Name = "Child1-Category1", ParentId = 1 });
                categories.Add(new Category { Name = "Child2-Category1", ParentId = 1 });
                categories.Add(new Category { Name = "Child1-Category2", ParentId = 2 });
                categories.Add(new Category { Name = "Child2-Category2", ParentId = 2 });
                categories.Add(new Category { Name = "Child3-Category2", ParentId = 2 });
                categories.Add(new Category { Name = "Child1-Category3", ParentId = 2 });

                foreach (var item in categories)
                {
                    _categories.Add(item);
                    UnitOfWork.SaveChanges();
                }
            }
            var customercount = _customers.Count();
            if (customercount == 0)
            {
                List<Customer> customers = new List<Customer>()
                {
                    new Customer{ FirstName="علی",LastName="علوی",Phone="09120000011"},
                    new Customer{ FirstName="سارا",LastName="حسینی",Phone="09120000022"},
                    new Customer{ FirstName="محمد",LastName="محمدی",Phone="09120000033"},
                };
                foreach (var item in customers)
                {
                    _customers.Add(item);
                    UnitOfWork.SaveChanges();
                }
            }
        }
    }
}
