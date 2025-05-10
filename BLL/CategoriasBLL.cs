using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoriaBLL
    {
        private readonly CategoriaDAL _categoriaDAL;

        public CategoriaBLL()
        {
            _categoriaDAL = new CategoriaDAL();
        }

        public List<Categoria> ObtenerTodos()
        {
            try
            {
                return _categoriaDAL.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener categorías: " + ex.Message);
            }
        }

        public Categoria ObtenerPorId(int id)
        {
            try
            {
                return _categoriaDAL.ObtenerPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener categoría: " + ex.Message);
            }
        }

        public int ObtenerTotalCategorias()
        {
            try
            {
                return _categoriaDAL.ObtenerTotalCategorias();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener total de categorías: " + ex.Message);
            }
        }

        public bool Insertar(Categoria categoria)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrEmpty(categoria.Nombre))
                    throw new Exception("El nombre de la categoría es obligatorio");

                return _categoriaDAL.Insertar(categoria);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar categoría: " + ex.Message);
            }
        }

        public bool Actualizar(Categoria categoria)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrEmpty(categoria.Nombre))
                    throw new Exception("El nombre de la categoría es obligatorio");

                return _categoriaDAL.Actualizar(categoria);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar categoría: " + ex.Message);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                return _categoriaDAL.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar categoría: " + ex.Message);
            }
        }
    }
}