using OpenQA.Selenium;

namespace EHS.PageObjects;

/// <summary>
/// List Page Object
/// </summary>
public class ListPage
{
    //The Selenium web driver to automate the browser
    private readonly IWebDriver _webDriver;

    //The default wait time in seconds for wait.Until
    public const int DefaultWaitInSeconds = 5;
    public ListPage(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    //Finding elements by ID
    private IWebElement ItemId(string Id) => _webDriver.FindElement(By.XPath($"//td[text()='{Id}']"));

    private IWebElement OpenBtn(string ItemId) => _webDriver.FindElement(By.XPath($"//td[text()='{ItemId}']/..//input[@value='Open']"));

    public void OpenItemDetails(string ItemName)
    {
        OpenBtn(ItemName).Click();
    }
    public void AllItemsShouldBeDisplayed(string ItemIds)
    {
        var Ids = ItemIds.Split(',');

        foreach (var id in Ids)
        {
            Assert.AreEqual(true, ItemId(id).Displayed);
        }
    }
}
