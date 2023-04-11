using OpenQA.Selenium;
using System.Diagnostics;

namespace EHS.PageObjects;

public class ItemDetailsPage
{
    //The Selenium web driver to automate the browser
    private readonly IWebDriver _webDriver;

    //The default wait time in seconds for wait.Until
    public const int DefaultWaitInSeconds = 5;

    public ItemDetailsPage(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    //Finding elements by ID
    private IWebElement ItemId => _webDriver.FindElement(By.Id("ProductId"));
    private IWebElement Name => _webDriver.FindElement(By.Id("NameField"));
    private IWebElement Material => _webDriver.FindElement(By.Id("MaterialField"));
    private IWebElement Manufacturer => _webDriver.FindElement(By.Id("ManufacturerField"));
    private IWebElement RetailPrice => _webDriver.FindElement(By.Id("RetailPriceField"));


    public void ItemShouldBeDisplayed(string ItemId, string Name, string Material, string Manufacturer, string RetailPrice)
    {
        Assert.AreEqual(ItemId, this.ItemId.Text);
        Assert.AreEqual(Name, this.Name.GetAttribute("value"));
        Assert.AreEqual(Material, this.Material.GetAttribute("value"));
        Assert.AreEqual(Manufacturer, this.Manufacturer.GetAttribute("value"));
        Assert.AreEqual(RetailPrice, this.RetailPrice.GetAttribute("value"));
    }
}
