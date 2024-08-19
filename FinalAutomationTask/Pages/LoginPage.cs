using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Serilog;

namespace FinalAutomationTask.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Locators
        [FindsBy(How = How.CssSelector, Using = "#user-name")]
        private IWebElement UsernameInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#password")]
        private IWebElement PasswordInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#login-button")]
        private IWebElement LoginButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".error-message-container")]
        private IWebElement ErrorMessage { get; set; }

        // Methods
        public void EnterUsername(string username)
        {
            try
            {
                Log.Information("Entering username: {Username}", username);
                UsernameInput.SendKeys(username);
            }
            catch (NoSuchElementException ex)
            {
                Log.Error(ex, "Username input field not found.");
                throw;
            }
        }

        public void EnterPassword(string password)
        {
            try
            {
                Log.Information("Entering password.");
                PasswordInput.SendKeys(password);
            }
            catch (NoSuchElementException ex)
            {
                Log.Error(ex, "Password input field not found.");
                throw;
            }
        }

        public void ClearUsername()
        {
            try
            {
                Log.Information("Clearing username input.");
                UsernameInput.SendKeys(Keys.Control + "a");
                UsernameInput.SendKeys(Keys.Delete);
                UsernameInput.SendKeys(Keys.Control + "a");
                UsernameInput.SendKeys(Keys.Delete);
            }
            catch (NoSuchElementException ex)
            {
                Log.Error(ex, "Username input field not found for clearing.");
                throw;
            }
        }

        public void ClearPassword()
        {
            try
            {
                Log.Information("Clearing password input.");
                PasswordInput.SendKeys(Keys.Control + "a");
                PasswordInput.SendKeys(Keys.Delete);
                PasswordInput.SendKeys(Keys.Control + "a");
                PasswordInput.SendKeys(Keys.Delete);
            }
            catch (NoSuchElementException ex)
            {
                Log.Error(ex, "Password input field not found for clearing.");
                throw;
            }
        }

        public void ClickLogin()
        {
            try
            {
                Log.Information("Clicking the login button.");
                LoginButton.Click();
            }
            catch (NoSuchElementException ex)
            {
                Log.Error(ex, "Login button not found.");
                throw;
            }
            catch (ElementClickInterceptedException ex)
            {
                Log.Error(ex, "Login button could not be clicked, possibly due to an overlapping element.");
                throw;
            }
        }

        public string GetErrorMessage()
        {
            try
            {
                string errorMessage = ErrorMessage.Text;
                Log.Information("Retrieved error message: {ErrorMessage}", errorMessage);
                return errorMessage;
            }
            catch (NoSuchElementException ex)
            {
                Log.Error(ex, "Error message element not found.");
                throw;
            }
        }
    }
}
