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
            return _context.Productos
                .Where(p => p.Estado)
                .Include(p => p.Categoria) // Incluir la categoría relacionada
                .ToList();
        }

        // Método para obtener un producto por ID
        public Producto ObtenerPorId(int id)
        {
            return _context.Productos
                .Include(p => p.Categoria)
                .FirstOrDefault(p => p.IdProducto == id && p.Estado);
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
                .Include(p => p.Categoria)
                .ToList();
        }

        // Método para insertar un producto
        public int Insertar(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return producto.IdProducto;
        }

        // Método para actualizar un producto
        public bool Actualizar(Producto producto)
        {
            var productoExistente = _context.Productos.Find(producto.IdProducto);
            if (productoExistente != null)
            {
                _context.Entry(productoExistente).CurrentValues.SetValues(producto);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        // Método para eliminar un producto
        public bool Eliminar(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        // Método para filtrar productos por nombre o código
        public List<Producto> BuscarProductos(string filtro)
        {
            return _context.Productos
                .Where(p => p.Estado &&
                    (p.Nombre.Contains(filtro) ||
                     p.Descripcion.Contains(filtro)))
                .Include(p => p.Categoria)
                .ToList();
        }

        // Método para obtener productos por categoría
        public List<Producto> ObtenerPorCategoria(int categoriaId)
        {
            return _context.Productos
                .Where(p => p.Estado && p.CategoriaId == categoriaId)
                .Include(p => p.Categoria)
                .ToList();
        }
    }
}