using Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;

namespace Tests.Utils.Swd.BaseWebElements.Elements;

public class CheckBox : BaseElement
{
    public bool Checked => IsSelected();
    
    public void Check()
    {
        if (!Checked)
        {
            Click();
        }
    }

    public void UnCheck()
    {
        if (Checked)
        {
            Click();
        }
    }
}