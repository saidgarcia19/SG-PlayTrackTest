using Microsoft.AspNetCore.Mvc;
using PlayTrackTestAPI.DB;
using PlayTrackTestAPI.services;

namespace PlayTrackTestAPI.controllers
{
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriaService _categoriaService;

        public CategoriasController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost]
        [Route("api/Categorys/Add")]
        public string AddCategory(Categorias categoria)
        {
            string response = _categoriaService.AddCategory(categoria);

            return response;
        }

        [HttpGet]
        [Route("api/Categorys/GetCategorys")]
        public List<Categorias> GetCategorys()
        {
            List<Categorias> list = _categoriaService.GetCategorys();
            return list;
        }
    }
}
