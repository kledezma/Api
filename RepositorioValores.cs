using WebApi.Entidades;

namespace WebApi
{
    public class RepositorioValores : IRepositorioValores
    {

        public IEnumerable<Valor> GetValores()
        {
            return new List<Valor>
            {
                new Valor{Id = 1, Nombre= "Valor 1"},
                new Valor{Id = 2, Nombre= "Valor 2"}
            };
        }

        public void AgregarValor(Valor valor)
        {
            // Implementación para agregar un valor
        }
    }
}
