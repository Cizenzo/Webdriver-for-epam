using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace WebdriverAdvanced
{
    class PageObjectHome
    {
        private IWebDriver driver;
        private Actions builder;
        public PageObjectHome(IWebDriver driver)
        {
            this.driver = driver;
        }


        private IWebElement AllProdBtn
        {
            get
            {
                return this.driver.FindElement(By.XPath("//li/*[@href='/Product']"));
            }
        }
        private IWebElement LogOutBtn
        {
            get
            {
                return this.driver.FindElement(By.XPath("//li/a[@href='/Account/Logout']"));
            }
        }
        public void GoToAllProd()
        {
            builder = new Actions(this.driver);
            builder.Click(AllProdBtn).Perform();
        }
        public void LogOut()
        {
            builder = new Actions(this.driver);
            builder.Click(LogOutBtn).Perform();
        }
    }
}
