using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace ConvertLinqApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        public UploadFileController(IWebHostEnvironment env)
        {
            _env = env;
        }


        [HttpPost]
        public async Task<string> UploadImage([FromBody] string ImageBase64)
        {
            byte[] Bytes = Convert.FromBase64String(ImageBase64);
            var FilePath = Path.Combine($"{_env.WebRootPath}/Files/{Guid.NewGuid()}.jpg");
            await System.IO.File.WriteAllBytesAsync(FilePath, Bytes);
            return "آپلود عکس باموفقیت انجام شد";

        }
    }
}