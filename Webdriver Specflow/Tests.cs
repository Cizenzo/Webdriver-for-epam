using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace WebdriverAdvanced
{
    [TestClass]
    public class Tests
    {

        static IWebDriver driver;
        [TestMethod]
        public void LogIn()
        {
            driver = new ChromeDriver();
            driver.Url = "localhost:5000";
            PageObjectLogin pol = new PageObjectLogin(driver);
            pol.Login("user", "user");
            Assert.IsTrue(driver.FindElement(By.CssSelector("body > div:nth-child(2) > h2")).Displayed);
            driver.Quit();
        }

        [TestMethod]
        public void AddProduct()
        {
            driver = new ChromeDriver();
            driver.Url = "localhost:5000";
            PageObjectLogin pol = new PageObjectLogin(driver);
            pol.Login("user", "user");
            PageObjectHome poh = new PageObjectHome(driver);
            poh.GoToAllProd();

            PageObjectAllPr pal = new PageObjectAllPr(driver);
            pal.NewProd();

            PageObjectNewPr ponp = new PageObjectNewPr(driver);
            ponp.FillProd("Abra", "Condiments", "Tokyo Traders", "1");
            Assert.IsTrue(driver.Url.Equals("http://localhost:5000/Product"));
            driver.Quit();
        }

        [TestMethod]
        public void CheckProduct()
        {
            driver = new ChromeDriver();
            driver.Url = "localhost:5000";
            IWebElement element = driver.FindElement(By.Id("Name"));
            element.SendKeys("user");
            element = driver.FindElement(By.Id("Password"));
            element.SendKeys("user");
            element = driver.FindElement(By.CssSelector(".btn"));
            element.Click();
            driver.Url = "http://localhost:5000/Product";
            Assert.IsTrue(driver.Url.Equals("http://localhost:5000/Product"));
            element = driver.FindElement(By.XPath("//tr/td/a[text()='Abra']"));
            element.Click();
            element = driver.FindElement(By.Id("ProductName"));
            Assert.AreEqual(element.GetAttribute("value"), "Abra");
            element = driver.FindElement(By.Id("UnitPrice"));
            Assert.AreEqual(element.GetAttribute("value"), "1,0000");
            element = driver.FindElement(By.Id("CategoryId"));
            SelectElement select = new SelectElement(element);
            Assert.AreEqual(select.SelectedOption.Text, "Condiments");
            element = driver.FindElement(By.Id("SupplierId"));
            select = new SelectElement(element);
            Assert.AreEqual(select.SelectedOption.Text, "Tokyo Traders");
            driver.Quit();
        }

        [TestMethod]
        public void LogOutcheck()
        {
            driver = new ChromeDriver();
            driver.Url = "localhost:5000";
            PageObjectLogin pol = new PageObjectLogin(driver);
            pol.Login("user", "user");
            PageObjectHome poh = new PageObjectHome(driver);
            poh.LogOut();
            Assert.IsTrue(driver.Url.Equals("http://localhost:5000/Account/Login"));
            driver.Quit();
        }
    }
}
