using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.pageObjects
{
    public class PurchasePage
    {
        private IWebDriver dr;

        public PurchasePage(IWebDriver dr)
        {
            this.dr = dr;
            PageFactory.InitElements(dr, this);
        }
        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement locationEnter;
        [FindsBy(How = How.LinkText, Using = "India")]
        private IWebElement clickDropDown;
        [FindsBy(How = How.CssSelector, Using = "label[for='checkbox2']")]
        private IWebElement clickOnCheckBox;
        [FindsBy(How = How.CssSelector, Using = "input[value='Purchase']")]
        private IWebElement purchaseButton;
        public IWebElement getLocationEnter()
        {
            return locationEnter;
        }
        public void waitForElementDisplay()
        {
            WebDriverWait wait = new WebDriverWait(dr, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
        }
        public void clickOnElements()
        {
            clickDropDown.Click();
            clickOnCheckBox.Click();
            purchaseButton.Click();
        }
    }
}
