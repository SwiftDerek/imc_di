using Flurl.Http;
using Moq;
using System;
using System.Threading.Tasks;
using TaxApi.Models;
using TaxApi.TaxServices;
using Xunit;

namespace XUnitTestProject
{
    public class TaxServiceTest
    {
        private readonly Mock<ITaxCalculator> taxCalculator;

        public TaxServiceTest()
        {
            this.taxCalculator = new Mock<ITaxCalculator>();
        }

        [Theory]
        [InlineData("61822", "IL", "Champaign", "US", "1704 Bonnie Blair Dr.")]
        [InlineData("61822", "", "", "", "")]
        [InlineData("61822", "IL", "", "US", "")]
        public async void TaxServiceGetRate(string ziptest, string statetest, string citytest, string countrytest, string streettest)
        {
            ReqRates reqRates = new ReqRates()
            {
                zip = ziptest,
                state = statetest,
                city = citytest,
                country = countrytest,
                street = streettest
            };

            taxCalculator.Setup(x => x.GetRate(reqRates)).Returns(Task.FromResult(0.09));

            TaxCalculator taxService = new TaxCalculator(taxCalculator.Object);

            Assert.Equal(0.09, await taxService.GetRate(reqRates));
        }

        [Theory]
        [InlineData("61822", "IL", "Champaign", "US", "1704 Bonnie Blair Dr.")]
        [InlineData("61822", "", "", "", "")]
        [InlineData("61822", "IL", "", "US", "")]
        public async void TaxJarGetRate(string ziptest, string statetest, string citytest, string countrytest, string streettest)
        {
            ReqRates reqRates = new ReqRates()
            {
                zip = ziptest,
                state = statetest,
                city = citytest,
                country = countrytest,
                street = streettest
            };

            TaxJar taxJar = new TaxJar();

            Assert.Equal(0.09, await taxJar.GetRate(reqRates));
        }

        [Theory]
        [InlineData("US", "61822", "IL", 1.5, "61822", "US", "Weldon", "IL", "Lakewood Rd.", 655)]
        public async void TaxServiceGetTaxableAmount(string tocountry, string tozip, string tostate, double shipping, string fromzip, string fromcountry, string fromcity, string fromstate, string fromstreet, double amount)
        {
            ReqTaxes reqTaxes = new ReqTaxes()
            {
                ToCountry = tocountry,
                ToZip = tozip,
                ToState = tostate,
                Shipping = shipping,
                FromZip = fromzip,
                FromCountry = fromcountry,
                FromCity = fromcity,
                FromState = fromstate,
                FromStreet = fromstreet
            };

            taxCalculator.Setup(x => x.GetTaxableAmount(reqTaxes)).Returns(Task.FromResult(41.03));

            TaxCalculator taxService = new TaxCalculator(taxCalculator.Object);

            Assert.Equal(41.03, await taxService.GetTaxableAmount(reqTaxes));

        }

        [Theory]
        [InlineData("US", "61822", "IL", 1.5, "61822", "US", "Weldon", "IL", "Lakewood Rd.", 655)]
        public async void TaxJarGetTaxableAmount(string tocountry, string tozip, string tostate, double shipping, string fromzip, string fromcountry, string fromcity, string fromstate, string fromstreet, double amount)
        {
            ReqTaxes reqTaxes = new ReqTaxes()
            {
                ToCountry = tocountry,
                ToZip = tozip,
                ToState = tostate,
                Shipping = shipping,
                FromZip = fromzip,
                FromCountry = fromcountry,
                FromCity = fromcity,
                FromState = fromstate,
                FromStreet = fromstreet
            };

            TaxJar taxJar = new TaxJar();

            // Not getting right result from post request? Seems it's picking up the get request rate. Weird. 

            Assert.Equal(41.03, await taxJar.GetTaxableAmount(reqTaxes));
        }
    }
}
