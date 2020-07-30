using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxApi.Models;

namespace TaxApi.TaxServices
{
    public interface ITaxCalculator
    {

        public string URL { get; set; }

        abstract public Task<double> GetRate(APIModel aPIModel);

        abstract public Task<double> GetTaxableAmount(APIModel aPIModel);
    }
}
