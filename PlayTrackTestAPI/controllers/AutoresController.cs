using Microsoft.AspNetCore.Mvc;
using PlayTrackTestAPI.DB;
using PlayTrackTestAPI.services;

namespace PlayTrackTestAPI.controllers
{
    public class AutoresController : ControllerBase
    {
        private readonly AutorService _autorService;

        public AutoresController(AutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpPost]
        [Route("api/Authors/Add")]
        public string AddBook(Autores autor)
        {
            string response = _autorService.AddAuthor(autor);

            return response;
        }

        [HttpGet]
        [Route("api/Authors/GetAuthors")]
        public List<Autores> GetBooks()
        {
            List<Autores> list = _autorService.GetAuthors();
            return list;
        }
    }
}
