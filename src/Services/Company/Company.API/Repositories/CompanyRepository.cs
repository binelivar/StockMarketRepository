using Company.API.Data;
using Company.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.API.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ICompanyContext _context;

        public CompanyRepository(ICompanyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<CompanyDetail>> GetAllCompanies()
        {
            return await _context
                            .Companies
                            .Find(_ => true)
                            .ToListAsync();
        }

        public async Task<IEnumerable<CompanyDetail>> GetCompanyInfo(string code)
        {
            return await _context
                            .Companies
                            .Find(x => x.CompanyCode == code)
                            .ToListAsync();
        }

        public async Task AddCompany(CompanyDetail newCompany)
        {
            await _context.Companies.InsertOneAsync(newCompany);
        }

        public async Task DeleteCompany(string code)
        {
            await _context.Companies.DeleteOneAsync(x => x.CompanyCode == code);
        }
    }
}
