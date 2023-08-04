using PlayTrackTestAPI.DB;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PlayTrackTestAPI.models;

namespace PlayTrackTestAPI.services
{
    public class LibroService
    {
        private readonly LibreriaContext _context;
        private readonly ILogger<LibroService> _logger;
        public LibroService(LibreriaContext context, ILogger<LibroService> logger)
        {
            _context = context; _logger = logger;
        }

        public string AddBook(BookModel libro)
        {
            try
            {
                //validar el modelo
                _logger.LogInformation("add book process started");
                if (libro != null)
                {
                    //buscar registro existente en la BD
                    _logger.LogInformation("look for book into DB");
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
                        _logger.LogInformation("add book to DB");
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
            _logger.LogInformation("Get books process started");
            List<BooksList> books = new List<BooksList>();
            //buscar todos los registros en la BD
            _logger.LogInformation("find book process started");
            List<Libros> libros = _context.Libros.Include(x => x.Autor)
                                                 .Include(y => y.Categoria).ToList();
            //recorrer resultado para mapear el modelo de salida
            foreach (Libros libro in libros) 
            {
                _logger.LogInformation("Create return model");
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
