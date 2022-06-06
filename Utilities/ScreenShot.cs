using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CompetitionTasks.Pages
{
    public class ScreenShot
    {
        public static void takeScreenshot(IWebDriver driver,string projectpath)
        {
            String ScreenshotFileName = Directory.GetParent(projectpath+@"\ScreenShot").FullName
            + Path.DirectorySeparatorChar
             + DateTime.Now.ToString("dd-MM-yyyy HH mm ss") + ".png";
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(ScreenshotFileName, ScreenshotImageFormat.Png);
        }
    }
}




