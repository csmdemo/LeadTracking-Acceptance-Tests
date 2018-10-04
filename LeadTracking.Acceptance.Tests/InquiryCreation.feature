Feature: InquiryCreation
	As a person who sells services
	I want to record and inquiry
	So that I can use the information to sell services



@firstContact
Scenario: Create Inquiry Record
	Given I have a service inquiry repository
	Given I have an inquiry about services from a person
			| FirstName | LastName | PhoneNumber  | EmailAddress          | OrganizationName | Inquiry                                   |
			| John      | Doe      | 111-222-3333 | jdoe@donotresolve.com | Widgets Inc.     | I need a simple CRM system to track leads |	
	When I record the service inquiry
	Then Record is saved in database
@existingContact
Scenario: Search for Existing Record
	Given I have a service inquiry repository
	When I perform a service inquiry search where first name is "FirstName1" and last name is "LastName1"
	Then Search results has count greater than 0
