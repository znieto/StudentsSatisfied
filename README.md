# Coding challenge


## High-Level Approach

    - Parse the CSV: Load the CSV file to extract the priorities assigned by teams to companies and vice versa. 
    - Matching Algorithm: Implement a variation of the Gale-Shapley algorithm tailored to handle cases 
      where not all parties have ranked all the others, and parties can leave preferences blank.
    - Output: The algorithm will produce a set of pairs indicating which team is matched with which company, 
      aiming to satisfy the highest priorities on both sides as much as possible.


### Services Used:
    - CsvService: Responsible for reading the CSV file and converting the data into a format usable by the application.
    - PreferenceService: Handles the creation and management of preference lists for teams and companies.
    - MatchingService: Implements the matching algorithm, relying on preferences provided by the PreferenceService.
    - OutputService: Manages output formatting and presentation, such as displaying match results.


## Assumptions

    - Incomplete Lists: Both teams and companies might not rank all the opposite parties. 
    - The algorithm must handle such cases gracefully.
    - Unique Matches: Each team is matched with exactly one company, and vice versa, wherever possible.
    - Preference for Filled Rankings: If a team or company ranks another, it indicates a preference to be matched 
    over having no match at all.
    - No empty Lists: There must be at least one team and one company. 


## Important Test Cases

    All Teams and Companies Have Complete Rankings: Ensures the basic functionality works.
    Some Entities Have Incomplete Rankings: Tests the algorithm's ability to handle incomplete preferences.
    One Side Has More Entities Than the Other: Verifies how the algorithm deals with potential unmatched entities.
    Mutual Highest Priority: Confirms that entities that rank each other as their top choice are matched.

## Improvements
    - Comprehensive error handling is missing. The solution should contain the following:
      1. Validating inputs at each step of the process, such as checking for the correctness and 
        completeness of the data loaded from the CSV file.
      2. Use try-catch blocks where exceptions might occur, for example, when parsing data or accessing files and resources.
      3. Provide meaningful error messages to the user or system logs.
      4. Gracefully handling known edge cases, such as unmatched teams or companies, missing data, 
         and incorrect formats in the CSV.
    - Performance could be improved by using queues or linked lists for team preferences or having hash sets  for quick checks 
       on whether a company is already matched could speed up these operations.
       Parallel Processing
    - If the dataset is large and the matching logic is independent across different teams or companies, 
      using parallel processing techniques might offer significant performance improvements. 

## Usage
```
.\Student.Satisfaction.Console.exe "C:\Temp\studentdompany.csv"

```
