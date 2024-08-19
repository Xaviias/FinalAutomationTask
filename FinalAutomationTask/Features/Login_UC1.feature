Feature: UC-1

@parallel
Scenario Outline: Test Login form with empty credentials
  Given I open the login page
  When I enter "<username>" in the username field
  And I enter "<password>" in the password field
  And I clear the username field
  And I clear the password field
  And I click the login button
  Then I should see an error message "Username is required"

Examples:
  | username | password |
  | login    | password |
  |          |          |
