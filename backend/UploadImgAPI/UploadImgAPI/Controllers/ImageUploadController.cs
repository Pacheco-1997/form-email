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
                var img1 = Request.Form.Files[0];
                var img2 = Request.Form.Files[1];
                var img3 = Request.Form.Files[2];

                var nome = Request.Form["nome"];
                var email = Request.Form["email"];
                var plataforma = Request.Form["plataforma"];
                var problema = Request.Form["problema"];


                if (img1.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + img1.FileName))
                    {
                        img1.CopyTo(fileStream);
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
