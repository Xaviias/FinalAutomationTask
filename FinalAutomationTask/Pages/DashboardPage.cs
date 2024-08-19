using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Serilog;

namespace FinalAutomationTask.Pages
{
    public class DashboardPage
    {
        private readonly IWebDriver driver;
        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string GetPageTitle()
        {
            string pageTitle = driver.Title;
            Log.Information("Retrieved dashboard page title: {PageTitle}", pageTitle);
            return pageTitle;
        }
    }
}
