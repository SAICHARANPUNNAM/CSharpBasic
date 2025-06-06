using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumLearning
{
    class WebTable
    {
        public IWebDriver dr = null;
        [SetUp]
        public void setup()
        {
            dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Navigate().GoToUrl("https://www.moneycontrol.com/stocks/marketinfo/marketcap/bse/C.html");
            dr.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }
        [Test]
        public void VerifyTableInTop()
        {
            IWebDriver dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Navigate().GoToUrl("https://www.moneycontrol.com/stocks/marketinfo/marketcap/bse/C.html");
            Thread.Sleep(10000);
            IWebElement FirstCompany = dr.FindElement(By.XPath("(//tr//td//a[@class='undefined'])[1]"));
            Console.WriteLine(FirstCompany.Text);
            Thread.Sleep(2000);
            IWebElement FivthCompany = dr.FindElement(By.XPath("(//tr//td//a[@class='undefined'])[5]"));
            Console.WriteLine(FivthCompany.Text);
            dr.Close();



        }
        [Test]
        public void GetNameOfCompany()
        {
            Thread.Sleep(10000);

            Console.WriteLine(GetCompanyNameByRank(5));

        }

        public string GetCompanyNameByRank(int rank)
        {
            IWebElement nthCompanyName = dr.FindElement(By.XPath("//table[@class='Topfilter_web_tbl_indices__Wa1Sj undefined']/tbody/tr[" + rank + "]/td[1]/a"));


            return nthCompanyName.Text;

        }


        [TearDown]
        public void Cleanup()
        {
            dr.Close();
        }
    }
}
