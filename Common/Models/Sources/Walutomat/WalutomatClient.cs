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
        private readonly SourceClient _sourceClient = new SourceClient();

        public WalutomatClient(string apiKey) {
            _sourceClient.SetHeaderAuthorization("X-API-Key", apiKey);
        }

        public async Task<CurrentExchangeRate> GetCurrentExchangeRate(Currency from, Currency to)
        {
            string currencyPair = $"currencyPair={from}{to}";
            return await _sourceClient.Get<CurrentExchangeRate>($"https://api.walutomat.pl/api/v2.0.0/direct_fx/exchanges?{currencyPair}");
        }
    }
}
