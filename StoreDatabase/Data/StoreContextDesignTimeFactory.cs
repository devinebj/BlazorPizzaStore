using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace StoreDatabase.Data {
    internal class StoreContextDesignTimeFactory : IDesignTimeDbContextFactory<StoreContext> {
        public StoreContext CreateDbContext(string[] args) {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("StoreDB"));

            return new StoreContext(optionsBuilder.Options);
        }
    }
}
