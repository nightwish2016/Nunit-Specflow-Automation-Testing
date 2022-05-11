using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using NUnit.Framework;
using NunitSpecflowAutomation.WeatherServiceReference1;

namespace NunitSpecflowAutomation
{
   [Binding]
   public class StepsDefinition
    {
        [When(@"I  input Country name '(.*)' to get City")]
        public void WhenIInputCountryNameToGetCity(string p0)
        {
            GlobalWeatherSoapClient cl = new GlobalWeatherSoapClient();

            string city_ls = cl.GetCitiesByCountry(p0);
            Console.WriteLine(city_ls);
            if (!ScenarioContext.Current.ContainsKey("CityList"))
            {
                ScenarioContext.Current.Add("CityList", city_ls);
            }

        }


        [Then(@"The cities should be contains '(.*)'")]
        public void ThenTheCitiesShouldBeContains(string p0)
        {
            string citylist = ScenarioContext.Current.Get<string>("CityList");
            bool getExpectCity = false;
            if (citylist.Contains(p0))
            {
                getExpectCity = true;
            }

            Assert.IsTrue(getExpectCity);

        }

     


    }
}
