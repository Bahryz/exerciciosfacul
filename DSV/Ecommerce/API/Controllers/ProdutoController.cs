using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        // [HttpGet("helloworld")]
        // public IActionResult HelloWorld()
        // {
        //     return Ok("Hello World");
        // }

        [HttpPost("cadastrar/produto")]
        public IActionResult Cadastrar([FromBody] Produto produto)
        {
            // Lógica para adicionar o produto no contexto
            _produtoRepository.Cadastrar(produto);
            return Created("", produto);

        }

        [HttpGet("listar/produto")]
        public IActionResult Listar(){
            var produtos = _produtoRepository.Listar();
            return Ok(produtos);
        }

        [HttpPost("cadastrar/usuario")]
        public IActionResult CadastrarUsuario([FromBody] Usuario usuario) {
            _   
        }

    }
}
