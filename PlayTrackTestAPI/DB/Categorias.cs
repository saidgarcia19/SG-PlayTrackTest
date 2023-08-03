using System.ComponentModel.DataAnnotations;

namespace PlayTrackTestAPI.DB
{
    public class Categorias
    {
        [Key]
        public int CategoriaID { get; set; }
        public string Nombre { get; set; }
    }
}
