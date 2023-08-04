using PlayTrackTestAPI.DB;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PlayTrackTestAPI.models;

namespace PlayTrackTestAPI.services
{
    public class LibroService
    {
        private readonly LibreriaContext _context;
        public LibroService(LibreriaContext context) { _context = context; }

        public string AddBook(BookModel libro)
        {
            try
            {
                //validar el modelo
                if (libro != null)
                {
                    //buscar registro existente en la BD
                    Libros exist = _context.Libros.Where(x => x.LibroID == libro.LibroID).FirstOrDefault();
                    //si no existe el registro, agregarlo
                    if (exist == null) {
                        Libros newLibro = new Libros
                        {
                            LibroID = libro.LibroID,
                            Titulo = libro.Titulo,
                            AutorID = libro.AutorID,
                            CategoriaID = libro.CategoriaID,
                            AnioPublicacion = libro.AnioPublicacion
                        };

                        _context.Libros.Add(newLibro);
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

        public List<BooksList> GetBooks()
        {
            List<BooksList> books = new List<BooksList>();
            //buscar todos los registros en la BD
            List<Libros> libros = _context.Libros.Include(x => x.Autor)
                                                 .Include(y => y.Categoria).ToList();
            //recorrer resultado para mapear el modelo de salida
            foreach (Libros libro in libros) 
            {
                BooksList book = new BooksList
                {
                    Tittle = libro.Titulo,
                    Author = libro.Autor.Nombre,
                    Category = libro.Categoria.Nombre,
                    Year = libro.AnioPublicacion
                };
                books.Add(book);
            }    

            return books;
        }
    }
}
