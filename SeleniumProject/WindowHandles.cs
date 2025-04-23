using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumProject
{
    public class WindowHandles
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        IWebDriver dr;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        [SetUp]
        public void StartBrowser()
        {
            dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            dr.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");

        }
        [Test]
        public void VerifyWindowHandle()
            
        {
            string verifyMail = "mentor@rahulshettyacademy.com";
            dr.FindElement(By.CssSelector(".blinkingText")).Click();
            string parentWindow = dr.CurrentWindowHandle;
            Assert.AreEqual(2, dr.WindowHandles.Count);
            string childWindow = dr.WindowHandles[1];
            dr.SwitchTo().Window(childWindow);
            Console.WriteLine(dr.FindElement(By.CssSelector(".red")).Text);
            string text = dr.FindElement(By.CssSelector(".red")).Text;
            // Please email us at mentor@rahulshettyacademy.com with below template to receive response
            string[] splitedTxt = text.Split("at");
            Console.WriteLine(splitedTxt[1]);
            Console.WriteLine(splitedTxt[1].Trim());
            string[] trimmedTxt = splitedTxt[1].Trim().Split(" ");
            Console.WriteLine(trimmedTxt[0]);
            Assert.That(trimmedTxt[0], Is.EqualTo(verifyMail));
            //dr.SwitchTo().DefaultContent(); its not working--- its works on iframes..
            dr.SwitchTo().Window(parentWindow);
            dr.FindElement(By.CssSelector("#username")).SendKeys(trimmedTxt[0]);


        }
    }
}
