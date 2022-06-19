using System;
using AutoItX3Lib;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompetitionTasks.Utilities;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium;
using System.Threading;
using System.IO;
using ExcelDataReader;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace CompetitionTasks.Pages
{
    public class ShareSkillPage : CommonDriver
    {
        public void ShareSkillSteps(IWebDriver driver,string projectPath)
        {

            //click on shareskill
            //Wait.WaitToBeClickable(driver, "XPath", "//*[@id='account-profile-section']/div/section[1]/div/div[2]/a", 3);
            Thread.Sleep(3000);
            IWebElement shareSkill = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[2]/a"));
            
            shareSkill.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input", 3);
            //Adding Title
            IWebElement titleTextBox = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input"));
            string title = ExcelOperations.ReadData(1, "Title");
            titleTextBox.SendKeys(title);
            
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea", 3);
            //adding description
            IWebElement descriptionTextBox = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea"));
            string description = ExcelOperations.ReadData(1, "Description");
            descriptionTextBox.SendKeys(description);

            //adding category
            js.ExecuteScript("window.scrollBy(0,200)");
            IWebElement categoryDropdown = driver.FindElement(By.Name("categoryId"));
            categoryDropdown.Click();
            SelectElement categoryselect = new SelectElement(categoryDropdown);
            categoryselect.SelectByText(ExcelOperations.ReadData(1, "Category"));

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[2]", 3);
            //adding subcategory
            IWebElement subcategory = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select"));
            subcategory.Click();
            SelectElement subcategoryRead = new SelectElement(subcategory);
            subcategoryRead.SelectByText(ExcelOperations.ReadData(1, "Subcategory"));
            //IWebElement logoCategory = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select/option[2]"));
            //logoCategory.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input", 3);

            IWebElement tags = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
            string tagName = ExcelOperations.ReadData(1, "Tags");
            tags.SendKeys(tagName); 
            tags.SendKeys(Keys.Enter);
             
            //Adding servicetype as oneoff service
            IWebElement servicetypeRadioButton = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input"));
            servicetypeRadioButton.Click();
            //adding location as online
            IWebElement locationTypeRadioButton = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));
            locationTypeRadioButton.Click();
            //Wait.WaitToBeClickable(driver, "XPath", "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input", 3);
            Thread.Sleep(2000);            

            //adding end date
            IWebElement endDate = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input"));
            string endDateText = ExcelOperations.ReadData(1, "End Date");
            endDate.SendKeys(endDateText);
            Thread.Sleep(2000);
        //endDate.Click();
            // Wait.WaitToBeClickable(driver, "XPath", "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[1]/div/input", 3);
            Thread.Sleep(3000);
            IWebElement checkBoxDates = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[1]/div/input"));
            checkBoxDates.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/label", 3);


            IWebElement skillTradeRadioButton = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/label"));
            skillTradeRadioButton.Click();
            IWebElement skillExchange = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div[1]/div/div/div/div/input"));
            string skillTrade = ExcelOperations.ReadData(1, "Skill Exchange");
            skillExchange.SendKeys(skillTrade);
            skillExchange.SendKeys(Keys.Enter);
            IWebElement workUploadButton=driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
            workUploadButton.Click();

            //option 1 for adfng files from s/m
            // workUploadButton.SendKeys(projectPath+ @"\work sample\Updated - Mars(QA)-CompetitionTask.docx");

            //option 2
            Console.WriteLine(projectPath + @"work sample\Updated - Mars(QA)-CompetitionTask.docx");
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            Thread.Sleep(1000);
            autoIt.Send(projectPath+ @"work sample\Updated - Mars(QA)-CompetitionTask.docx"); //work.txt
            Thread.Sleep(1000); //1000 ms
            autoIt.Send(@"{Enter}");

            //Wait.WaitToBeClickable(driver, "XPath", "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input", 3);
            Thread.Sleep(2000);
            IWebElement active = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input"));
            active.Click();

            IWebElement saveButton = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]"));
            saveButton.Click();
            Thread.Sleep(3000);
            ScreenShot.takeScreenshot(driver, projectPath);           
        }
    }
}
