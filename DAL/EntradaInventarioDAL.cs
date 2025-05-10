using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EL;

namespace DAL
{
    public class EntradaInventarioDAL
    {
        private readonly ApplicationDbContext _context;

        public EntradaInventarioDAL()
        {
            _context = new ApplicationDbContext();
        }

        public List<EntradaInventario> ObtenerTodas()
        {
            return _context.EntradasInventario
                .Where(e => e.Estado)
                .Include(e => e.Producto)
                .Include(e => e.Proveedor)
                .OrderByDescending(e => e.Fecha)
                .ToList();
        }

        public EntradaInventario ObtenerPorId(int id)
        {
            return _context.EntradasInventario
                .Include(e => e.Producto)
                .Include(e => e.Proveedor)
                .FirstOrDefault(e => e.IdEntrada == id && e.Estado);
        }

        public int Insertar(EntradaInventario entrada, bool actualizarStock = true)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    /
                    _context.EntradasInventario.Add(entrada);

                    // Actualizar el stock del producto si se solicita
                    if (actualizarStock)
                    {
                        var producto = _context.Productos.Find(entrada.ProductoId);
                        if (producto != null)
                        {
                            producto.Stock += entrada.Cantidad;
                        }
                    }

                    // Guardar cambios
                    _context.SaveChanges();

                    // Confirmar la transacción
                    transaction.Commit();

                    return entrada.IdEntrada;
                }
                catch
                {
                    // Revertir cambios si hay error
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public bool Actualizar(EntradaInventario entrada, int cantidadAnterior)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var entradaExistente = _context.EntradasInventario.Find(entrada.IdEntrada);
                    if (entradaExistente != null)
                    {
                        // Actualizar el stock del producto si cambió la cantidad
                        if (entrada.Cantidad != cantidadAnterior)
                        {
                            int diferencia = entrada.Cantidad - cantidadAnterior;
                            var producto = _context.Productos.Find(entrada.ProductoId);
                            if (producto != null)
                            {
                                producto.Stock += diferencia;
                            }
                        }

                        // Actualizar propiedades de la entrada
                        _context.Entry(entradaExistente).CurrentValues.SetValues(entrada);

                        // Guardar cambios
                        bool resultado = _context.SaveChanges() > 0;

                        // Confirmar la transacción
                        transaction.Commit();

                        return resultado;
                    }

                    return false;
                }
                catch
                {
                    // Revertir cambios si hay error
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public bool Eliminar(int id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var entrada = _context.EntradasInventario.Find(id);
                    if (entrada != null)
                    {
                        // Actualizar el stock del producto
                        var producto = _context.Productos.Find(entrada.ProductoId);
                        if (producto != null)
                        {
                            producto.Stock -= entrada.Cantidad;
                            if (producto.Stock < 0)
                                throw new Exception("La eliminación de esta entrada dejaría el stock negativo.");
                        }

                        // Marcar como eliminada 
                        entrada.Estado = false;

                        // Guardar cambios
                        bool resultado = _context.SaveChanges() > 0;

                        // Confirmar la transacción
                        transaction.Commit();

                        return resultado;
                    }

                    return false;
                }
                catch
                {
                    // Revertir cambios si hay error
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public List<EntradaInventario> ObtenerPorProducto(int productoId)
        {
            return _context.EntradasInventario
                .Where(e => e.Estado && e.ProductoId == productoId)
                .Include(e => e.Producto)
                .Include(e => e.Proveedor)
                .OrderByDescending(e => e.Fecha)
                .ToList();
        }

        public List<EntradaInventario> ObtenerPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return _context.EntradasInventario
                .Where(e => e.Estado && e.Fecha >= fechaInicio && e.Fecha <= fechaFin)
                .Include(e => e.Producto)
                .Include(e => e.Proveedor)
                .OrderByDescending(e => e.Fecha)
                .ToList();
        }
    }
}