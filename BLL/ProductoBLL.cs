using EL;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class ProductoBLL
    {
        private readonly ProductoDAL _productoDAL;

        public ProductoBLL()
        {
            _productoDAL = new ProductoDAL();
        }

        // Método para obtener todos los productos
        public List<Producto> ObtenerTodos()
        {
            try
            {
                return _productoDAL.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener productos: " + ex.Message);
            }
        }

        // Método para obtener un producto por ID
        public Producto ObtenerPorId(int id)
        {
            try
            {
                return _productoDAL.ObtenerPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener producto: " + ex.Message);
            }
        }

        // Método para contar los productos
        public int ObtenerTotalProductos()
        {
            try
            {
                return _productoDAL.ObtenerTotalProductos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener total de productos: " + ex.Message);
            }
        }

        // Método para obtener productos con stock bajo
        public List<Producto> ObtenerProductosStockBajo(int stockMinimo)
        {
            try
            {
                return _productoDAL.ObtenerProductosStockBajo(stockMinimo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener productos con stock bajo: " + ex.Message);
            }
        }

        // Método para insertar un producto
        public int Insertar(Producto producto)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrEmpty(producto.Nombre))
                    throw new Exception("El nombre del producto es obligatorio");

                if (producto.Precio <= 0)
                    throw new Exception("El precio debe ser mayor que cero");

                if (producto.Stock < 0)
                    throw new Exception("El stock no puede ser negativo");

                return _productoDAL.Insertar(producto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar producto: " + ex.Message);
            }
        }

        // Método para actualizar un producto
        public bool Actualizar(Producto producto)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrEmpty(producto.Nombre))
                    throw new Exception("El nombre del producto es obligatorio");

                if (producto.Precio <= 0)
                    throw new Exception("El precio debe ser mayor que cero");

                if (producto.Stock < 0)
                    throw new Exception("El stock no puede ser negativo");

                return _productoDAL.Actualizar(producto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar producto: " + ex.Message);
            }
        }

        // Método para eliminar un producto
        public bool Eliminar(int id)
        {
            try
            {
                return _productoDAL.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar producto: " + ex.Message);
            }
        }

        // Método para buscar productos
        public List<Producto> BuscarProductos(string filtro)
        {
            try
            {
                if (string.IsNullOrEmpty(filtro))
                    return ObtenerTodos();

                return _productoDAL.BuscarProductos(filtro);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar productos: " + ex.Message);
            }
        }

        // Método para obtener productos por categoría
        public List<Producto> ObtenerPorCategoria(int categoriaId)
        {
            try
            {
                return _productoDAL.ObtenerPorCategoria(categoriaId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener productos por categoría: " + ex.Message);
            }
        }
    }
}