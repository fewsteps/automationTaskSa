@Converter
Feature: Converter

Scenario: All items should be visible and open item details from the list
    Given I open converter page
	When I convert <Amount> amount from <FromCurrency> to <ToCurrency>

	Examples:
	| Amount | FromCurrency  | ToCurrency |
	| 10     | BAM           | GBP        |
