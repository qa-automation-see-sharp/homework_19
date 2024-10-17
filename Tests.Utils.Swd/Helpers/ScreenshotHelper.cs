using OpenQA.Selenium.Support.Extensions;
using static Tests.Utils.Swd.BaseWebElements.Browser.WebDriverFactory;

namespace Tests.Utils.Swd.Helpers;

public static class ScreenshotHelper
{
    public static void TakeScreenShoot(string pathAndTestName)
    {
        var directory = Directory.GetCurrentDirectory();
        var createADirectory = Path.Combine(directory, $"{DateTime.Now:MM-dd-yy}/Screenshots/");
        Directory.CreateDirectory(createADirectory);
        var path = Path.Combine(createADirectory, $"{pathAndTestName}.png");

        Driver
            .TakeScreenshot()
            .SaveAsFile(path);
    }
}