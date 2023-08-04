using Microsoft.AspNetCore.Mvc;
using PlayTrackTestAPI.DB;
using PlayTrackTestAPI.models;
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
        public string AddBook(BookModel libro)
        {
            string response = _libroService.AddBook(libro);

            return response;
        }

        [HttpGet]
        [Route("api/Books/GetBooks")]
        public List<BooksList> GetBooks()
        {
            List<BooksList> list = _libroService.GetBooks();
            return list;
        }
        
    }
}
