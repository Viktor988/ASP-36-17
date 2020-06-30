using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApiNovine.Application;
using ApiNovine.Application.Commands.Picture;
using ApiNovine.Application.DataTransfer;
using ApiNovine.Application.Queries.Picture;
using ApiNovine.Application.Searches;
using ApiNovine.DataAccess;
using ApiNovine.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NovineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;
        private readonly ApiNovineContext context;
        

        public PictureController(IApplicationActor actor, UseCaseExecutor executor, ApiNovineContext context)
        {
            this.actor = actor;
            this.executor = executor;
            this.context = context;

        }
        // GET: api/Picture
        [HttpGet]
        public IActionResult Get([FromQuery] PictureSearch dto,[FromServices] IGetPictureQuery query)
        {
          
            return Ok(executor.ExecuteQuery(query,dto));
            
        }

       

        // POST: api/Picture
        [HttpPost]
        public IActionResult Post([FromForm] UploadImageDto dto)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(dto.Image.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                dto.Image.CopyTo(fileStream);
            }

            var pic = new Picture
            {
                Src = newFileName
            };
            context.Pictures.Add(pic);
            context.SaveChanges();
            return StatusCode(201);
        }

     
       

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromQuery] DeletePictureDto dto,[FromServices] IDeletePictureCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(204);
        }
    }
}
