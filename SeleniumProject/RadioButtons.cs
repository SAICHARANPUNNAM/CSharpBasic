using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLearning
{
    public class RadioButtons
    {
        IWebDriver dr;
        [SetUp]
        public void StartBrowser()
        {
            dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            dr.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");
        }
        [Test]
        public void RadioButton_Click()
        {
            IList<IWebElement> buttonClick = dr.FindElements(By.CssSelector("input[type='radio']"));
            foreach (IWebElement popDisplay in buttonClick)
            {
                if (popDisplay.GetAttribute("value").Equals("user"))

                {
                    popDisplay.Click();
                }
            }
            // WebDriverWait wait = new WebDriverWait(dr, TimeSpan.FromSeconds(8));
            // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".modal-body")));

            WebDriverWait wait = new WebDriverWait(dr, TimeSpan.FromSeconds(8));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#okayBtn")));
            string popMessage = dr.FindElement(By.CssSelector(".modal-body")).Text;
            Console.WriteLine(popMessage);
            dr.FindElement(By.CssSelector("#okayBtn")).Click();
            bool userButtonClick = dr.FindElement(By.Id("usertype")).Selected;
            // To verify boolen assertions we have to us "That is True"
            Assert.That(userButtonClick, Is.True);
            dr.Close();
        }
    }
}
