
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CompetitionTasks.Utilities;

namespace CompetitionTasks.Pages
{
    public class LoginPage
    {

        public void LoginSteps(IWebDriver driver)
        {


            
            //launch turnup  portal
            driver.Navigate().GoToUrl("http://localhost:5000/");

            //click on signin
            IWebElement signinButton = driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a"));
            signinButton.Click();
            try
            {
                //Identify user name text box and enter valid user name
                IWebElement usernameTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
                usernameTextbox.Clear();    
               
                string userName = ExcelOperations.ReadData(1, "UserName");
                usernameTextbox.SendKeys(userName);
              
                //identify password and enter valid password
                IWebElement passwordTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
                usernameTextbox.Clear();
                string password = ExcelOperations.ReadData(1, "Password");
                passwordTextbox.SendKeys(password);
                Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[2]/div/ div/div[1]/div/div[4]/button", 2);
                //click on login button
                IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
                loginButton.Click();
                Thread.Sleep(3000); 

            }
            catch (Exception ex)

            {
                Assert.Fail("Turnup portal login page didnt launch", ex.Message);
                throw;
            }


        }
    }
}
