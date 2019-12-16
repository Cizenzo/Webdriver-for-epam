using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Webdriver_Specflow
{
    class PageObjectNewPr
    {
        private IWebDriver driver;
        private Actions builder;
        public PageObjectNewPr(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement ProdNameField
        {
            get
            {
                return this.driver.FindElement(By.Id("ProductName"));
            }
        }
        private IWebElement CategoryEl
        {
            get
            {
                return this.driver.FindElement(By.Id("CategoryId"));
            }
        }
        private IWebElement SuplierEl
        {
            get
            {
                return this.driver.FindElement(By.Id("SupplierId"));
            }
        }
        private IWebElement UnitEl
        {
            get
            {
                return this.driver.FindElement(By.Id("UnitPrice"));
            }
        }
        private IWebElement SendBtn
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@type='submit']"));
            }
        }
        public void FillProd(string name, string cat, string sup, string unit)
        {
            builder = new Actions(this.driver);
            builder.SendKeys(ProdNameField, name).SendKeys(CategoryEl, cat).SendKeys(SuplierEl, sup).SendKeys(UnitEl, unit).Click(SendBtn).Perform();
        }
    }
}
