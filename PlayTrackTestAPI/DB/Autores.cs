using System.ComponentModel.DataAnnotations;

namespace PlayTrackTestAPI.DB
{
    public class Autores
    {
        [Key]
        public int AutorID { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
    }
}
