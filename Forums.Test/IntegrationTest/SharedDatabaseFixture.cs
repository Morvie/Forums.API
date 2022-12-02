using Bogus;
using ForumsService.Domain.Entities;
using ForumsService.Infrastructure.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;

namespace Forums.Test.IntegrationTest
{
    public class SharedDatabaseFixture: IDisposable
    {
        private static readonly object _lock = new object();
        private static bool _databaseInitialized;
        private string dbName = "TestDatabase.db";
        public SharedDatabaseFixture()
        {
            Connection = new SqliteConnection($"Filename={dbName}");
            Seed();
            Connection.Open();
        }
        public DbConnection Connection
        {
            get;
        }
        public ForumDbContext CreateContext(DbTransaction? transaction = null)
        {
            var context = new ForumDbContext(new DbContextOptionsBuilder<ForumDbContext>().UseSqlite(Connection).Options);
            if (transaction != null)
            {
                context.Database.UseTransaction(transaction);
            }
            return context;
        }
        private void Seed()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                        SeedData(context);
                    }
                    _databaseInitialized = true;
                }
            }
        }
        private void SeedData(ForumDbContext context)
        {
            var id = new Guid("1c565daf - 3eaa - 4b60 - bc11 - d0a96fce249e");
            var fakeForums = new Faker<ForumsDTO>()
                .RuleFor(o => o.Id, f => id)
                .RuleFor(o => o.Description, f => "This is a movie test description!")
                .RuleFor(o => o.Title, f => "Test forum")
                .RuleFor(o => o.Ownership, f => id)
                .RuleFor(o => o.MovieId, f => f.Random.Int(10000, 99999))
                .RuleFor(o => o.DateOfAdded, f => DateTime.Now)
                .RuleFor(o => o.Amountoflikes, f => f.Random.Int(0, 1000))
                .RuleFor(o => o.Reported, f => false);
            var products = fakeForums.Generate(10);
            context.AddRange(products);
            context.SaveChanges();
        }
        public void Dispose() => Connection.Dispose();
    }
}
