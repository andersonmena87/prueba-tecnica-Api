using ApiPruebaTecnica.Business.Interfaces;
using ApiPruebaTecnica.DB;
using ApiPruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaTecnica.Business
{
    public class UsuarioBL : IUsuarioBL
    {
        private readonly ApplicationDbContext _context;
        public UsuarioBL(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UsuarioModel>> GetAll()
        {
            List<UsuarioModel> usuarios = await (from usuario in _context.Usuarios
                      select new UsuarioModel 
                      {
                          Id = usuario.Id,
                          Nombre = usuario.Nombre,
                          FechaNacimiento = usuario.FechaNacimiento,
                          Genero = usuario.Genero,
                      }
                      ).ToListAsync();

            return usuarios;
        }

        public bool Insert(UsuarioModel usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
            return true;
        }

        public bool Update(UsuarioModel usuario)
        {
            if (usuario.Id > 0) 
            {
                _context.Update(usuario);
                _context.SaveChanges();
                return true;
            }
            
            return false;
        }

        public bool Delete(int id)
        {
            UsuarioModel usuario = _context.Usuarios.Where(u => u.Id == id).FirstOrDefault();

            if (usuario != null)
            {
                _context.Remove(usuario);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
