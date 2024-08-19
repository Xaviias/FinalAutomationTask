Feature: UC-3

@parallel
Scenario Outline: Test Login form with credentials by passing Username & Password
  Given I open the login page
  When I enter "<username>" in the username field
  And I enter "<password>" in the password field
  And I click the login button
  Then I should see the dashboard title "Swag Labs"

Examples:
  | username       | password      |
  | standard_user  | secret_sauce  |
  | problem_user   | secret_sauce  |