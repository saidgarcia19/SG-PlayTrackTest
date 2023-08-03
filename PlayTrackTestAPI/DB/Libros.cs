using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayTrackTestAPI.DB
{
    public class Libros
    {
        [Key]
        public int LibroID { get; set; }
        public string Titulo { get; set; }
        [ForeignKey("Autor")]
        public int AutorID { get; set; }
        public Autores Autor { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaID { get; set; }
        public Categorias Categoria { get; set; }
        public int AnioPublicacion { get; set; }
    }
}
