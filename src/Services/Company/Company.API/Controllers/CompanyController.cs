using Company.API.Entities;
using Company.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Company.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/Market")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _repository;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ICompanyRepository repository, ILogger<CompanyController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("company/getall")]
        [ProducesResponseType(typeof(IEnumerable<CompanyDetail>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CompanyDetail>>> GetAllCompanies()
        {
            var companies = await _repository.GetAllCompanies();
            return Ok(companies);
        }

        [HttpGet("company/info/{code}", Name = "GetCompanyInfo")]
        [ProducesResponseType(typeof(IEnumerable<CompanyDetail>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CompanyDetail>>> GetCompanyInfo(string code)
        {
            var companyInfo = await _repository.GetCompanyInfo(code);
            return Ok(companyInfo);
        }

        [HttpPost("company/register")]
        [ProducesResponseType(typeof(CompanyDetail), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CompanyDetail>> AddCompany([FromBody] CompanyDetail company)
        {
            await _repository.AddCompany(company);

            return CreatedAtRoute("GetCompanyInfo", new { code = company.CompanyCode }, company);
        }

        [HttpDelete("company/delete/{code}")]
        [ProducesResponseType(typeof(CompanyDetail), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCompany(string code)
        {
            //return Ok(await _repository.DeleteCompany(code);

            var stock = await _repository.GetCompanyInfo(code);

            if (stock is null)
            {
                return NotFound();
            }

            await _repository.DeleteCompany(code);

            return NoContent();

        }
    }
}
