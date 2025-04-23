using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EL;

namespace DAL
{
    public class ProveedorDAL
    {
        // lista para simular una base de datos
        private static List<Proveedor> _proveedores = new List<Proveedor>
        {
            new Proveedor { Id = 1, Nombre = "Distribuidora Norte", Telefono = "555-1234", Email = "juan@norte.com", Direccion = "Calle Principal 123" },
            new Proveedor { Id = 2, Nombre = "Alimentos del Sur", Telefono = "555-5678", Email = "maria@sur.com", Direccion = "Av. Central 456" },
            new Proveedor { Id = 3, Nombre = "Productos Rápidos", Telefono = "555-9012", Email = "carlos@rapidos.com", Direccion = "Plaza Mayor 789" },
            new Proveedor { Id = 4, Nombre = "Importadora Global", Telefono = "555-3456", Email = "ana@global.com", Direccion = "Blvd. Industrial 101" },
            new Proveedor { Id = 5, Nombre = "Distribuidora Local", Telefono = "555-7890", Email = "roberto@local.com", Direccion = "Calle Comercio 234" }
        };

        private readonly ApplicationDbContext _context;

        public ProveedorDAL()
        {
            _context = new ApplicationDbContext();
        }

        public List<Proveedor> ObtenerTodos()
        {
            // devuelve la lista simulada en lugar de consultar la base de datos
            return _proveedores;
        }

        public Proveedor ObtenerPorId(int id)
        {
            return _proveedores.FirstOrDefault(p => p.Id == id);
        }

        public int Insertar(Proveedor proveedor)
        {
            // Ssimula la generación de un nuevo ID
            int nuevoId = _proveedores.Count > 0 ? _proveedores.Max(p => p.Id) + 1 : 1;
            proveedor.Id = nuevoId;
            _proveedores.Add(proveedor);
            return nuevoId;
        }

        public bool Actualizar(Proveedor proveedor)
        {
            var proveedorExistente = _proveedores.FirstOrDefault(p => p.Id == proveedor.Id);
            if (proveedorExistente != null)
            {
                int index = _proveedores.IndexOf(proveedorExistente);
                _proveedores[index] = proveedor;
                return true;
            }
            return false;
        }

        public bool Eliminar(int id)
        {
            var proveedor = _proveedores.FirstOrDefault(p => p.Id == id);
            if (proveedor != null)
            {
                return _proveedores.Remove(proveedor);
            }
            return false;
        }

        public List<Proveedor> BuscarPorNombre(string nombre)
        {
            return _proveedores.Where(p => p.Nombre.ToLower().Contains(nombre.ToLower())).ToList();
        }
    }
}