#Customer Matcher

## Description
You are asked to implement all three interfaces: 
`ICustomersReportParser`, `IReportItemsParser` and `ICustomerSumMatcher`.
First two should implement logic to parse and import data from csv files. 
`ICustomerSumMatcher` should contain logic to match items between above reports. 
Assume that the code is right in terms of business logic, `Program.cs` contains example of usage of interfaces (no DI for simplicity).

##Requirements
Solution should be able to match items between data files (`PartialReports.csv` and `Totals.csv`).

Each row in `PartialReports.csv` file contains data for one individual transaction in format:
[Amount, CustomerNumber, Reference], possible multiple rows for same customer number.

`Totals.csv` contains data with total amount per customer number in format: [CustomerNumber, Total] (one row per customer number).

One, multiple or none rows from `PartialReports.csv` file can be matched to one row from `Totals.csv`.
Items are matched when `CustomerNumber` is the same and sum of `Amount` column from `PartialReports.csv` equals total of `Totals.csv` item.
Not all items from both files have to be matched, some can stay unmatched. One item can't be matched multiple times.


Example:
###ReportItems:  
| Amount | CustomerNumber | Reference |
| :------: | :------:| :------:|
| 12.00 | A01 | ref1 |
| 2.00 | B02 | ref2 |
| 10.00 | A01 | ref3 |
| 12.00 | B02 | ref4 |
| 100.00 | A01 | ref5 |
| 1000.00 | C03 | ref6 |

###Totals
| CustomerNumber | Total |
| :------: | :------:|
| A01 | 112.00 |
| B02 | 14.00 |
| C03 | 1000.00 |

###Matched
| CustomerNumber | Total | PartialAmount | Reference
| :------: | :------:| :------: | :------:|
| A01 | 112.00 | 12.00 | ref1
| A01 | --- | 100.00 | ref5
| B02 | 14.00 | 2.00 | ref2
| B02 | --- | 12.00 | ref4
| C03 | 1000.00 | 1000.00 | ref6

###UnMatched
| CustomerNumber | PartialAmount | Reference
| :------: | :------:| :------: |
| A01 | 10.00 | ref3