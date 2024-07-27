@ReusesFeatureDriver
@WebPageLogin

Feature: WebTableTest

  As a User i want to add new item to web table,
  so that i can see the new item in the table
  and i can delete and edit item.

Scenario Outline: I see item in the table
	Given I am on DemoQA WebTable Page
	When I see the WebTable
	Then I see FirstName "<FirstName>" in a table
	Then I see LastName "<LastName>" in a table
Examples:
	| FirstName | LastName |
	| Cierra    | Vega     |
	| Alden     | Cantrell |
	| Kierra    | Gentry   |

Scenario Outline: I add item to the table
	Given I am on DemoQA WebTable Page
	When I see the WebTable
	And I add the FisrtName "<FirstName>" and LastName "<LastName>" and Email "<Email>" to the table
	Then I should see the FirstName "<FirstName>" and LastName "<LastName>" and "<Email>" in the table
Examples:
	| FirstName   | LastName  | Email                        |
	| Ryan        | Blevins   | cooperjoshua@hotmail.com     |
	| Derrick     | Sandoval  | williamhenderson@hotmail.com |
	| Kimberly    | Douglas   | susan34@yahoo.com            |
	| Michael     | Clark     | jenniferfinley@gonzalez.com  |
	| Diana       | Ray       | susan38@long.com             |
	| Christopher | White     | fhobbs@brown-ortega.com      |
	| Tanya       | Larson    | qfigueroa@yahoo.com          |
	| Donald      | Johnston  | bennettanita@gmail.com       |
	| Samantha    | Williams  | michael19@hotmail.com        |
	| Keith       | Soto      | edwarddorsey@george.com      |
	| Aaron       | Stewart   | aaronstewart@hotmail.com     |
	| Jessica     | Powell    | jessicapowell@yahoo.com      |
	| Brian       | Scott     | brianscott@gmail.com         |
	| Lisa        | Edwards   | lisaedwards@hotmail.com      |
	| Eric        | Russell   | ericrussell@live.com         |
	| Laura       | Perry     | lauraperry@gmail.com         |
	| Mark        | Watson    | markwatson@outlook.com       |
	| Nancy       | Baker     | nancybaker@hotmail.com       |
	| Frank       | Murphy    | frankmurphy@gmail.com        |
	| Gloria      | Bryant    | gloriabryant@yahoo.com       |
	| George      | Evans     | georgeevans@outlook.com      |
	| Linda       | Howard    | lindahoward@hotmail.com      |
	| Steven      | Ward      | stevenward@gmail.com         |
	| Amy         | Kelly     | amy.kelly@yahoo.com          |
	| Justin      | Flores    | justinflores@live.com        |
	| Karen       | Morales   | karenmorales@gmail.com       |
	| Paul        | Cooper    | paulcooper@hotmail.com       |
	| Laura       | Ward      | lauraward@outlook.com        |
	| Daniel      | Hughes    | danielhughes@gmail.com       |
	| Michelle    | Foster    | michellefoster@yahoo.com     |
	| Kevin       | Rivera    | kevinrivera@live.com         |
	| Angela      | Simmons   | angelasimmons@gmail.com      |
	| Jason       | Butler    | jasonbutler@hotmail.com      |
	| Melissa     | Gray      | melissagray@yahoo.com        |
	| Charles     | Cooper    | charlescooper@outlook.com    |
	| Amanda      | Stewart   | amandastewart@gmail.com      |
	| Edward      | Sanders   | edwardsanders@yahoo.com      |
	| Emily       | Brooks    | emilybrooks@live.com         |
	| Joshua      | Bell      | joshuabell@gmail.com         |
	| Sarah       | Gonzales  | sarahgonzales@yahoo.com      |
	| Daniel      | Ramirez   | danielramirez@hotmail.com    |
	| Patricia    | Alexander | patricia.alexander@gmail.com |
	| Matthew     | Hamilton  | matthewhamilton@outlook.com  |
	| Barbara     | Graham    | barbara.graham@yahoo.com     |
	| David       | Patterson | davidpatterson@live.com      |
	| Jennifer    | Cox       | jennifercox@gmail.com        |
	| Richard     | Wallace   | richardwallace@yahoo.com     |
	| Stephanie   | Carter    | stephaniecarter@outlook.com  |
	| Brian       | Woods     | brianwoods@hotmail.com       |


	#TODO Finalize I add item to the table
    #Finish table examples
    #Add more steps to the make valid scenario
    #Generate dataset for 50 items