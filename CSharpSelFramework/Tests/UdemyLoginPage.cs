using CSharpSelFramework.pageObjects;
using CSharpSelFramework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpSelFramework
{
    class UdemyLoginPage : Base
    {


        [Test]
        public void EndToEndFlow()
        {
            string[] expectedProducts = { "iphone X", "Nokia Edge", "Blackberry" }; // Fixed typo in variable name
            string[] actualProducts = new string[3];
            LoginPage loginPage = new LoginPage(getDriver());
            ProductsPage productPage = loginPage.validLogin("rahulshettyacademy", "learning");
            productPage.waitForPageDisplay();
            // loginPage.getUserName().SendKeys("rahulshettyacademy");

            IList<IWebElement> products = productPage.getCards();
            foreach (IWebElement product in products)
            {

                if (expectedProducts.Contains(product.FindElement(productPage.getCardTitle()).Text)) // Fixed typo in variable name
                {

                    // IWebElement button = product.FindElement(By.CssSelector(".card-footer button"));
                    //((IJavaScriptExecutor)dr).ExecuteScript("arguments[0].click();", button);
                    //IJavaScriptExecutor js = (IJavaScriptExecutor)dr;
                    //js.ExecuteScript("arguments[0].click();", button);
                    product.FindElement(productPage.addToCartButton()).Click();
                }
                Console.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
            }
            CheckoutPage checkoutPage = productPage.checkout();

            IList<IWebElement> checkoutList = checkoutPage.getCards();
            for (int i = 0; i < checkoutList.Count; i++)
            {
                actualProducts[i] = checkoutList[i].Text;

            }
            Assert.AreEqual(expectedProducts, actualProducts);
            // now click on checkout
            checkoutPage.checkoutClick();
            dr.FindElement(By.Id("country")).SendKeys("Ind");
            WebDriverWait wait = new WebDriverWait(dr, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            dr.FindElement(By.LinkText("India")).Click();
            dr.FindElement(By.CssSelector("label[for='checkbox2']")).Click();
            dr.FindElement(By.CssSelector("input[value='Purchase']")).Click();
            string successTxt = dr.FindElement(By.CssSelector("div.alert ")).Text;
            Console.WriteLine(successTxt);
            // now we will check success test present or not
            StringAssert.Contains("Success", successTxt);
            Thread.Sleep(3000);
            dr.Close();
        }
    }
}
