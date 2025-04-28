using CSharpSelFramework.pageObjects;
using CSharpSelFramework.Utilities;
using OpenQA.Selenium;

namespace CSharpSelFramework
{
    class UdemyLoginPage : Base
    {


        [Test]
        //[TestCase("rahulshettyacademy","learning")]
        //[TestCase("saicharan", "Charansai@0011")]
        [TestCaseSource("AddTestDataConfig")]

        public void EndToEndFlow(string username, string password)
        {
            string[] expectedProducts = { "iphone X", "Nokia Edge", "Blackberry" }; // Fixed typo in variable name
            string[] actualProducts = new string[3];
            LoginPage loginPage = new LoginPage(getDriver());
            //ProductsPage productPage = loginPage.validLogin("rahulshettyacademy", "learning");
            ProductsPage productPage = loginPage.validLogin(username, password);
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
            PurchasePage purchasePage = checkoutPage.checkoutClick();
            purchasePage.getLocationEnter().SendKeys("Ind");
            purchasePage.waitForElementDisplay();
            purchasePage.clickOnElements();


            string successTxt = dr.FindElement(By.CssSelector("div.alert ")).Text;
            Console.WriteLine(successTxt);
            // now we will check success test present or not
            StringAssert.Contains("Success", successTxt);
            Thread.Sleep(3000);
            dr.Close();
        }
        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData("rahulshettyacademy", "learning");
            yield return new TestCaseData("sai charan", "charansai");
            yield return new TestCaseData("rahulshademy", "learning");
        }
    }
}
