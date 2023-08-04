using PlayTrackTestAPI.DB;

namespace PlayTrackTestAPI.services
{
    public class AutorService
    {
        private readonly LibreriaContext _context;
        public AutorService(LibreriaContext context) { _context = context; }

        public string AddAuthor(Autores autor)
        {
            try
            {
                //validar modelo
                if (autor != null) 
                {
                    //Buscar registro existente en la BD
                    Autores exist = _context.Autores.Where(x => x.AutorID == autor.AutorID).FirstOrDefault();
                    //si no existe, agregarlo
                    if (exist == null)
                    {
                        _context.Autores.Add(autor);
                        _context.SaveChanges();
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
            //obtener todos los registros de la tabla
            List<Autores> list = _context.Autores.ToList();

            return list;
        }
    }
}
