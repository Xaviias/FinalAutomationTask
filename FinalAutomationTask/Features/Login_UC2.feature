Feature: UC-2

@parallel
Scenario Outline: Test Login form with credentials by passing Username
  Given I open the login page
  When I enter "<username>" in the username field
  And I enter "<password>" in the password field
  And I clear the password field
  And I click the login button
  Then I should see an error message "Password is required"

Examples:
  | username       | password |
  | standard_user  | 12345qwe |
  | user123        | abcdef   |
