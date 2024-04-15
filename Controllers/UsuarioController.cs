using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Model;
using SistemaDeTarefas.Repository.Interface;
using SistemaTarefasService.Interface;

// classe de controlador 
namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;

        }

        // metodo para busca os usuarios
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscaTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioService.BuscaTodosUsaurios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscaPorId(int id)
        {
            UsuarioModel usuarios = await _usuarioService.BuscaPorId(id);
            return Ok(usuarios);
        }
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuarios = await _usuarioService.Adicionar(usuarioModel);
            return Ok(usuarios);
        }
        [HttpPut]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuarios = await _usuarioService.Atualizar(usuarioModel, id);
            return Ok(usuarios);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {

            UsuarioModel Apagado = await _usuarioService.Apagar(id);
            return Ok(Apagado);
        }
    }
}
