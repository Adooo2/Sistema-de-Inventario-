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

        
    }
}