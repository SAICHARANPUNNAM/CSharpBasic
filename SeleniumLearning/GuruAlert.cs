using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace SeleniumLearning
{
    class GuruAlert
    {
        [Test]
        public void HandlingAlert()
        {
            IWebDriver dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Navigate().GoToUrl("https://demo.guru99.com/test/delete_customer.php");
            dr.FindElement(By.Name("cusid")).SendKeys("sai");
            dr.FindElement(By.Name("submit")).Click();
            IAlert alert = dr.SwitchTo().Alert();
            string alertMessage = alert.Text;
            Console.WriteLine(alertMessage);
            if (alertMessage == "Do you really want to delete this Customer?")
            {
                alert.Accept();
            }
            IAlert alert1 = dr.SwitchTo().Alert();
            string alertMessage1 = alert1.Text;
            Console.WriteLine(alertMessage1);
            if (alertMessage1 == "Customer Successfully Delete!")
            {
                alert1.Accept();
            }
            dr.Close();

            


        }
    }
}
