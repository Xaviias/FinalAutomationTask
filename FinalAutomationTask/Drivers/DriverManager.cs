using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace FinalAutomationTask.Drivers
{
    public enum BrowserType
    {
        Firefox,
        Edge
    }

    public class DriverManager
    {
        private static IWebDriver? driver;
        private static readonly ThreadLocal<IWebDriver> threadLocalDriver = new ThreadLocal<IWebDriver>();

        private DriverManager() { }

        private static void BrowserSwitch(BrowserType browserType)
        {
            driver = browserType switch
            {
                BrowserType.Firefox => new FirefoxDriver(),
                BrowserType.Edge => new EdgeDriver(),
                _ => throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null)
            };

            threadLocalDriver.Value = driver;
        }

        public static IWebDriver GetWebDriver(BrowserType browserType)
        {
            if (threadLocalDriver.Value == null)
            {
                BrowserSwitch(browserType);
            }
            return threadLocalDriver.Value;
        }
        public static void ResetDriver(BrowserType browserType)
        {
            QuitDriver();

            BrowserSwitch(browserType);
        }

        public static void QuitDriver()
        {
            if (threadLocalDriver.Value != null)
            {
                threadLocalDriver.Value.Quit();
                threadLocalDriver.Value = null;
            }
        }
    }
}