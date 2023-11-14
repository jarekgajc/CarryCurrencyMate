using Common.Models.Observations;
using Common.Models.Sources;
using Common.Models.Sources.Auths;
using Common.Models.Sources.Walutomat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Observers.Sources
{
    internal class Walutomat : IObserverSource
    {
        private readonly bool _dev;

        public SourceAuthType SourceAuthType => SourceAuthType.ApiKey;
        
        public Walutomat(bool dev)
        {
            _dev = dev;
        }

        public async Task<Observation> GetObservation(ObservationQuery query)
        {
            Observation observation = query.ToObservationBase();
            WalutomatClient client = new WalutomatClient(_dev, query.Observer.SourceAuth.ApiKey!);
            DateTime dateTime = DateTime.UtcNow;

            observation.ExchangeRates = (await Task.WhenAll( query.Currencies.Select(async currency =>
            {
                CurrentExchangeRate currentExchangeRate = await client.GetCurrentExchangeRate(query.BaseCurrency, currency);
                if(!currentExchangeRate.Success || currentExchangeRate.Result == null)
                {
                    throw new SourceClientException(IResponse.GetErrorsDescriptions(currentExchangeRate));
                }
                
                return new ExchangeRate
                {
                    Currency = currency,
                    Values = new List<ExchangeRateValue>
                    {
                        new ExchangeRateValue
                        {
                            Buy = decimal.Parse(currentExchangeRate.Result.BuyRate),
                            Sell = decimal.Parse(currentExchangeRate.Result.SellRate),
                            Time = dateTime
                        }
                    }
                };
            }))).ToList();

            return observation;
        }
    }
}
