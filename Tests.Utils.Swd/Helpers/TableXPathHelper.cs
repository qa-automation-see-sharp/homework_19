namespace Tests.Utils.Swd.Helpers;

public static class TableXPathHelper
{
    public static string GetRowXPath(int index)
    {
        return $"//div[{index}]/div[contains(@class,'rt-tr -odd') or contains(@class,'rt-tr -even')]";
    }
    
    public static string GetColumnXPath(int index)
    {
        return $"//div/div[contains(@class,'rt-tr -odd') or contains(@class,'rt-tr -even')]/div[{index}]";
    }
    
    public static string GetCellFromRowXPath(int rowIndex, int cellIndex)
    {
        return $"//div[{rowIndex}]/div[contains(@class,'rt-tr -odd') or contains(@class,'rt-tr -even')]/div[{cellIndex}]";
    }
    
    public static string GetCellFromTheColumnXPath(int cellIndex, int columnIndex)
    {
        return $"//div[{cellIndex}]/div[contains(@class,'rt-tr -odd') or contains(@class,'rt-tr -even')]/div[{columnIndex}]";
    }

    public static string GetHeaderCellXPath(int columnIndex)
    {
        return $"//div[@class ='rt-thead -header']/div/div[{columnIndex}]/div[@class='rt-resizable-header-content']]";
    }
}