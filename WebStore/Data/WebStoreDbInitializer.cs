using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebStore.DAL.Context;

namespace WebStore.Data
{
    public class WebStoreDbInitializer
    {
        private readonly WebStoreDB _db;
        private ILogger<WebStoreDbInitializer> _Logger;

        public WebStoreDbInitializer(WebStoreDB db, ILogger<WebStoreDbInitializer> Logger)
        {
            _db = db;
            _Logger = Logger;
        }

        public void Initialize()
        {
            var timer = Stopwatch.StartNew();

            _Logger.LogInformation("Db initialization...");
            /*_db.Database.EnsureDeleted();
            _db.Database.EnsureCreated();*/

            var db = _db.Database;
            if (db.GetPendingMigrations().Any())
            {
                _Logger.LogInformation("Db migration running...");
                db.Migrate();
                _Logger.LogInformation("Db migration done...");
            }
            else
                _Logger.LogInformation("Db migration is not needed ({0:0.0###} sec.)", timer.Elapsed.TotalSeconds);

            try
            {
                InitializeProducts();
            }
            catch (Exception error)
            {
                _Logger.LogError(error, "Error during Db initialization");
                throw;
            }

            _Logger.LogInformation("Db initialized successfully ({0:0.0###} sec.)", timer.Elapsed.TotalSeconds);
        }

        private void InitializeProducts()
        {
            var timer = Stopwatch.StartNew();
            if (_db.Products.Any())
            {
                _Logger.LogInformation("Products initialization is not needed");
                return;
            }
            _Logger.LogInformation("Products initialization...");
            _Logger.LogInformation("Sections...");
            using (_db.Database.BeginTransaction())
            {
                _db.Sections.AddRange(TestData.Sections);

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Sections] ON"); // to deal with primary keys in test data
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Sections] OFF"); // to deal with primary keys in test data
                _db.Database.CommitTransaction();
            }
            _Logger.LogInformation("Brands...");
            using (_db.Database.BeginTransaction())
            {
                _db.Brands.AddRange(TestData.Brands);

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Brands] ON"); // to deal with primary keys in test data
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Brands] OFF"); // to deal with primary keys in test data
                _db.Database.CommitTransaction();
            }
            _Logger.LogInformation("Products...");
            using (_db.Database.BeginTransaction())
            {
                _db.Products.AddRange(TestData.Products);

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] ON"); // to deal with primary keys in test data
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] OFF"); // to deal with primary keys in test data
                _db.Database.CommitTransaction();
            }

            _Logger.LogInformation("Products initialization completed ({0:0.0###} sec.)", timer.Elapsed.TotalSeconds);

        }
    }
}
