using Company.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.API.Data
{
    public class CompanyContext : ICompanyContext
    {
        public CompanyContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Companies = database.GetCollection<CompanyDetail>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CompanyContextSeed.SeedData(Companies);
        }

        public IMongoCollection<CompanyDetail> Companies { get; }
    }
}
