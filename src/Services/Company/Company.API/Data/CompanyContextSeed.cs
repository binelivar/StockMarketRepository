using Company.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.API.Data
{
    public class CompanyContextSeed
    {
        public static void SeedData(IMongoCollection<CompanyDetail> companyCollection)
        {
            bool existCompany = companyCollection.Find(p => true).Any();
            if (!existCompany)
            {
                companyCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }
        private static IEnumerable<CompanyDetail> GetPreconfiguredProducts()
        {
            return new List<CompanyDetail>()
            {
                new CompanyDetail()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    CompanyCode = "C003",
                    CompanyName = "LM Chemicals",
                    CompanyCEO = "Seigner",
                    CompanyTurnOver = (float?)6548.90,
                    CompanyWebsite = "www.LMCh.com",
                    StockExchange = "NSE"
                }
            };
        }
    }
}
