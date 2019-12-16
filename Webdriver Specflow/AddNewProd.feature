Feature: AddNewProd_Feature
	In order to add new product
	As a authenticated user of website	
	I want to add new product

@mytag
Scenario: Successful Add new product
	Given user is successfully login
	When User click on All products
	And user click on create new
	And user fill enought fields and user click send
	Then new product successfully added