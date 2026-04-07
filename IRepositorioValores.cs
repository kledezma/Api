using WebApi.Entidades;

namespace WebApi
{
    public interface IRepositorioValores
    {
        void AgregarValor(Valor valor);
        IEnumerable<Valor> GetValores();
    }
}
