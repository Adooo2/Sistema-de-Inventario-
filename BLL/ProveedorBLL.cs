using System;
using System.Collections.Generic;
using DAL;
using EL;

namespace BLL
{
    // en esta clase estoy implemento toda la lógica de negocio para los proveedores
     
    public class ProveedorBLL
    {
        // una variable para acceder a la capa de datos
        private readonly ProveedorDAL _proveedorDAL;

        // con esto inicializo mi acceso a la capa DAL
        public ProveedorBLL()
        {
            _proveedorDAL = new ProveedorDAL();
        }

        // Aquí  llamo al método de DAL para obtener todos los proveedores
        public List<Proveedor> ObtenerTodos()
        {
            return _proveedorDAL.ObtenerTodos();
        }

        // Aquí llamo al método de DAL para obtener un proveedor por ID
        public Proveedor ObtenerPorId(int id)
        {
            return _proveedorDAL.ObtenerPorId(id);
        }

        // Con este método valido los datos antes de insertar un proveedor
        public int Insertar(Proveedor proveedor)
        {
            // verifico que los datos sean válidos
            ValidarProveedor(proveedor);

            // si todo está bien lo inserto en la base de datos a través del DAL
            return _proveedorDAL.Insertar(proveedor);
        }

        // Con este método valido los datos antes de actualizar un proveedor
        public bool Actualizar(Proveedor proveedor)
        {
            // Primero verifico que los datos sean válidos
            ValidarProveedor(proveedor);

            // Si todo está bien lo actualizo en la base de datos a través del DAL
            return _proveedorDAL.Actualizar(proveedor);
        }

        // Aquí llamo al método de DAL para eliminar un proveedor
        public bool Eliminar(int id)
        {
            return _proveedorDAL.Eliminar(id);
        }

        // Con este método busco proveedores por nombre haciendo una pequeña validación
        public List<Proveedor> BuscarPorNombre(string nombre)
        {
            // Si no hay texto de búsqueda, devuelvo todos los proveedores
            if (string.IsNullOrWhiteSpace(nombre))
                return _proveedorDAL.ObtenerTodos();

            // Si hay texto busco coincidencias a través del DAL
            return _proveedorDAL.BuscarPorNombre(nombre);
        }

       
        private void ValidarProveedor(Proveedor proveedor)
        {
            // Verifico que el proveedor no sea nulo
            if (proveedor == null)
                throw new ArgumentNullException("El proveedor no puede ser nulo");

           
            if (string.IsNullOrWhiteSpace(proveedor.Nombre))
                throw new ArgumentException("El nombre del proveedor es obligatorio");

           
            if (string.IsNullOrWhiteSpace(proveedor.Telefono))
                throw new ArgumentException("El teléfono del proveedor es obligatorio");
        }
    }
}