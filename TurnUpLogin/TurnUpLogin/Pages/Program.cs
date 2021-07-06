using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TurnUpLogin;

namespace TurnUpPortal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //open the chrome browser
            IWebDriver driver = new ChromeDriver();

            //Object for login page
            LoginPage loginObj = new LoginPage();
            loginObj.LoginActions(driver);

            //Object for Home page
            HomePage homeObj = new HomePage();
            homeObj.GoToTMPage(driver);

            //object for TM page
            TMPage tmObj = new TMPage();
            tmObj.CreateTM(driver);
            tmObj.UpdateTM(driver);
            tmObj.DeleteTM(driver);
            

        }
    }
}