using OpenQA.Selenium;
using Serilog;
using FinalAutomationTask.Pages;
using FinalAutomationTask.Drivers;
using System.Text.RegularExpressions;
[assembly: Parallelize(Scope = ExecutionScope.ClassLevel)]

namespace FinalAutomationTask.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private DashboardPage dashboardPage;

        [BeforeScenario]
        public void Setup()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            Log.Information("Setting up the test scenario.");

            string browser = Environment.GetEnvironmentVariable("BROWSER") ?? "Firefox";


            BrowserType browserType = Enum.TryParse(browser, true, out BrowserType parsedBrowserType)
                                      ? parsedBrowserType
                                      : BrowserType.Firefox;

            DriverManager.ResetDriver(browserType);
            driver = DriverManager.GetWebDriver(browserType);

            loginPage = new LoginPage(driver);
            dashboardPage = new DashboardPage(driver);
        }

        [AfterScenario]
        public void TearDown()
        {
            Log.Information("Tearing down the test scenario.");
            driver.Quit();
            Log.Information("Driver has been quit.");
        }

        [Given(@"I open the login page")]
        public void GivenIOpenTheLoginPage()
        {
            Log.Information("Navigating to the login page.");
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Cookies.DeleteAllCookies();
            Log.Information("Cookies cleared.");
        }

        [When(@"I enter ""(.*)"" in the username field")]
        public void WhenIEnterInTheUsernameField(string username)
        {
            loginPage.EnterUsername(username);
        }

        [When(@"I enter ""(.*)"" in the password field")]
        public void WhenIEnterInThePasswordField(string password)
        {
            loginPage.EnterPassword(password);
        }

        [When(@"I clear the username field")]
        public void WhenIClearTheUsernameField()
        {
            loginPage.ClearUsername();
        }

        [When(@"I clear the password field")]
        public void WhenIClearThePasswordField()
        {
            loginPage.ClearPassword();
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            loginPage.ClickLogin();
        }

        [Then(@"I should see an error message ""(.*)""")]
        public void ThenIShouldSeeAnErrorMessage(string expectedErrorMessage)
        {
            Log.Information("Verifying the error message.");
            string actualErrorMessage = loginPage.GetErrorMessage();

            Regex regex = new Regex(expectedErrorMessage);
            Match match = regex.Match(actualErrorMessage);

            match.Success.Should().BeTrue($"Expected error message '{expectedErrorMessage}' not found in actual message '{actualErrorMessage}'");
            Log.Information("Error message verified successfully.");
        }

        [Then(@"I should see the dashboard title ""(.*)""")]
        public void ThenIShouldSeeTheDashboardTitle(string expectedTitle)
        {
            Log.Information("Verifying the dashboard title.");
            string actualTitle = dashboardPage.GetPageTitle();
            actualTitle.Should().Be(expectedTitle);
            Log.Information("Dashboard title verified successfully.");
        }
    }
}
