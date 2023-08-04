using Microsoft.EntityFrameworkCore;
using PlayTrackTestAPI.DB;

namespace PlayTrackTestAPI.services
{
    public class CategoriaService
    {
        private readonly LibreriaContext _context;
        private readonly ILogger<CategoriaService> _logger;

        public CategoriaService(LibreriaContext libreriaContext, ILogger<CategoriaService> logger)
        {
            _context = libreriaContext;
            _logger = logger;
        }

        public string AddCategory(Categorias categoria)
        {
            _logger.LogInformation("Add Category process started");
            try
            {
                //validar modelo
                if (categoria != null)
                {
                    //Buscar registro existente
                    _logger.LogInformation("Find Category process started");
                    Categorias exist = _context.Categorias.Where(x => x.CategoriaID == categoria.CategoriaID).FirstOrDefault();
                    //si no existe, agregarlo
                    if (exist == null)
                    {
                        _context.Categorias.Add(categoria);
                        _context.SaveChanges();
                        _logger.LogInformation("Add Category to DB");
                    }
                    else
                    {
                        return "A category with that Id already exists.";
                    }
                }
                else
                {
                    return "information can not be null";
                }
                return "Category added succesfully";
            }
            catch { return "Something gone wrong"; }
        }

        public List<Categorias> GetCategorys()
        {
            //Obtener todos los registros de la tabla
            _logger.LogInformation("Get Categorys process started");
            List<Categorias> list = _context.Categorias.ToList();

            return list;
        }
    }
}
