using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Driver.Tests
{
    public class SeleniumServer
    {
        private static IWebDriver driver;

        public static IWebDriver Start()
        {
            if (IsStarted)
                return driver;

            IsStarted = true;
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            return driver;
        }

        public static void Stop()
        {
            try
            {
                driver.Quit();
                driver.Dispose();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("has exited") == false)
                {
                    throw ex;
                }
            }

            IsStarted = false;
        }

        public static bool IsStarted { get; set; }
    }
}
