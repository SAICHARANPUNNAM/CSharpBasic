using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

class HeadlessExample
{
    [Test]
    public void VerifyHeadless()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("headless"); // run in headless mode

        IWebDriver driver = new ChromeDriver(options);

        driver.Navigate().GoToUrl("https://www.google.com");
        Console.WriteLine("Headless - Page Title: " + driver.Title);
        
        driver.Quit();
    }
}
