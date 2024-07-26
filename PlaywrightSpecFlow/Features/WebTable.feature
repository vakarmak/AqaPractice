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
	And I add the following items:
		| FirstName   | LastName   | Email   |
		| <FirstName> | <LastName> | <Email> |
	Then I should see following items in the table:
		| FirstName   | LastName   | Email   |
		| <FirstName> | <LastName> | <Email> |
Examples:
	| FirstName   | LastName   | Email                          |
	| Ryan        | Blevins    | cooperjoshua@hotmail.com       |
	| Derrick     | Sandoval   | williamhenderson@hotmail.com   |
	| Kimberly    | Douglas    | susan34@yahoo.com              |
	| Michael     | Clark      | jenniferfinley@gonzalez.com    |
	| Diana       | Ray        | susan38@long.com               |
	| Christopher | White      | fhobbs@brown-ortega.com        |
	| Tanya       | Larson     | qfigueroa@yahoo.com            |
	| Donald      | Johnston   | bennettanita@gmail.com         |
	| Samantha    | Williams   | michael19@hotmail.com          |
	| Keith       | Soto       | edwarddorsey@george.com        |
	| Philip      | Shelton    | stevenmiller@yahoo.com         |
	| Mitchell    | French     | hperez@graves.org              |
	| Ryan        | Hansen     | roblesjohn@harris-gonzalez.com |
	| Kimberly    | Morris     | goodwinamber@gmail.com         |
	| Melanie     | Charles    | maryparker@yahoo.com           |
	| Allison     | Fowler     | khill@hotmail.com              |
	| Jamie       | Henry      | rgonzalez@harris.com           |
	| Nathan      | French     | hernandezthomas@gmail.com      |
	| James       | Harper     | kfranco@gmail.com              |
	| Katherine   | Hicks      | warrenmegan@gmail.com          |
	| Robert      | Villanueva | jasonross@white.info           |
	| Anne        | Weaver     | martinezdavid@leon-young.com   |
	| Steven      | Stein      | ymoon@johnson-watson.com       |
	| Karen       | Sanders    | medina44@taylor.com            |
	| Robert      | Turner     | svargas@jimenez-dunn.com       |
	| Michelle    | Mcneil     | allenmelendez@hotmail.com      |
	| Zachary     | Armstrong  | stokesconnie@gmail.com         |
	| Terri       | Rios       | rosemary@hotmail.com           |
	| William     | Smith      | anthonygeorge@sellers.biz      |
	| Karen       | Ramirez    | acardenas@yahoo.com            |
	| Penny       | Maddox     | harrisamy@gmail.com            |
	| Ashlee      | Jones      | phillipsbrian@gmail.com        |
	| Mason       | Allen      | ambergilmore@hill-leon.org     |
	| Jennifer    | Smith      | chelseymendoza@flowers.info    |
	| Jennifer    | Jackson    | sherrysmith@miller.com         |
	| Jamie       | James      | xwright@rios.biz               |
	| Terrance    | Harris     | pamela83@hotmail.com           |
	| Brandon     | Hicks      | elizabethsnow@crawford.org     |
	| Christopher | Brewer     | davidshannon@gmail.com         |
	| John        | Murray     | wweeks@gmail.com               |
	| Kimberly    | Hartman    | jean75@gmail.com               |
	| Joseph      | Alexander  | wattskyle@bailey.com           |
	| Devin       | George     | huffgeorge@perez-garrett.com   |
	| Austin      | Bell       | igonzales@hotmail.com          |
	| James       | Kelley     | dunncarl@camacho.com           |
	| Robert      | Yu         | wbernard@hotmail.com           |
	| Amanda      | Garcia     | kparks@taylor.com              |
	| Erin        | Wilson     | bradleykimberly@hotmail.com    |



	#TODO Finalize I add item to the table
    #Finish table examples
    #Add more steps to the make valid scenario
    #Generate dataset for 50 items