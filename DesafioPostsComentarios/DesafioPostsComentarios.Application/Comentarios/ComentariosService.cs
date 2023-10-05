using DesafioPostsComentarios.Application.Models;
using DesafioPostsComentarios.Repository;
using DesafioPostsComentarios.Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPostsComentarios.Application.Comentarios
{
    public class ComentariosService
    {
        private readonly DesafioPostsComentariosContext _context;

        public ComentariosService(DesafioPostsComentariosContext context)
        {
            _context = context;
        }

        public ComentariosReponse AdicionarComentario(ComentariosRequest request)
        {
            var response = new ComentariosReponse();
            try
            {
                var comentario = new TabPosts()
                {
                    NomeConta = request.NomeConta,
                    Comentarios = request.Comentarios
                };

                _context.TabPosts.Add(comentario);
                _context.SaveChanges();

                response.status = true;
                response.message = "paraben!! você conseguiu realizar a requisição!";
                return response;

                
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = "Infelismente não foi possivel realizar a requisição!";
                return response;
            }
        }

        public List<TabPosts> BuscarComentarios()
        {
            try
            {
                var comentarios = _context.TabPosts.ToList();
                if (comentarios == null)
                {
                    return null;
                }
                else
                {
                    return comentarios;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public bool AtualizarComentario(int id, ComentariosRequest request)
        {
            try
            {
                var comentario = _context.TabPosts.FirstOrDefault(x => x.Id == id);
                if (comentario == null)
                    return false;

                comentario.NomeConta = request.NomeConta;
                comentario.Comentarios = request.Comentarios;

                _context.TabPosts.Update(comentario);
                _context.SaveChanges();
                return true;
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletarComentario(int id)
        {
            try
            {
                var comentario = _context.TabPosts.FirstOrDefault(x => x.Id == id);
                if (comentario == null)
                    return false;
                _context.TabPosts.Remove(comentario);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<string>> InserirFoto(List<FileUploadModel> files, int id)
        {
            if (files == null || files.Count == 0)
                throw new ArgumentException("Nenhum arquivo foi fornecido para upload.");

            var fotosSalvas = new List<string>();

            foreach (var file in files)
            {
                if (file.Data.Length > 0)
                {
                    file.FileName = id.ToString() + $".{file.FileName.Split(".")[1]}";
                    // Salvar a foto em um diretório (por exemplo, "Fotos") e obter o caminho completo do arquivo salvo
                    string filePath = "C:\\inetpub\\wwwroot\\images\\" + file.FileName;

                    // Verificar se o diretório "Fotos" existe e criar se não existir
                    if (!Directory.Exists("C:\\inetpub\\wwwroot\\images"))
                    {
                        Directory.CreateDirectory("C:\\inetpub\\wwwroot\\images");
                    }

                    // Salvar o arquivo no diretório
                    await File.WriteAllBytesAsync(filePath, file.Data);
                    var user = _context.TabPosts.FirstOrDefault(x => x.Id == id);
                    user.Foto = file.FileName;
                    _context.TabPosts.Update(user);
                    _context.SaveChanges();


                    fotosSalvas.Add(filePath);
                }
            }

            return fotosSalvas;
        }
    }
}
