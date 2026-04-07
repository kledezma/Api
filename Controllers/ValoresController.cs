using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WebApi.Entidades;

namespace WebApi.Controllers
{
        [ApiController]
        [Route("api/valores")]
    public class ValoresController : ControllerBase
    {
       private readonly IRepositorioValores repositorioValores;
        private readonly ServicioTransient transient1;
        private readonly ServicioTransient transient2;
        private readonly ServicioScope scope1;
        private readonly ServicioScope scope2;
        private readonly ServicioSingleton single;

        public ValoresController(IRepositorioValores repositorioValores,
            ServicioTransient transient1 ,
            ServicioTransient transient2,
            ServicioScope scope1,
            ServicioScope scope2,
            ServicioSingleton single
            )
        {
            this.repositorioValores = repositorioValores;
            this.transient1 = transient1;
            this.transient2 = transient2;
            this.scope1 = scope1;
            this.scope2 = scope2;
            this.single = single;
        }

        [HttpGet ("servicios-tiempo-de-vida")]
        public IActionResult GetServiciosTiempoDeVida()
        {
            return Ok(new
            {
                Transients = new
                {
                    transient1 = transient1.ObtenerGuid,
                    transient2 = transient2.ObtenerGuid
                },
                Scopeds = new
                {
                    scope1 = scope1.ObtenerGuid,
                    scope2 = scope2.ObtenerGuid
                },
                single = single.ObtenerGuid
            }
            );
        }

        [HttpPost]
        public IActionResult Post(Valor valor)
        {
            repositorioValores.AgregarValor(valor);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<Valor> Get()
        {
            return repositorioValores.GetValores();
        }
    }
}
    