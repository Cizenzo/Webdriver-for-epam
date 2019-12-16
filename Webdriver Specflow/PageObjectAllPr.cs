using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Webdriver_Specflow
{
    class PageObjectAllPr
    {
        private IWebDriver driver;
        private Actions builder;
        public PageObjectAllPr(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement NewProdBtn
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[2]/a"));
            }
        }
        public void NewProd()
        {
            builder = new Actions(this.driver);
            builder.Click(NewProdBtn).Perform();
        }
    }
}
