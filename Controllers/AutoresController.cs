using Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Entidades;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/autores
        [HttpGet]
        public async Task<IEnumerable<Autor>> Get()
        {
            return await context.Autores.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        // GET: api/autores/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(new { message = $"Author with id {id}" });
        }

        // PUT: api/autores/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] object autor)
        {
            return NoContent();
        }

        // DELETE: api/autores/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}