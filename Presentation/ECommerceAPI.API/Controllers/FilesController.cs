using ECommerceAPI.Application.OptionsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        readonly StorageOptions _storage;
        public FilesController(IOptions<StorageOptions> options )
        {
            _storage = options.Value;
        }

        [HttpGet("[action]")]
        public IActionResult GetBaseStorageUrl()
        {
            return Ok(new{ Url= _storage.BaseStorageUrl });
        } 
    }
}
