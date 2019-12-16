using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace WebdriverAdvanced
{
    class PageObjectLogin
    {
        private IWebDriver driver;
        private Actions builder;
        public PageObjectLogin(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement NameField
        {
            get
            {
                return this.driver.FindElement(By.Id("Name"));
            }
        }
        private IWebElement PswdField
        {
            get
            {
                return this.driver.FindElement(By.Id("Password"));
            }
        }
        private IWebElement Buttn
        {
            get
            {
                return this.driver.FindElement(By.CssSelector(".btn"));
            }
        }
        public void Login(string name, string pswd)
        {
            builder = new Actions(this.driver);
            builder.SendKeys(NameField, name).SendKeys(PswdField, pswd).Click(Buttn).Perform();
        }
    }
}
