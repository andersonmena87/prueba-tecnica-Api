using ApiPruebaTecnica.Business.Interfaces;
using ApiPruebaTecnica.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaTecnica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioBL _bussines;

        public UsuarioController(IUsuarioBL bussines)
        {
            _bussines = bussines;
        }

        /// <summary>
        ///  Obtiene el listado de usuarios
        /// </summary>
        /// <returns>Listado de usuarios</returns>
        /// <response code="200">Operación finalizada exitosamente</response>
        /// <response code="500">Se presentó un error interno al consultar los usuarios</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<List<UsuarioModel>> GetAll()
        {
            try
            {
                return await _bussines.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Adiciona un nuevo usuario
        /// </summary>
        /// <param name="usuario">Objeto con la información del usuario que se creará</param>
        /// <returns>valor que indica si el registro se realizo de forma exitosa</returns>
        /// <response code="200">Operación finalizada exitosamente</response>
        /// <response code="500">Se presentó un error interno al adicionar un usuario</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<bool> Post(UsuarioModel usuario)
        {
            return _bussines.Insert(usuario);
        }

        /// <summary>
        /// Actualiza el la información de un usuario.
        /// </summary>
        /// <param name="usuario">objeto que contiene la información actualizada</param>
        /// <returns>valor que indica si el registró se actualizó correctamente.</returns>
        ///  /// <response code="200">Operación finalizada exitosamente</response>
        /// <response code="500">Se presentó un error interno al actualizar un usuario</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public ActionResult<bool> Put(UsuarioModel usuario)
        {
            return _bussines.Update(usuario);
        }

        /// <summary>
        /// Elimina usuario por id.
        /// </summary>
        /// <param name="id">objeto que contiene la información actualizada</param>
        /// <returns>valor que indica si el registró se eliminó correctamente.</returns>
        ///  /// <response code="200">Operación finalizada exitosamente</response>
        /// <response code="500">Se presentó un error interno al eliminar un usuario</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _bussines.Delete(id);
        }
    }
}