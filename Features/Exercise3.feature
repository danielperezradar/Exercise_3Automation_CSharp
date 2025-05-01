Feature: Exercise 3

Scenario: Exercise 3 test
	Given I load my XML file '../../../files/configuration.xml'
	Given I go to automation exercise web site
	And I login using valid credentials
	And I search for product: 'Men Tshirt'
	When I select first product and save the price
	Then I validate first price is the same of new price
	When I add it to Cart
	Then I validate cart price is the same of new price
	And I validate that the Shop car has '1' as a product
	Given I search for product: 'Blue Top'
	And I select first product
	When I add it to Cart
	Then I validate that the Shop car has '2' as a product
	And I finish the test