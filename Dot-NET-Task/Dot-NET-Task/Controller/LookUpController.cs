using Microsoft.AspNetCore.Mvc;
using DotNETTask.Persistence.Interfaces.Services;

namespace DotNETTask.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookUpController : ControllerBase 
    {
        private readonly IProviderService _providerService;

        public LookUpController(IProviderService providerService) => _providerService = providerService;

        [HttpGet]
        public async Task<IActionResult> GetLookUpAsync()
        {
            return Ok(await this._providerService.LookUpAsync());
        }
    }
}
