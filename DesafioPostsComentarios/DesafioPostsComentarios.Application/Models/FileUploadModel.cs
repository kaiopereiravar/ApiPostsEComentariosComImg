using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioPostsComentarios.Application.Models
{
    public class FileUploadModel
    {
        public string FileName { get; set; }
        public byte[] Data { get; set; }
    }
}
