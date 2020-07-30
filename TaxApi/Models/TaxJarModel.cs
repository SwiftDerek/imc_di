using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;

namespace TaxApi.Models
{
    public class TaxJarModel : APIModel
    {

    }

    public class ReqRates : APIModel
    {
        // improper names for just to map for flurl and time's sake

        public string country { get; set; }
        public string zip { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string street { get; set; }

    }

    public class ReqTaxes : APIModel
    {
        public string FromCountry { get; set; }
        [JsonProperty("from_zip")]
        public string FromZip { get; set; }
        [JsonProperty("from_state")]
        public string FromState { get; set; }
        [JsonProperty("from_city")]
        public string FromCity { get; set; }
        [JsonProperty("from_street")]
        public string FromStreet { get; set; }
        [JsonProperty("to_country")]
        public string ToCountry { get; set; }
        [JsonProperty("to_zip")]
        public string ToZip { get; set; }
        [JsonProperty("to_state")]
        public string ToState { get; set; }
        [JsonProperty("to_city")]
        public string ToCity { get; set; }
        [JsonProperty("to_street")]
        public string ToStreet { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("shipping")]
        public double Shipping { get; set; }

    }

    public class ResRates : APIModel
    {
        [JsonProperty("rate")]
        public Rate Rate { get; set; }

    }

    public class Rate
    {
        [JsonProperty("combined_rate")]
        public double CombinedRate { get; set; }
    }

    public class ResTaxes : APIModel
    {
        [JsonProperty("tax")]
        public Tax Tax { get; set; }

    }

    public class Tax
    {
        [JsonProperty("amount_to_collect")]
        public double AmountToCollect { get; set; }
    }
}
