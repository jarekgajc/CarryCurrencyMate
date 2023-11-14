using Common.Models.Observations;
using Common.Models.Sources.Auths;
using Common.Models.Sources.Walutomat;
using Common.Models.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Exchanges;
using System.Collections;
using Common.Utils;

namespace Common.Models.Exchangers.Sources
{
    internal class Walutomat : IExchangerSource
    {
        private readonly bool _dev;

        public SourceAuthType SourceAuthType => SourceAuthType.ApiKey;

        public Walutomat(bool dev)
        {
            _dev = dev;
        }

        public async Task RequestExchange(ExchangeRequest exchangeRequest)
        {
            WalutomatClient client = new WalutomatClient(_dev, exchangeRequest.Exchanger.SourceAuth.ApiKey!);

            CurrencyExchangeRequest currencyExchangeRequest = new CurrencyExchangeRequest()
            {
                CurrencyPair = CurrencyUtils.ToPair(exchangeRequest.From, exchangeRequest.To),
                BuySell = exchangeRequest.Type.ToString(),
                DryRun = exchangeRequest.DryRun,
                SubmitId = Guid.NewGuid().ToString(),
                Ts = exchangeRequest.Timestamp,
                Volume = exchangeRequest.Value.ToString("0.00"),
                VolumeCurrency = exchangeRequest.From.ToString()
            };

            CurrencyExchangeResponse response = await client.RequestsCurrencyExchange(currencyExchangeRequest);
            if (!response.Success || response.Result == null)
            {
                throw new SourceClientException(IResponse.GetErrorsDescriptions(response));
            }
        }
        
    }
}
