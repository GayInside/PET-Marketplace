using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileStorageController(IFileStorageRepository fileStorage) : Controller
    {
        [HttpGet("UrlForSaving")]
        public async Task<IActionResult> GetUrlForSaving(string logoName)
        {
            var url = await fileStorage.GetPresignedUrlForSavingPublicationsLogo(logoName);

            return Ok(url);
        }

        [HttpGet("UrlForRetrive")]
        public async Task<IActionResult> GetUrlForRetriving(string logoName)
        {
            var url = await fileStorage.GetPresignedUrlForRetrivingPublicationsLogo(logoName);

            return Ok(url);
        }
    }
}
