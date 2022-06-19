using AventStack.ExtentReports;
using CompetitionTasks.Utilities;
using NUnit.Framework;
using System;
using OpenQA.Selenium;
using System.IO;
using System.Data;
using System.Diagnostics;


namespace CompetitionTasks.Pages
{
    [TestFixture]  //annotations --> data of data is called metadata

    public class ShareSkillDetails_Tests : CommonDriver
    {
        [Test, Order(1)]
        public void ExcelReaderMethod()
        {
            try
            {
                ExcelOperations.ClearData();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        [Test, Order(2)]
        public void CreateShareSkillDetails_Test()
        {
            ExcelOperations.ReadDataTable(stream, "ShareSkill"); // read data from excel and store it in to a datatable then read individual column data from given sheetname.
            test = extent.CreateTest("Create Shared Skill").Info("Test started");

            //Profile create page object initialization and definition
            ShareSkillPage shareSkillPageObj = new ShareSkillPage();
            shareSkillPageObj.ShareSkillSteps(driver, projectPath);
            test.Log(Status.Info, "shareskill details saved");
            test.Log(Status.Pass, "Test passed");
            ExcelOperations.ClearData();

        }
        [Test, Order(3)]
        public void EditSkillDetails_Test()
        {
            ExcelOperations.ReadDataTable(stream, "ManageListing");
            test = extent.CreateTest("test2").Info("Test started");
            //edit
            ManageListingPage manageListingPageObj = new ManageListingPage();

            manageListingPageObj.EditingSteps(driver, projectPath);
            test.Log(Status.Info, "shareskill details edited");
            test.Log(Status.Pass, "Test passed");
           
           // Assert.That(editCheck.Text == "Service Type", " not created successfully");

        }

        [Test, Order(4)]
        public void DeleteSkillDetails_Tests()
        {
            test = extent.CreateTest("test3").Info("Test started");
            ManageListingPage manageListingPageObj = new ManageListingPage();
            manageListingPageObj.deleteSteps(driver, projectPath);
            test.Log(Status.Info, "shareskill details deleted");
            test.Log(Status.Pass, "Test passed");
        }
    }
}

