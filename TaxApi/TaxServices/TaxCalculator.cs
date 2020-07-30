using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxApi.Models;

namespace TaxApi.TaxServices
{
    public class TaxCalculator
    {

        private ITaxCalculator TaxAPIEntity { get; set; }

        public TaxCalculator(ITaxCalculator taxAPIEntity)
        {
            TaxAPIEntity = taxAPIEntity;
        }

        public async Task<double> GetRate(APIModel aPIModel)
        {
            return await TaxAPIEntity.GetRate(aPIModel);
        }

        public async Task<double> GetTaxableAmount(APIModel aPIModel)
        {
            return await TaxAPIEntity.GetTaxableAmount(aPIModel);
        }
    }
}
