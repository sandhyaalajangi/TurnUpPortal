using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace TurnUpLogin
{
    public class LoginPage
    {
        //login successfully into portal
        public void LoginActions(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();


            //launch TurnUp portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

            //Identify username textbox and enter valid username
            IWebElement username = driver.FindElement(By.Id("UserName"));
            username.SendKeys("hari");

            //Identify password textbox and enter valid password
            IWebElement password = driver.FindElement(By.Id("Password"));
            password.SendKeys("123123");
            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[4]/div/div/section/form/div[3]/input[1]"));
            loginButton.Click();

            //check if login successful
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));


            if (helloHari.Text == "Hello hari!")
            {
                Console.WriteLine("Login Successful, Test Passed");
            }
            else
            {
                Console.WriteLine("Login failed, Test failed");

            }
        }

     
    }
}
