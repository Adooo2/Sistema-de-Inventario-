using System;
using EL;
using DAL; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class EntradaInventarioBLL
    {
        private readonly EntradaInventarioDAL _entradaDAL;
        private readonly ProductoDAL _productoDAL;

        public EntradaInventarioBLL()
        {
            _entradaDAL = new EntradaInventarioDAL();
            _productoDAL = new ProductoDAL();
        }

        public List<EntradaInventario> ObtenerTodas()
        {
            try
            {
                return _entradaDAL.ObtenerTodas();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener entradas de inventario: " + ex.Message);
            }
        }

        public EntradaInventario ObtenerPorId(int id)
        {
            try
            {
                return _entradaDAL.ObtenerPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener entrada de inventario: " + ex.Message);
            }
        }

        public int Insertar(EntradaInventario entrada)
        {
            try
            {
                // Validaciones
                if (entrada.ProductoId <= 0)
                    throw new Exception("Debe seleccionar un producto válido");

                if (entrada.ProveedorId <= 0)
                    throw new Exception("Debe seleccionar un proveedor válido");

                if (entrada.Cantidad <= 0)
                    throw new Exception("La cantidad debe ser mayor que cero");

                if (entrada.PrecioCompra <= 0)
                    throw new Exception("El precio de compra debe ser mayor que cero");

                // Si no se establece fecha usar la fecha actual
                if (entrada.Fecha == DateTime.MinValue)
                    entrada.Fecha = DateTime.Now;

                return _entradaDAL.Insertar(entrada);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar entrada de inventario: " + ex.Message);
            }
        }

        public bool Actualizar(EntradaInventario entrada, int cantidadAnterior)
        {
            try
            {
                // Validaciones
                if (entrada.ProductoId <= 0)
                    throw new Exception("Debe seleccionar un producto válido");

                if (entrada.ProveedorId <= 0)
                    throw new Exception("Debe seleccionar un proveedor válido");

                if (entrada.Cantidad <= 0)
                    throw new Exception("La cantidad debe ser mayor que cero");

                if (entrada.PrecioCompra <= 0)
                    throw new Exception("El precio de compra debe ser mayor que cero");

                return _entradaDAL.Actualizar(entrada, cantidadAnterior);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar entrada de inventario: " + ex.Message);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                return _entradaDAL.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar entrada de inventario: " + ex.Message);
            }
        }

        public List<EntradaInventario> ObtenerPorProducto(int productoId)
        {
            try
            {
                return _entradaDAL.ObtenerPorProducto(productoId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener entradas por producto: " + ex.Message);
            }
        }

        public List<EntradaInventario> ObtenerPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                return _entradaDAL.ObtenerPorFecha(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener entradas por fecha: " + ex.Message);
            }
        }
    }
}