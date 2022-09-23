using CotacaoMoeda.Modelo;
using CotacaoMoeda.Servico.Model;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace CotacaoMoeda.Servico
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly HttpClient _httpClient;

        public Worker(ILogger<Worker> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            _httpClient = httpClient.CreateClient();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");  

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Serviço executado às { DateTime.Now}");

                CotacaoMercadoRetorno cotacaoMercadoRetorno = await ObterCotacaoMercado();
                Cotacao cotacao = ConverterCotacaoMercadoRetornoParaCotacao(cotacaoMercadoRetorno);
                await InserirCotacaoBancoDeDadosInterno(cotacao);

                await Task.Delay(35000, stoppingToken);
            }
        }
        private async Task<CotacaoMercadoRetorno> ObterCotacaoMercado()
        {
            HttpResponseMessage retorno = await _httpClient.GetAsync($"http://economia.awesomeapi.com.br/json/last/USD-BRL");

            if (retorno.IsSuccessStatusCode)
            {
               return JsonConvert.DeserializeObject<CotacaoMercadoRetorno>(await retorno.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception(retorno.ReasonPhrase);
            }
        }
        private async Task InserirCotacaoBancoDeDadosInterno(Cotacao cotacao)
        {
            HttpResponseMessage retorno = await _httpClient.PostAsJsonAsync($"https://localhost:7134/api/Cotacao", cotacao);
            if (retorno.IsSuccessStatusCode)
            {

            }
            else
            {
                throw new Exception(retorno.ReasonPhrase);
            }
        }
        private Cotacao ConverterCotacaoMercadoRetornoParaCotacao(CotacaoMercadoRetorno cotacaoMercadoRetorno)
        {
            Cotacao cotacao = new Cotacao();
            cotacao.Nome = cotacaoMercadoRetorno.USDBRL.name;
            cotacao.ValorCompra = Convert.ToDecimal(cotacaoMercadoRetorno.USDBRL.bid);
            cotacao.ValorVenda = Convert.ToDecimal(cotacaoMercadoRetorno.USDBRL.ask);

            return cotacao;
        }

    }
}