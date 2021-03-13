Feature: ClientsGet
The `/clients` and `/clients/{language}` end point returns a status message to indicate that the application is running successfully.

@getTest
Scenario: Verify status code when called api clients
	Given Create request '/clients' with 'GET' method
	When Execute Api
	Then  returned status code will be 200
@postTest
Scenario: Verify status code when called clients api with parameter
	Given Create request '/clients/ruby' with 'POST' method
	And I create a request body with the content
	When Execute Api
	Then returned status code will be 200