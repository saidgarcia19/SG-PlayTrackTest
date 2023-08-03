﻿using Microsoft.EntityFrameworkCore;
using PlayTrackTestAPI.DB;

namespace PlayTrackTestAPI.services
{
    public class CategoriaService
    {
        private readonly LibreriaContext _context;

        public CategoriaService(LibreriaContext libreriaContext)
        {
            _context = libreriaContext;
        }

        public string AddCategory(Categorias categoria)
        {
            try
            {
                if (categoria != null)
                {
                    Categorias exist = _context.Categorias.Where(x => x.CategoriaID == categoria.CategoriaID).FirstOrDefault();
                    if (exist == null)
                    {
                        _context.Categorias.Add(categoria);
                        _context.SaveChanges();
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
            List<Categorias> list = _context.Categorias.ToList();

            return list;
        }
    }
}
