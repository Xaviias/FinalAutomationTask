# Final Automation Task

## Overview
This project automates the login functionality testing of the [Sauce Demo](https://www.saucedemo.com/) application using Selenium WebDriver, MSTest, and BDD.

## Test Cases
- **UC-1**: Test login with empty credentials.
- **UC-2**: Test login with only username provided.
- **UC-3**: Test login with valid credentials.

## Tools & Frameworks
- **Test Automation Tool**: Selenium WebDriver
- **Browsers Supported**: Firefox, Edge
- **Locators Used**: CSS Selectors
- **Test Runner**: MSTest
- **Design Patterns**: Page Object Model (POM)
- **BDD**: SpecFlow
- **Assertions**: FluentAssertions
- **Logging**: Serilog

## How to Run Tests
1. Clone the repository.
2. Set the `BROWSER` environment variable to either `Firefox` or `Edge`(`Firefox` is default value).
3. Run the tests using MSTest.
4. Logs are output to the console.

## Project Structure
- `Drivers/`: WebDriver management.
- `Pages/`: Page Object Models for the application.
- `StepDefinitions/`: BDD Step Definitions.
- `Features/`: SpecFlow Feature files.

## Notes
- Parallelization is enabled at the class level to expedite the test execution process.
