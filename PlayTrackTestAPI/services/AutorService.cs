using PlayTrackTestAPI.DB;

namespace PlayTrackTestAPI.services
{
    public class AutorService
    {
        private readonly LibreriaContext _context;
        private readonly ILogger<AutorService> _logger;
        public AutorService(LibreriaContext context, ILogger<AutorService> logger)
        {
            _context = context; _logger = logger;
        }

        public string AddAuthor(Autores autor)
        {
            _logger.LogInformation("add Author process started");
            try
            {
                //validar modelo
                if (autor != null) 
                {
                    //Buscar registro existente en la BD
                    _logger.LogInformation("find Author process started");
                    Autores exist = _context.Autores.Where(x => x.AutorID == autor.AutorID).FirstOrDefault();
                    //si no existe, agregarlo
                    if (exist == null)
                    {
                        _context.Autores.Add(autor);
                        _context.SaveChanges();
                        _logger.LogInformation("add Author to DB");
                    }
                    else
                    {
                        return "An author with that Id already exists.";
                    }
                }
                else
                {
                    return "information can not be null";
                }
                return "Author added succesfully";
            }
            catch { return "Something gone wrong"; }
        }

        public List<Autores> GetAuthors()
        {
            _logger.LogInformation("Get Authors process started");
            //obtener todos los registros de la tabla
            List<Autores> list = _context.Autores.ToList();

            return list;
        }
    }
}
