using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.pageObjects
{
    public class LoginPage
    {
        private IWebDriver dr;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public LoginPage(IWebDriver dr)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
            this.dr = dr;
            PageFactory.InitElements(dr, this);//this keyword refers current class object..
        }
        //write locators
        //In page object also there is one design subdesign pattern called page factory.. 
        //In pageobject factory instal two package pageobject and pageobject core..
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;
        //This is concept of "Encapsulation" in object oriented like hidding some details without exposing them..
        [FindsBy(How = How.CssSelector, Using = "#password")]
        private IWebElement password;
        [FindsBy(How = How.CssSelector, Using = ".text-info span:nth-child(1) input")]
        private IWebElement checkBox;
        [FindsBy(How = How.CssSelector, Using = "#signInBtn")]
        private IWebElement signInButton;
        public ProductsPage validLogin(string user, string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            checkBox.Click();
            signInButton.Click();
            return new ProductsPage(dr);
        }
        public IWebElement getUserName()
        {
            return username;
        }


    }
}
