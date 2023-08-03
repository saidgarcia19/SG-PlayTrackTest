using PlayTrackTestAPI.DB;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace PlayTrackTestAPI.services
{
    public class LibroService
    {
        private readonly LibreriaContext _context;
        public LibroService(LibreriaContext context) { _context = context; }

        public string AddBook(Libros libro)
        {
            try
            {
                if (libro != null)
                {
                    Libros exist = _context.Libros.Where(x => x.LibroID == libro.LibroID).FirstOrDefault();
                    if (exist == null) {
                        _context.Libros.Add(libro);
                        _context.SaveChanges();
                    }
                    else
                    {
                        return "A book with that Id already exists.";
                    }
                }
                else
                {
                    return "information can not be null";
                }
                return "Book added succesfully";
            }
            catch { return "Something gone wrong"; }
        }

        public List<Libros> GetBooks()
        {
            List<Libros> libros = _context.Libros.Include(x => x.Autor)
                                                 .Include(y => y.Categoria).ToList();

            return libros;
        }
    }
}
