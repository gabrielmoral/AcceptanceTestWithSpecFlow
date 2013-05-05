Feature: Check out

Scenario: list check our items
 	Given I have a list of selected items
 	When I want to buy them
 	Then I can see them before pay

Scenario: payment
	Given I have selected the items
	When I write the credit card
	Then I should see a confirmation message

Scenario: clean basket items
	Given : I have selected then items 
	When : I empty the basket
	Then : I should see the basket empty
