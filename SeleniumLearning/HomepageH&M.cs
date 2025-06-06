using OpenQA.Selenium;
using System.ComponentModel.DataAnnotations;

namespace SeleniumLearning
{
    class HomepageH_M : BaseClass
    {

        [Test]
        public void Test1()
        {
            Thread.Sleep(2000);
            dr.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
            Thread.Sleep(5000);
            dr.FindElement(By.XPath("(//a[text()='Ladies'])[1]")).Click();
            Thread.Sleep(5000);

        }
        [Test]
        public void learnRadio()
        {

            IWebElement Operaelement = dr.FindElement(By.XPath("//input[@type='radio'][3]"));
            if (Operaelement.Selected == false)
            {
                Operaelement.Click();
                Thread.Sleep(5000);
                Assert.True(Operaelement.Selected, "The radio button not selected.");

            }

        }
        [Test]
        public void learnRadioMozilla()
        {

            IWebElement mozillaElement = dr.FindElement(By.XPath("//input[@type='radio'][2]"));
            if (mozillaElement.Selected == false)
            {
                mozillaElement.Click();
                Thread.Sleep(5000);
                Assert.True(mozillaElement.Selected, "The radio button not selected.");

            }

        }
        [Test]
        public void VerifyGetAttribute()
        {
            IWebElement txtSrch = dr.FindElement(By.XPath("(//input[@class='psxM XAI6'])[3]"));
            string mLength = txtSrch.GetAttribute("maxlength");
        }
    }
}