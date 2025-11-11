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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Autor>> Get(int id)
        {
            var autor = await context.Autores.Include(x => x.Libros).FirstOrDefaultAsync(x => x.Id == id);
            if (autor == null)
            {
                return NotFound();
            }
            return autor;
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
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Autor autor)
        {
            if (id != autor.Id)
            {
                return BadRequest("El id del autor no coincide con el id de la URL.");
            }
            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/autores/{id}
        [HttpDelete("{id:int}")]
        public  async Task<IActionResult> Delete(int id)
        {
            var registroBorrado = await context.Autores.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (registroBorrado == 0)
            {
                return NotFound();
            }   
            return Ok();
        }
    }
}