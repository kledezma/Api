using WebApi.Entidades;

namespace WebApi
{
    public class RepositorioValoresOracle : IRepositorioValores
    {

        private List<Valor> _valores;

        public RepositorioValoresOracle()
        {
            _valores = new List<Valor>
            {
                new Valor{Id = 1, Nombre= "Valor 1 Oracle"},
                new Valor{Id = 2, Nombre= "Valor 2 Oracle"}
            };
        }

        public IEnumerable<Valor> GetValores()
        {
            return _valores;
        }

        public void AgregarValor(Valor valor)
        {
            _valores.Add(valor);
        }
    }
}

