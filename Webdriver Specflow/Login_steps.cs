using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Webdriver_Specflow
{
    [Binding]
    public class LogIn_Steps
    {
        public IWebDriver driver;

        [Given(@"User is at the Login Page")]
        public void GivenUserIsAtTheHomePage()
        {
            driver = new ChromeDriver();
            driver.Url = "localhost:5000"; 
        }

        [When(@"User enter UserName and Password and Click on the LogIn button")]
        public void WhenUserEnterUserNameAndPassword()
        {
            PageObjectLogin pol = new PageObjectLogin(driver);
            pol.Login("user", "user");
        }


        [Then(@"User is at Home page")]
        public void ThenSuccessfulLogINMessageShouldDisplay()
        {
            Assert.IsTrue(driver.FindElement(By.CssSelector("body > div:nth-child(2) > h2")).Displayed);
            driver.Quit();
        }

    }
}
