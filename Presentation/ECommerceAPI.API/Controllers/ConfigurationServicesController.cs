using ECommerceAPI.Application.Abstractions.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationServicesController : ControllerBase
    {
        readonly IConfigurationService _configurationService;

        public ConfigurationServicesController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet]
        public IActionResult GetAuthorizeDefinitionEndpoints()
            => Ok(_configurationService.GetAuthorizeDefinitionEndpoints(typeof(Program)));
    }
}
