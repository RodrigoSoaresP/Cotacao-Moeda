using CotacaoMoeda.Infra.Entity;
using CotacaoMoeda.Modelo;
using CotacaoMoeda.Negocio.CotacaoNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CotacaoMoeda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotacaoController : ControllerBase
    {

        private readonly ICotacaoNegocio _cotacaoNegocio;

        public CotacaoController(ICotacaoNegocio cotacaoNegocio)
        {
            _cotacaoNegocio = cotacaoNegocio;
        }

        [HttpPost]
        public async Task Incluir([FromBody] Cotacao cotacao)
        {
            cotacao.DataHoraCotacao = DateTime.Now;

            if (ModelState.IsValid)
            {
                await _cotacaoNegocio.Incluir(cotacao);
            }
        }

        //[HttpGet]
        //public async Task<List<Cotacao>> Get()
        //{
        //    return await _cotacaoNegocio.ObterLista();
        //}

        [HttpGet]
        public async Task<List<Cotacao>> Get() => await _cotacaoNegocio.ObterLista();
    }
}
