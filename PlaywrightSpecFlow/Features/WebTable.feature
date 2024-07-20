@WebPageLogin
@ReusesFeatureDriver
  
Feature: WebTableTest

  As a User i want to add new item to web table,
  so that i can see the new item in the table
  and i can delete and edit item.

  Scenario Outline: I see item in the table
    Given I am on Demo QA Web Table Page
    When I see the Web Table
    When I see FirstName "<FirstName>" column in a table
    When I see LastName "<LastName>" column in a table
    Examples:
      | FirstName | LastName |
      | Cierra    | Vega     |
      | Alden     | Cantrell |
      | Kierra    | Gentry   |