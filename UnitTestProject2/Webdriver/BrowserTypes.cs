using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestWebProject.Webdriver
{
    public class BrowserTypes
    {
        public enum BrowserType
        {
            Chrome
        }

        public static IWebDriver GetDriver(BrowserType type, int timeOutSec)
        {
            IWebDriver driver = null;

            switch (type)
            {
                case BrowserType.Chrome:
                    {
                        var service = ChromeDriverService.CreateDefaultService();
                        var option = new ChromeOptions();
                        option.AddArgument("disable-infobars");
                        //driver = new ChromeDriver(@"C:\Users\Pavel_Shyker\Downloads\chromedriver_win32", option, TimeSpan.FromSeconds(timeOutSec));
                        driver = new ChromeDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }
            }
            return driver;
        }
    }
}