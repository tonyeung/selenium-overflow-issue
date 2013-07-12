using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
using Xunit;

namespace Selenium.Driver.Tests
{
    [Binding]
    public class SampleTestSteps
    {
        private IWebDriver driver;
        private string rootUrl = "http://localhost:6550/index.html";

        [BeforeScenario()]
        public void Setup()
        {
            driver = SeleniumServer.Start();
        }

        [AfterScenario()]
        public void TearDown()
        {
            SeleniumServer.Stop();
        }

        [Given(@"I am at the employees page")]
        public void GivenIAmAtTheEmployeesPage()
        {
            driver.Navigate().GoToUrl(rootUrl);
        }
        
        [When(@"I click the '(.*)' button")]
        public void WhenIClickTheButton(string buttonName)
        {

            System.Threading.Thread.Sleep(250);
            var element = driver.FindElement(By.Id(buttonName));
            element.Click();
        }

        [Then(@"I should see the employee '(.*)' message")]
        public void ThenIShouldSeeTheEmployeeMessage(string messageName)
        {
            Assert.DoesNotThrow(() =>
            {
                driver.FindElement(By.Id(messageName));
            });
        }

    }
}
