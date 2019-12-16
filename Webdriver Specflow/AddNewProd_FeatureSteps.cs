using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace Webdriver_Specflow
{
    [Binding]
    public class AddNewProd_FeatureSteps
    {
        static IWebDriver driver;
        [Given(@"user is successfully login")]
        public void GivenUserIsAtTheHomePage()
        {
            driver = new ChromeDriver();
            driver.Url = "localhost:5000";
            PageObjectLogin pol = new PageObjectLogin(driver);
            pol.Login("user", "user");
            
        }
        
        [When(@"User click on All products")]
        public void WhenUserClickOnAllProducts()
        {
            PageObjectHome poh = new PageObjectHome(driver);
            poh.GoToAllProd();
        }
        
        [When(@"user click on create new")]
        public void WhenUserClickOnCreateNew()
        {
            PageObjectAllPr pal = new PageObjectAllPr(driver);
            pal.NewProd();
        }
        
        [When(@"user fill enought fields and user click send")]
        public void WhenUserFillEnoughtFields()
        {
            PageObjectNewPr ponp = new PageObjectNewPr(driver);
            ponp.FillProd("Abra", "Condiments", "Tokyo Traders", "1");
        }
        
        [Then(@"new product successfully added")]
        public void ThenNewProductSuccessfullyAdded()
        {
            Assert.IsTrue(driver.Url.Equals("http://localhost:5000/Product"));
            IWebElement element = driver.FindElement(By.XPath("//tr/td/a[text()='Abra']"));
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
    }
}
