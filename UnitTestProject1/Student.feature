Feature: Students

@mytag
Scenario: Create a new student
	Given I navigate to create new student page
	When I create new student with "Dimitry" for FullName and 19 for Age
	Then the result should be success

Scenario: Create a new student with no name
	Given I navigate to create new student page
	When I create new student with "" for FullName and 30 for Age
	Then the result should be return "The FullName field is required."

Scenario: Create a new student with age outside range
	Given I navigate to create new student page
	When I create new student with "Dimitry" for FullName and 30 for Age
	Then the result should be return "The field Age must be between 6 and 20."

Scenario: Create a new student with grade
	Given I navigate to create new student page
	When I create new student with "Dimitry" for FullName and 20 for Age and "B" for Grade
	Then the result should be success

Scenario: Create a new student with invalid grade
	Given I navigate to create new student page
	When I create new student with "Dimitry" for FullName and 20 for Age and "AA" for Grade
	Then the result should be return "not a valid grade"

Scenario: View students
	When I navigate to student list page
	Then the page should contain "Tom Jones"
