using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CompanyEmployees.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/companies")]
    [ApiController]
    public class CompaniesV2ControllerController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;

        public CompaniesV2ControllerController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanoes()
        {
            var companies = await _repositoryManager.Company.GetAllCompaniesAsync(trackChanges: false);

            return Ok(companies);
        }
    }
}
