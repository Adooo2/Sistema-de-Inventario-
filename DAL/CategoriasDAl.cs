using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoriaDAL
    {
        private readonly ApplicationDbContext _context;

        public CategoriaDAL()
        {
            _context = new ApplicationDbContext();
        }

        public List<Categoria> ObtenerTodos()
        {
            return _context.Categorias.Where(c => c.Estado).ToList();
        }

        public Categoria ObtenerPorId(int id)
        {
            return _context.Categorias.FirstOrDefault(c => c.IdCategoria == id && c.Estado);
        }

        public int ObtenerTotalCategorias()
        {
            return _context.Categorias.Count(c => c.Estado);
        }

        public bool Insertar(Categoria categoria)
        {
            try
            {
                _context.Categorias.Add(categoria);
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(Categoria categoria)
        {
            try
            {
                var categoriaExistente = _context.Categorias.Find(categoria.IdCategoria);
                if (categoriaExistente != null)
                {
                    categoriaExistente.Nombre = categoria.Nombre;
                    categoriaExistente.Descripcion = categoria.Descripcion;

                    return _context.SaveChanges() > 0;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                var categoria = _context.Categorias.Find(id);
                if (categoria != null)
                {
                    categoria.Estado = false;
                    return _context.SaveChanges() > 0;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}