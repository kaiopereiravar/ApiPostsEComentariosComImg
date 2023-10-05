using DesafioPostsComentarios.Application.Comentarios;
using DesafioPostsComentarios.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Linq;
using DesafioPostsComentarios.Application.Models;

namespace DesafioPostsComentarios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComentariosController : ControllerBase
    {
        private readonly DesafioPostsComentariosContext _context;

        public ComentariosController(DesafioPostsComentariosContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult InserirComentarios([FromBody] ComentariosRequest request)
        {
            var comentariosService = new ComentariosService(_context);
            var comentarioAdicionado = comentariosService.AdicionarComentario(request);

            if(comentarioAdicionado.status)
            {
                return Ok(comentarioAdicionado);
            }

            else
            {
                return BadRequest(comentarioAdicionado);
            }     
        }

        [HttpGet]
        public IActionResult BuscarComentarios()
        {
            var comentariosService = new ComentariosService(_context);
            var comentarios = comentariosService.BuscarComentarios();

            if(comentarios != null)
            {
                return Ok(comentarios);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizarComentario([FromRoute]int id, [FromBody] ComentariosRequest request)
        {
            var comentariosService = new ComentariosService(_context);
            var comentarioAtualizado = comentariosService.AtualizarComentario(id, request);
            if (comentarioAtualizado == true)
            {
                return NoContent();
            }
            else 
            { 
                return BadRequest(); 
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletarComentario(int id)
        {
            var comentarioService = new ComentariosService(_context);
            var comentarioDeletado = comentarioService.DeletarComentario(id);
            if (comentarioDeletado == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Inserirfoto/{id}")]
        public async Task<IActionResult> InserirFoto([FromForm]List<IFormFile> files,[FromRoute] int id)
        {
            var produtoService = new ComentariosService(_context);
            var objId = _context.TabPosts.FirstOrDefault(x => x.Id == id);
            if (objId == null)
            {
                // faz alguma coisa pra negar
            }

            try
            {
                var fileModels = new List<FileUploadModel>();

                foreach (var formFile in files)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await formFile.CopyToAsync(memoryStream);
                        fileModels.Add(new FileUploadModel
                        {
                            FileName = formFile.FileName,
                            Data = memoryStream.ToArray()
                        });
                    }
                }

                var fotosSalvas = await produtoService.InserirFoto(fileModels, id);
                return Ok(fotosSalvas);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao salvar as fotos.");
            }
        }
    }
}
