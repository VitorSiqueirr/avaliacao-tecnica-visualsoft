﻿using System.Net.Http;
using System.Threading.Tasks;
using avaliacao_tecnica_visualsoft.Utils;
using Newtonsoft.Json.Linq;

namespace avaliacao_tecnica_visualsoft.Services
{
    public class CnpjService : ICnpjService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<JObject> ConsultarCnpj(string cnpj)
        {
            string cnpjLimpo = FornecedorHelper.LimparCnpj(cnpj);
            string url = $"https://receitaws.com.br/v1/cnpj/{cnpjLimpo}";

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return JObject.Parse(responseBody);
        }
    }
}
