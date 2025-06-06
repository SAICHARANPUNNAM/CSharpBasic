using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.WebDriver;
using System.IO;

namespace SeleniumLearning
{
    class YoutubeScreenshot
    {
        

        [Test]
        public void GetScreenshot()
        {
            IWebDriver dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            try
            {
                dr.Navigate().GoToUrl("https://www.youtube.com/");
                dr.FindElement(By.Name("search_query")).SendKeys("Telugu Comedy scenes");
                dr.FindElement(By.XPath("(//button[@aria-label='Search'])[1]")).Click();
                dr.FindElement(By.XPath("(//ytd-video-renderer[@class='style-scope ytd-item-section-renderer']/div/ytd-thumbnail/a)[1]")).Click();
                Thread.Sleep(2000);
                Screenshot TakeScreenshot = ((ITakesScreenshot)dr).GetScreenshot();
                string filePath = "D:\\QAScreenShot\\YoutubeScreenShot.Png";
                //Screenshot screenshot = driver.GetScreenshot();
                byte[] img = Convert.FromBase64String(TakeScreenshot.AsBase64EncodedString);
                System.IO.File.WriteAllBytes(filePath, img);


                Console.WriteLine($"Screenshot saved at: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            dr.Close();
        }
    }
}