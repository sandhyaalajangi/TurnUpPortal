using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace TurnUpLogin
{
    
    public class HomePage
    {
        //navigate to time and material module 
        public void GoToTMPage(IWebDriver driver)
        {

            //Identify Administration tab and click

            IWebElement administration = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul[1]/li[5]/a"));
            administration.Click();

            //Identify Time and material module and click
            IWebElement moduleLink = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            moduleLink.Click();

        }

        }
}
