using Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Entidades;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public LibrosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Libro>> Get()
        {
            return await context.Libros.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>> Get(int id)
        {
            var libro = await context.Libros.Include(x => x.Autor).FirstOrDefaultAsync(x => x.Id == id);

            if (libro == null)
            {
                return NotFound();
            }

            return libro;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Libro libro)
        {
            var existeAutor = await context.Autores.AnyAsync(x => x.Id == libro.AutorId);
            if (!existeAutor)
            {
                return BadRequest($"No existe un autor con el id {libro.AutorId}");
            }
            context.Add(libro);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Libro libro)
        {
            var autorExiste = await context.Autores.AnyAsync(x => x.Id == libro.AutorId);
            if (!autorExiste)
            {
                return BadRequest($"No existe un autor con el id {libro.AutorId}");
            }
            if (id != libro.Id)
            {
                return BadRequest("El id del libro no coincide con el id de la URL.");
            }

            context.Update(libro);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var libro = await context.Libros.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (libro == 0)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
