using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebStore.DAL.Context;
using WebStore.Domain.Entities.Identity;

namespace WebStore.Data
{
    public class WebStoreDbInitializer
    {
        private readonly WebStoreDB _db;
        private ILogger<WebStoreDbInitializer> _Logger;
        private readonly UserManager<User> _UserManager;
        private readonly RoleManager<Role> _RoleMananger;

        public WebStoreDbInitializer(
            WebStoreDB db, 
            ILogger<WebStoreDbInitializer> Logger,
            UserManager<User> UserManager,
            RoleManager<Role> RoleMananger)
        {
            _db = db;
            _Logger = Logger;
            _UserManager = UserManager;
            _RoleMananger = RoleMananger;
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
                InitializeIdentityAsync().Wait();
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

        private async Task InitializeIdentityAsync()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Identity initialization...");

            async Task CheckRole(string RoleName)
            {
                if (!await _RoleMananger.RoleExistsAsync(RoleName))
                {
                    _Logger.LogInformation("Role {0} was not found. Creating...", RoleName);
                    await _RoleMananger.CreateAsync(new Role { Name = RoleName });
                    _Logger.LogInformation("Role {0} created.", RoleName);
                }
                    
            }

            await CheckRole(Role.Administrator);
            await CheckRole(Role.User);

            if (await _UserManager.FindByNameAsync(User.Administrator) is null)
            {
                _Logger.LogInformation("Admin was not found");
                var admin = new User
                {
                    UserName = User.Administrator
                };

                var creation_result = await _UserManager.CreateAsync(admin, User.DefaultAdminPassword);
                if (creation_result.Succeeded)
                {
                    await _UserManager.AddToRoleAsync(admin, Role.Administrator);
                    _Logger.LogInformation("Admin was created");
                }
                else
                {
                    var errors = creation_result.Errors.Select(e => e.Description);
                    throw new InvalidOperationException($"Admin creation error: {string.Join(",", errors)}");
                }
            } 

            _Logger.LogInformation("Identity initialization ended successfully ({0:0.0###} sec.)", timer.Elapsed.Seconds);
        }
    }
}
