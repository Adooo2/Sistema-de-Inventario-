using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EL;

namespace DAL
{
    public class SalidaInventarioDAL
    {
        private readonly ApplicationDbContext _context;

        public SalidaInventarioDAL()
        {
            _context = new ApplicationDbContext();
        }

        public List<SalidaInventario> ObtenerTodas()
        {
            return _context.SalidasInventario
                .Where(s => s.Estado)
                .Include(s => s.Producto)
                .OrderByDescending(s => s.Fecha)
                .ToList();
        }

        public SalidaInventario ObtenerPorId(int id)
        {
            return _context.SalidasInventario
                .Include(s => s.Producto)
                .FirstOrDefault(s => s.IdSalida == id && s.Estado);
        }

        public int Insertar(SalidaInventario salida, bool actualizarStock = true)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Verificar stock disponible
                    if (actualizarStock)
                    {
                        var producto = _context.Productos.Find(salida.ProductoId);
                        if (producto != null)
                        {
                            if (producto.Stock < salida.Cantidad)
                                throw new Exception("No hay suficiente stock disponible.");

                            // Actualizar stock
                            producto.Stock -= salida.Cantidad;
                        }
                    }

                    // Agregar la salida al contexto
                    _context.SalidasInventario.Add(salida);

                    // Guardar cambios
                    _context.SaveChanges();

                    // Confirmar la transacción
                    transaction.Commit();

                    return salida.IdSalida;
                }
                catch
                {
                    // Revertir cambios si hay error
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public bool Actualizar(SalidaInventario salida, int cantidadAnterior)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var salidaExistente = _context.SalidasInventario.Find(salida.IdSalida);
                    if (salidaExistente != null)
                    {
                        // Actualizar el stock del producto si cambió la cantidad
                        if (salida.Cantidad != cantidadAnterior)
                        {
                            int diferencia = salida.Cantidad - cantidadAnterior;
                            var producto = _context.Productos.Find(salida.ProductoId);
                            if (producto != null)
                            {
                                if (producto.Stock - diferencia < 0)
                                    throw new Exception("No hay suficiente stock disponible.");

                                producto.Stock -= diferencia;
                            }
                        }

                        // Actualizar propiedades de la salida
                        _context.Entry(salidaExistente).CurrentValues.SetValues(salida);

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
                    var salida = _context.SalidasInventario.Find(id);
                    if (salida != null)
                    {
                        // Actualizar el stock del producto
                        var producto = _context.Productos.Find(salida.ProductoId);
                        if (producto != null)
                        {
                            producto.Stock += salida.Cantidad;
                        }

                        // Marcar como eliminada 
                        _context.SalidasInventario.Remove(salida);

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

        public List<SalidaInventario> ObtenerPorProducto(int productoId)
        {
            return _context.SalidasInventario
                .Where(s => s.Estado && s.ProductoId == productoId)
                .Include(s => s.Producto)
                .OrderByDescending(s => s.Fecha)
                .ToList();
        }

        public List<SalidaInventario> ObtenerPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return _context.SalidasInventario
                .Where(s => s.Estado && s.Fecha >= fechaInicio && s.Fecha <= fechaFin)
                .Include(s => s.Producto)
                .OrderByDescending(s => s.Fecha)
                .ToList();
        }
    }
}