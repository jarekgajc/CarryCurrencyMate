using Common.Models.Observations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Common.Utils;

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
            string currencyPair = $"currencyPair={CurrencyUtils.ToPair(from, to)}";
            return await _sourceClient.Get<CurrentExchangeRate>($"{_baseUrl}/direct_fx/rates?{currencyPair}");
        }

        public async Task<CurrencyExchangeResponse> RequestsCurrencyExchange(CurrencyExchangeRequest request)
        {
            var body = new Queue<KeyValuePair<string, string>>();
            body.Enqueue(new KeyValuePair<string, string>("dryRun", request.DryRun.ToString()));
            if (request.DryRun)
            {
                if (request.SubmitId == null)
                {
                    throw new SourceClientException("SubmitId cannot be null");
                }
                else
                {
                    body.Enqueue(new KeyValuePair<string, string>("submitId", request.SubmitId));
                }
            }
            body.Enqueue(new KeyValuePair<string, string>("currencyPair", request.CurrencyPair));
            body.Enqueue(new KeyValuePair<string, string>("buySell", request.BuySell));
            body.Enqueue(new KeyValuePair<string, string>("volume", request.Volume));
            body.Enqueue(new KeyValuePair<string, string>("volumeCurrency", request.VolumeCurrency));
            body.Enqueue(new KeyValuePair<string, string>("ts", request.Ts.ToString()));
            return await _sourceClient.Post<CurrencyExchangeResponse>($"{_baseUrl}/direct_fx/exchanges", body);
        }
    }
}
