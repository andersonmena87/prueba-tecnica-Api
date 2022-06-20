using ApiPruebaTecnica.Models;

namespace ApiPruebaTecnica.Business.Interfaces
{
    public interface IUsuarioBL
    {
        public Task<List<UsuarioModel>> GetAll();

        public bool Insert(UsuarioModel usuario);

        public bool Update(UsuarioModel usuario);

        public bool Delete(int id);
    }
}
