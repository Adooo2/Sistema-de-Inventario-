using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DAL
{
    public class ProductoDAL
    {
        private readonly ApplicationDbContext _context;

        public ProductoDAL()
        {
            _context = new ApplicationDbContext();
        }

        // Método para obtener todos los productos
        public List<Producto> ObtenerTodos()
        {
            return _context.Productos.Where(p => p.Estado).ToList();
        }

        // Método para contar los productos
        public int ObtenerTotalProductos()
        {
            return _context.Productos.Count(p => p.Estado);
        }

        // Método para obtener productos con stock bajo
        public List<Producto> ObtenerProductosStockBajo(int stockMinimo)
        {
            return _context.Productos
                .Where(p => p.Stock <= stockMinimo && p.Estado)
                .ToList();
        }

      
    }
}