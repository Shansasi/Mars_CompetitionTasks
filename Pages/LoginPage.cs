
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
            IWebElement signinButton = driver.FindElement(By.LinkText("Sign In"));
            //.XPath("//div[@id='home']/div/div/div[1]/div/a")
            signinButton.Click();
            try
            {
                //Identify user name text box and enter valid user name
                IWebElement usernameTextbox = driver.FindElement(By.Name("email"));
                //.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"
                usernameTextbox.Clear();  
                string userName = ExcelOperations.ReadData(1, "UserName");
                usernameTextbox.SendKeys(userName);
              
                //identify password and enter valid password
                IWebElement passwordTextbox = driver.FindElement(By.Name("password"));
                //.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input")
                usernameTextbox.Clear();
                string password = ExcelOperations.ReadData(1, "Password");
                passwordTextbox.SendKeys(password);
                
            //Wait.WaitToBeClickable(driver, "XPath", "//button[contains(text(),'Login')]", 2);
                ///html/body/div[2]/div/ div/div[1]/div/div[4]/button
                //click on login button
                IWebElement loginButton = driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));
                loginButton.Click();
                //Thread.Sleep(3000); 
                IWebElement desc = driver.FindElement(By.XPath("//h3[contains(text(),'Description')]"));
                Assert.IsTrue(desc.Displayed);

            }
            catch (Exception ex)

            {
                Assert.Fail("Turnup portal login page didnt launch", ex.Message);
                throw;
            }
        }
    }
}
