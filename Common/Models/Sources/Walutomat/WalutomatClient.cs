using Common.Models.Observations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Sources.Walutomat
{
    internal class WalutomatClient
    {
        private readonly string _baseUrl;
        private readonly SourceClient _sourceClient = new SourceClient();

        public WalutomatClient(bool dev, string apiKey) {
            _baseUrl = dev ? "https://api.walutomat.dev/api/v2.0.0" : "https://api.walutomat.pl/api/v2.0.0";
            _sourceClient.SetHeaderAuthorization("X-API-Key", apiKey);
        }

        public async Task<CurrentExchangeRate> GetCurrentExchangeRate(Currency from, Currency to)
        {
            string currencyPair = $"currencyPair={from}{to}";
            return await _sourceClient.Get<CurrentExchangeRate>($"{_baseUrl}/direct_fx/rates?{currencyPair}");
        }
    }
}
