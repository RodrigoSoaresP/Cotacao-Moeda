using CotacaoMoeda.Modelo;

namespace CotacaoMoeda.Negocio.CotacaoNegocio
{
    public interface ICotacaoNegocio
    {

        Task Incluir(Cotacao cotacao);
        Task<List<Cotacao>> ObterLista();
    }
}
