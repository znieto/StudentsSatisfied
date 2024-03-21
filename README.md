# Coding challenge


## High-Level Approach

    - Parse the CSV: Load the CSV file to extract the priorities assigned by teams to companies and vice versa. 
    - Matching Algorithm: Implement a variation of the Gale-Shapley algorithm tailored to handle cases where not all parties have ranked all the others, 
    and parties can leave preferences blank.
    - Output: The algorithm will produce a set of pairs indicating which team is matched with which company, aiming to satisfy the highest priorities on both sides as much as possible.

### Services Used:
    - CsvService: Responsible for reading the CSV file and converting the data into a format usable by the application.
    - PreferenceService: Handles the creation and management of preference lists for teams and companies.
    - MatchingService: Implements the matching algorithm, relying on preferences provided by the PreferenceService.
    - OutputService: Manages output formatting and presentation, such as displaying match results.


## Assumptions

    Incomplete Lists: Both teams and companies might not rank all the opposite parties. The algorithm must handle such cases gracefully.
    Unique Matches: Each team is matched with exactly one company, and vice versa, wherever possible.
    Preference for Filled Rankings: If a team or company ranks another, it indicates a preference to be matched over having no match at all.
    No empty Lists: There must be at least one team and one company. 


## Important Test Cases

    All Teams and Companies Have Complete Rankings: Ensures the basic functionality works.
    Some Entities Have Incomplete Rankings: Tests the algorithm's ability to handle incomplete preferences.
    One Side Has More Entities Than the Other: Verifies how the algorithm deals with potential unmatched entities.
    Mutual Highest Priority: Confirms that entities that rank each other as their top choice are matched.