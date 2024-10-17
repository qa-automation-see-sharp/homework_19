using static Tests.Utils.Swd.BaseWebElements.Browser.WebDriverFactory;

namespace Tests.Utils.Swd.BaseWebElements.Page;

public class AlertHandle
{
    public AlertHandle Accept()
    {
        Driver.SwitchTo().Alert().Accept();

        return this;
    }

    public AlertHandle Dismiss()
    {
        Driver.SwitchTo().Alert().Dismiss();

        return this;
    }

    public string GetText()
    {
        return Driver.SwitchTo().Alert().Text;
    }

    public AlertHandle SendKeys(string text)
    {
        Driver.SwitchTo().Alert().SendKeys(text);

        return this;
    }
}