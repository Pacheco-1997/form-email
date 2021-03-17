using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UploadImgAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {

        public static IWebHostEnvironment _environment;
        public ImageUploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

   

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            try
            {
                //var conteudo = HttpContext.Items["model"].ToString();
                var teste = Request.Form.Files[0];


                if (teste.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + teste.FileName))
                    {
                        teste.CopyTo(fileStream);
                        fileStream.Flush();
                        return Ok();

                    }
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500,ex);
            }
        }
    }
}
