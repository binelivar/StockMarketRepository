using Company.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.API.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<CompanyDetail>> GetAllCompanies();

        Task<IEnumerable<CompanyDetail>> GetCompanyInfo(string code);

        Task AddCompany(CompanyDetail newCompany);

        Task DeleteCompany(string code);
    }
}
