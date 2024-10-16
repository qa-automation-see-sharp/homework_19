namespace Tests.Utils.Swd.Helpers;

public static class TableXPathHelper
{
    public static string GetRowXPath(int index)
    {
        return $"//div{index}/div[contains(@class,'rt-tr -odd') or contains(@class,'rt-tr -even')]/div";
    }
    
    public static string GetColumnXPath(int index)
    {
        return $"//div[contains(@class,'rt-tbody')]/div/div[contains(@class,'rt-tr -odd') or contains(@class,'rt-tr -even')]/div[{index}]";
    }
    
    public static string GetCellXPath(int rowIndex, int columnIndex)
    {
        return $"//div[{rowIndex}]/div[contains(@class,'rt-tr -odd') or contains(@class,'rt-tr -even')]/div[{columnIndex}]";
    }
    
    public static string GetHeaderCellXPath(int columnIndex)
    {
        return $"//div[@class ='rt-thead -header']/div/div[{columnIndex}]/div[@class='rt-resizable-header-content']]";
    }
}