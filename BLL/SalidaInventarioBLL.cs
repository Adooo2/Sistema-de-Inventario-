using System;
using EL;
using DAL; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SalidaInventarioBLL
    {
        private readonly SalidaInventarioDAL _salidaDAL;
        private readonly ProductoDAL _productoDAL;

        public SalidaInventarioBLL()
        {
            _salidaDAL = new SalidaInventarioDAL();
            _productoDAL = new ProductoDAL();
        }

        public List<SalidaInventario> ObtenerTodas()
        {
            try
            {
                return _salidaDAL.ObtenerTodas();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener salidas de inventario: " + ex.Message);
            }
        }

        public SalidaInventario ObtenerPorId(int id)
        {
            try
            {
                return _salidaDAL.ObtenerPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener salida de inventario: " + ex.Message);
            }
        }

        public int Insertar(SalidaInventario salida)
        {
            try
            {
                // Validaciones
                if (salida.ProductoId <= 0)
                    throw new Exception("Debe seleccionar un producto válido");

                if (salida.Cantidad <= 0)
                    throw new Exception("La cantidad debe ser mayor que cero");

                if (salida.PrecioVenta <= 0)
                    throw new Exception("El precio de venta debe ser mayor que cero");

                // Verificar stock disponible
                var producto = _productoDAL.ObtenerPorId(salida.ProductoId);
                if (producto == null)
                    throw new Exception("Producto no encontrado");

                if (producto.Stock < salida.Cantidad)
                    throw new Exception($"No hay suficiente stock. Stock actual: {producto.Stock}");

                // Si no se establece fecha, usar la fecha actual
                if (salida.Fecha == DateTime.MinValue)
                    salida.Fecha = DateTime.Now;

                return _salidaDAL.Insertar(salida);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar salida de inventario: " + ex.Message);
            }
        }

        public bool Actualizar(SalidaInventario salida, int cantidadAnterior)
        {
            try
            {
                // Validaciones
                if (salida.ProductoId <= 0)
                    throw new Exception("Debe seleccionar un producto válido");

                if (salida.Cantidad <= 0)
                    throw new Exception("La cantidad debe ser mayor que cero");

                if (salida.PrecioVenta <= 0)
                    throw new Exception("El precio de venta debe ser mayor que cero");

                // Si la cantidad ha aumentado, verificar stock disponible
                if (salida.Cantidad > cantidadAnterior)
                {
                    var producto = _productoDAL.ObtenerPorId(salida.ProductoId);
                    if (producto == null)
                        throw new Exception("Producto no encontrado");

                    int diferencia = salida.Cantidad - cantidadAnterior;
                    if (producto.Stock < diferencia)
                        throw new Exception($"No hay suficiente stock. Stock actual: {producto.Stock}");
                }

                return _salidaDAL.Actualizar(salida, cantidadAnterior);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar salida de inventario: " + ex.Message);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                return _salidaDAL.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar salida de inventario: " + ex.Message);
            }
        }

        public List<SalidaInventario> ObtenerPorProducto(int productoId)
        {
            try
            {
                return _salidaDAL.ObtenerPorProducto(productoId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener salidas por producto: " + ex.Message);
            }
        }

        public List<SalidaInventario> ObtenerPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                return _salidaDAL.ObtenerPorFecha(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener salidas por fecha: " + ex.Message);
            }
        }
    }
}