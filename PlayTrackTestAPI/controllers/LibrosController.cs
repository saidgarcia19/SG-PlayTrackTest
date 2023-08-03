using Microsoft.AspNetCore.Mvc;
using PlayTrackTestAPI.DB;
using PlayTrackTestAPI.services;

namespace PlayTrackTestAPI.controllers
{
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly LibroService _libroService;
        public LibrosController(LibroService libroService)
        {
            _libroService = libroService;
        }
        
        [HttpPost]
        [Route("api/Books/Add")]
        public string AddBook(Libros libro)
        {
            string response = _libroService.AddBook(libro);

            return response;
        }

        [HttpGet]
        [Route("api/Books/GetBooks")]
        public List<Libros> GetBooks()
        {
            List<Libros> list = _libroService.GetBooks();
            return list;
        }
        
    }
}
