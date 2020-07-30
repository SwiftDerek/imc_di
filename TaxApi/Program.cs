using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using TaxApi.Models;
using TaxApi.TaxServices;

namespace TaxApi
{
    class Program
    {
        static void Main(string[] args)
        {
            //TaxJar taxJar = new TaxJar();

            //ReqRates reqRates = new ReqRates()
            //{
            //    zip = "61822",
            //    state = "IL",
            //    city = "Champaign",
            //    country = "US",
            //    street = "1704 Bonnie Blair Dr."
            //};

            //ReqTaxes reqTaxes = new ReqTaxes()
            //{
            //    ToCountry = "US",
            //    ToZip = "61822",
            //    ToState = "IL",
            //    Shipping = 1.5,
            //    FromZip = "61882",
            //    FromCountry = "US",
            //    FromCity = "Weldon",
            //    FromState = "IL",
            //    FromStreet = "Lakewood Rd.",
            //    Amount = 655
            //};

            //TaxCalculator taxCalculator = new TaxCalculator(taxJar);

            //var rate = taxCalculator.GetRate(reqRates).GetAwaiter().GetResult();

            //var tax = taxCalculator.GetTaxableAmount(reqTaxes).GetAwaiter().GetResult();

            //Console.WriteLine(rate);
            //Console.WriteLine(tax);
        }
    }
}
