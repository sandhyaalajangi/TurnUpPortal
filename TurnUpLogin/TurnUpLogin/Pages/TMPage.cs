using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using TurnUpLogin.Utilities;

namespace TurnUpLogin
{
    public class TMPage
    {
        
        //create TM
        public void CreateTM(IWebDriver driver)
        {
            //Identify create button and click
            IWebElement createButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createButton.Click();
            Wait.WaitForWebElementToExist(driver, "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]", "XPath", 5);

            //Identify drop down list and select Time
            IWebElement material = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            material.Click();

            IWebElement time = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            time.Click();
            Wait.WaitForWebElementToExist(driver, "Code", "Id", 1);
                


            //Identify code type and input code
            IWebElement code = driver.FindElement(By.Id("Code"));
            code.SendKeys("Test");


            //Identify description and input description
            IWebElement description = driver.FindElement(By.Id("Description"));
            description.SendKeys("Automation");

            // Identify Price per unit and input price
            driver.FindElement(By.XPath(" //*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Click();
            IWebElement price = driver.FindElement(By.Id("Price"));
            price.SendKeys("50");


            //Identify save button and click and save
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(1500);

            //Identify go to last page and click

            IWebElement lastPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastPage.Click();
            Thread.Sleep(1000);


            //Verify if the entry is created
            IWebElement actualCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (actualCode.Text == "Test")
            {
                Console.WriteLine("Test passed, Item is created successfully");
            }
            else
            {
                Console.WriteLine("Test failed, item is not created");
            }

            Thread.Sleep(1500);

        }



        //Edit TM
        public void UpdateTM(IWebDriver driver)
        {
        //Identify and click on Edit button
        IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
        editButton.Click();


        //Identify drop down list and select Material
        IWebElement editMaterial = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
        editMaterial.Click();

        IWebElement editTime = driver.FindElement(By.Id("TypeCode_option_selected"));
        Thread.Sleep(1000);
        editTime.Click();
        Thread.Sleep(1000);

        //Identify code type and input code
        IWebElement editCode = driver.FindElement(By.Id("Code"));
        editCode.Clear();
        editCode.SendKeys("June");
        Thread.Sleep(1000);

        //Identify description and input description
        IWebElement editDescription = driver.FindElement(By.Id("Description"));
        editDescription.Clear();

        editDescription.SendKeys("Analyst");
        Thread.Sleep(1000);

        // Identify Price per unit and input price
        IWebElement priceTab = driver.FindElement(By.XPath(" //*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
        priceTab.Click();

        IWebElement editPrice = driver.FindElement(By.Id("Price"));
        editPrice.Clear();
        Thread.Sleep(1000);
        priceTab.Click();
        editPrice.SendKeys("100");
        Thread.Sleep(1500);

        //Identify save and click and save
        IWebElement save = driver.FindElement(By.Id("SaveButton"));
        save.Click();
        Thread.Sleep(1000);

        //Go to last page and click
        IWebElement lastItem = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
        lastItem.Click();
        Thread.Sleep(2000);

        //verify if item is updated
        IWebElement displayedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
        Thread.Sleep(2000);
        if (displayedCode.Text == "June")
        {
            Console.WriteLine("Entry updated, test passed");
        }
        else
        {
            Console.WriteLine("Test failed, Entry not updated");
        }
        Thread.Sleep(1500);

    }

    //Delete TM
    public void DeleteTM(IWebDriver driver)
        {
            //Identify and click on delete button

            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            Thread.Sleep(2000);
            driver.SwitchTo().Alert().Accept();

            //Go to last page and click
            IWebElement lastItemPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastItemPage.Click();
            Thread.Sleep(2000);

            IWebElement lastItemCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement lastItemDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement lastItemPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            IWebElement lastItemTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            Thread.Sleep(2000);
            if (lastItemCode.Text == "June" && lastItemDescription.Text == "Automation" && lastItemPrice.Text == "100" && lastItemTypeCode.Text == "T")
            {
                Console.WriteLine("Item exits, Test Failed");
            }
            else
            {
                Console.WriteLine("Item deleted, Test Passed");
            }

        }


    }
}
