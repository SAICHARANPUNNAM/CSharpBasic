using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumLearning
{
    class BigBasketTryCatch
    {
        [Test]
        public void VerifyHeaderItems()
        {
            IWebDriver dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            try
            {



                dr.Navigate().GoToUrl("https://Bigbasket.com");
                IWebElement error = dr.FindElement(By.XPath("//span[text()='Ghee']"));
                error.Click();
            }
            catch(ElementClickInterceptedException ex) 

            {

                Console.WriteLine("ElementClickInterceptedException occurred: " + ex.Message);
                if(dr != null)
                {
                    Screenshot TakeScreenshot = ((ITakesScreenshot)dr).GetScreenshot();
                    string filePath = "D:\\QAScreenShot\\YoutubeScreenShot.Png";
                    //Screenshot screenshot = driver.GetScreenshot();
                    byte[] img = Convert.FromBase64String(TakeScreenshot.AsBase64EncodedString);
                    System.IO.File.WriteAllBytes(filePath, img);


                    Console.WriteLine($"Screenshot saved at: {filePath}");
                }
            }
           

        }
    }
}
