using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTrackWPF.models
{
    public class Book
    {
        public int LibroID { get; set; }
        public string Titulo { get; set; }    
        public int AutorID { get; set; }
        public int CategoriaID { get; set; }
        public int AnioPublicacion { get; set; }
    }
}
