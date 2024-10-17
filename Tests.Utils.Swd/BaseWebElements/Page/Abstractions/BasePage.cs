using Tests.Utils.Swd.BaseWebElements.Browser;
using static Tests.Utils.Swd.BaseWebElements.Browser.WebDriverFactory;
using static Tests.Utils.Swd.Helpers.InitializationHelper;
using static Tests.Utils.Swd.Helpers.WaitHelper;


namespace Tests.Utils.Swd.BaseWebElements.Page.Abstractions;

public class BasePage
{
    public string CurrentWindowHandle { get; init; }

    protected BasePage()
    {
        InitializeElements(this, null);
    }

    protected void OpenWith(BrowserNames name, params string[] args)
    {
        WebDriverFactory.OpenWith(name, args);
    }

    public string GetPageTitle()
    {
        return Driver!.Title;
    }

    public string GetPageUrl()
    {
        return Driver!.Url;
    }

    protected void NavigateTo(string url)
    {
        WaitAndHandleExceptions(() => Driver.Navigate().GoToUrl(url));
    }

    public void RefreshPage()
    {
        WaitAndHandleExceptions(() => Driver.Navigate().Refresh());
    }

    public void GoBack()
    {
        WaitAndHandleExceptions(() => Driver.Navigate().Back());
    }

    public void GoForward()
    {
        WaitAndHandleExceptions(() => Driver.Navigate().Forward());
    }
    
    public void SwitchToAnotherWindow()
    {
        var currentWindowHandle = Driver.CurrentWindowHandle;
        var windows = Driver.WindowHandles;
        var windowToSwitch = windows.FirstOrDefault(w => w != currentWindowHandle);

        Driver
            .SwitchTo().Window(windowToSwitch)
            .SwitchTo().Window(currentWindowHandle);
    }


    public void SwitchToTabByUrl(string url)
    {
        var windows = Driver.WindowHandles;

        foreach (var window in windows)
        {
            Driver.SwitchTo().Window(window);
            var currentUrl = Driver.Url;
            if (currentUrl == url) break;
        }
    }


    public void Close()
    {
        CloseBrowser();
    }
}