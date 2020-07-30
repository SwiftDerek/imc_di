using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaxApi.Models;
using TaxApi.TaxServices;

namespace TaxApi.TaxServices
{
    public class TaxJar : ITaxCalculator
    {

        public string URL { get; set; }
        public string ApiKey { get; set; }


        public TaxJar()
        {
            URL = "https://api.taxjar.com/v2";
            ApiKey = "5da2f821eee4035db4771edab942a4cc";
        }

        public async Task<double> GetRate(APIModel aPIModel)
        {
            // TODO: Use generic parameter i.e. ReqRates not APIModel

            string endpoint = "rates";

            ResRates response = await URL.AppendPathSegment(endpoint).SetQueryParams(aPIModel).WithOAuthBearerToken(ApiKey).GetJsonAsync<ResRates>();

            return response.Rate.CombinedRate;
        }

        public async Task<double> GetTaxableAmount(APIModel aPIModel)
        {
            // TODO: Use generic parameter i.e. ReqTaxes not APIModel

            string endpoint = "taxes";

            ResTaxes response = await URL.AppendPathSegment(endpoint).WithOAuthBearerToken(ApiKey).PostJsonAsync(aPIModel).ReceiveJson<ResTaxes>();

            return response.Tax.AmountToCollect;
        }
    }
}
