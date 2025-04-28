using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSelFramework.pageObjects
{
    public class CheckoutPage
    {
        private IWebDriver dr;
        public CheckoutPage(IWebDriver dr)
        {
            this.dr = dr;
            PageFactory.InitElements(dr,this);
        }
        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkoutCards;
        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement checkoutButton;
        public IList<IWebElement> getCards()
        {
            return checkoutCards;
        }
        public PurchasePage checkoutClick()
        {
            checkoutButton.Click();
            return new PurchasePage(dr);
        }
    }
}
