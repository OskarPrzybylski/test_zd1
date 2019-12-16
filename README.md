### Application interface v1

#### Endpoints
##### /string?s={valueToReverse} - endpoint for getting reversed string
##### /string/check/upper?s={value} - endpoint for checking string contains any upper letters
##### /string/check/lower?s={value} - endpoint for checking string contains any lower letters
##### /string/check/number?s={value} - endpoint for checking string contains any numbers
##### /string/check/special?s={value} - endpoint for checking string contains any special letters
##### /events?year={year}&month={month} - endpoint for getting weeia events by year and month


#### Parameters
##### valueToReverse - string to reverse
##### value - [required] string which operations will be made ons
##### year - [required] year to take events by
##### month - [required] month to take events by

#### Return
##### /string/check/* - all endpoints return value false or true
##### /string - returns reversed string
##### /events - returns ical format with all weeia events by requested year and month
