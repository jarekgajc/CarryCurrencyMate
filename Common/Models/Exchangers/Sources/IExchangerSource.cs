using Common.Models.Observations;
using Common.Models.Observers.Sources;
using Common.Models.Observers;
using Common.Models.Sources.Auths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Exchanges;

namespace Common.Models.Exchangers.Sources
{
    public interface IExchangerSource
    {
        SourceAuthType SourceAuthType { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exchangeRequest"></param>
        /// <exception cref="SourceClientException">Thrown if anything fails</exception>
        /// <returns></returns>
        Task RequestExchange(ExchangeRequest exchangeRequest);

        public static IExchangerSource GetInstance(ExchangeSource source)
        {
            return source switch
            {
                ExchangeSource.WalutomatDev => new Walutomat(true),
                ExchangeSource.Walutomat => new Walutomat(false),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
