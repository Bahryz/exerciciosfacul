using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDataContext _context;

        public ProdutoController(AppDataContext context)
        {
            _context = context;
        }

        [HttpGet("helloworld")]
        public IActionResult HelloWorld()
        {
            return Ok("Hello World");
        }

        [HttpPost("cadastro")]
        public IActionResult Cadastrar([FromBody] Produto produto)
        {
            // Lógica para adicionar o produto no contexto
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return Created("", produto);
        }
    }
}
