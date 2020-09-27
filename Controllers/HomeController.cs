using Microsoft.AspNetCore.Mvc;
using UploadImages.Services;

namespace UploadImages.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        public string Post([FromBody] UploadImageCommand command)
        {
            var uploadService = new FileUpload();
            return uploadService.UploadBase64Image(command.Image, "NAME OF YOUR CONTAINER");
        }
    }
}