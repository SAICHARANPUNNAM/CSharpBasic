using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
 // Assuming you're using Xunit for testing

public class ChromeDriverTests
{
    [Test]  // Marking the method as a test
    public void GetAddArguments()
    {
        // Create Chrome options to launch Chrome in incognito mode
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("incognito");
        Thread.Sleep(5000);
        // Initialize the ChromeDriver with the options
        using (IWebDriver driver = new ChromeDriver(options))
        {
            // Navigate to the Google website
            driver.Navigate().GoToUrl("https://google.com");
            
        }
    }
}
