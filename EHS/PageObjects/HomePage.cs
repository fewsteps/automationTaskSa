using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EHS.PageObjects;

/// <summary>
/// Home Page Object
/// </summary>
public class HomePage
{
    //The URL of the application to be opened in the browser
    private const string HomeUrl = "\\Application\\EHS.html";

    //The Selenium web driver to automate the browser
    private readonly IWebDriver _webDriver;
    
    //The default wait time in seconds for wait.Until
    public const int DefaultWaitInSeconds = 5;

    public HomePage(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    //Finding elements by ID
    private IWebElement SearchInput => _webDriver.FindElement(By.Id("ProductIdField"));
    private IWebElement FindBtn => _webDriver.FindElement(By.Id("FindItemButton"));

    public void SearchItemById(string value)
    {
        //Clear text box
        SearchInput.Clear();
        //Enter text
        SearchInput.SendKeys(value);
        FindBtn.Click();
    }

    public void OpenAllItems()
    {
        WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
        IWebElement AllItemsBtn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("ListAllItemsButton")));

        AllItemsBtn.Click();
    }

    public void EnsureHomePageIsOpen()
    {
        string path = System.IO.Directory.GetCurrentDirectory();
        string parent = Directory.GetParent(path).Parent.Parent.Parent.Parent.ToString();
        Console.WriteLine(parent);
        _webDriver.Navigate().GoToUrl(parent + HomeUrl);
    }
}
