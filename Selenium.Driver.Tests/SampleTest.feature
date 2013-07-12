Feature: Employee Management
In order to have many employees
As a employee with access to "manage employees"
I want to be able to easily find, add, edit, or delete employees so they can use the system


Scenario: I can add a employee
Given I am at the employees page
When I click the 'addNewEmployee' button
And I click the 'addEmployees-add' button
Then I should see the employee 'added' message 

Scenario: I can edit a employee
Given I am at the employees page
When I click the 'editEmployee' button
And I click the 'editEmployees-edit' button
Then I should see the employee 'edited' message 