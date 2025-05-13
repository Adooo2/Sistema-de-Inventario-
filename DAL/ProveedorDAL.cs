using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using EL;

namespace DAL
{
    public class ProveedorDAL
    {
        private readonly ApplicationDbContext _context;

        public ProveedorDAL()
        {
            _context = new ApplicationDbContext();
        }

        public List<Proveedor> ObtenerTodos()
        {
            return _context.Proveedores.Where(p => p.Estado).ToList();
        }

        public Proveedor ObtenerPorId(int id)
        {
            return _context.Proveedores.Find(id);
        }

        public int Insertar(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            _context.SaveChanges();
            return proveedor.Id;
        }

        public bool Actualizar(Proveedor proveedor)
        {
            var proveedorExistente = _context.Proveedores.Find(proveedor.Id);
            if (proveedorExistente != null)
            {
                _context.Entry(proveedorExistente).CurrentValues.SetValues(proveedor);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public bool Eliminar(int id)
        {
            var proveedor = _context.Proveedores.Find(id);
            if (proveedor != null)
            {
                _context.Proveedores.Remove(proveedor);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public List<Proveedor> BuscarPorNombre(string nombre)
        {
            return _context.Proveedores
                .Where(p => p.Estado && p.Nombre.Contains(nombre))
                .ToList();
        }
    }
}