using MicrosserviceBase;
using Newtonsoft.Json.Linq;
using RestSharp;
using FluxoCaixa.Domain;
using FluxoCaixa.Domain.Entity;

namespace FluxoCaixa.Infra.APIYahoo
{
    public class FluxoCaixaAPIRepository : IFluxoCaixaAPIRepository
    {
        #region Public Methods

        FluxoCaixaYahooFinance IFluxoCaixaAPIRepository.BuscarDados()
        {
            var options = new RestClientOptions("https://query2.finance.yahoo.com")
            {
                MaxTimeout = -1,
            };

            var client = new RestClient(options);

            var request = new RestRequest($"/v8/finance/chart/PETR4.SA", Method.Get);

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new GuidetiException($"Erro buscando dados. Codigo: {response.StatusCode}, Mensagem: {response.Content}");
            }

            dynamic dados = JObject.Parse(response.Content);

            Int32[] data = ((JArray)dados.chart.result[0].timestamp).Select(x => (Int32)x).ToArray();
            decimal?[] valor = ((JArray)dados.chart.result[0].indicators.quote[0].open).Select(x => (decimal?)x).ToArray();

            return new FluxoCaixaYahooFinance(data, valor);
        }

        #endregion Public Methods
    }
}