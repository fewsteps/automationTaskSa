using EHS.Drivers;
using EHS.PageObjects;
using TechTalk.SpecFlow;
using BindingAttribute = TechTalk.SpecFlow.BindingAttribute;

namespace EHS.Steps;

[Binding]
public sealed class EHSStepDefinitions
{
    //Page Object for Application
    private readonly HomePage _homePageObject;
    private readonly ListPage _listPage;
    private readonly ItemDetailsPage _itemDetailsPage;


    public EHSStepDefinitions(BrowserDriver browserDriver)
    {
        _homePageObject = new HomePage(browserDriver.Current);
        _listPage = new ListPage(browserDriver.Current);
        _itemDetailsPage = new ItemDetailsPage(browserDriver.Current);
    }

    [Given("I open home page")]
    public void OpenBrowser()
    {
        _homePageObject.EnsureHomePageIsOpen();
    }
    [When("I search item by id (.*)")]
    public void SearchItemById(string id)
    {
        //delegate to Page Object
        _homePageObject.SearchItemById(id);
    }

    [When("I open item details by name (.*)")]
    public void OpenItemDetails(string name)
    {
        //delegate to Page Object
        _listPage.OpenItemDetails(name);
    }

    [When("I open all items")]
    public void WhenOpenAllItems()
    {
        //delegate to Page Object
        _homePageObject.OpenAllItems();
    }

    [Then(@"All items should be displayed ""(.*)""")]
    public void ThenAllItemsShouldBeDisplayed(string Ids)
    {
        //delegate to Page Object
        _listPage.AllItemsShouldBeDisplayed(Ids);
    }

    [Then(@"Item details should be displayed ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)""")]
    public void ItemShouldBeDisplayed(string Id, string Name, string Material, string Manufacturer, string RetailPrice)
    {
        //delegate to Page Object
        _itemDetailsPage.ItemShouldBeDisplayed(Id, Name, Material, Manufacturer, RetailPrice);
    }
}
