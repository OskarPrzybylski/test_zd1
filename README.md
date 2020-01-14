### Application interface v1


### Employees endpoints
##### GET /employees/search?name={name} - endpoint for getting employees by name, returns list of employees
##### GET /employees/vcard?fullName={fullName} - endpoint for getting vcard for specific employee, returns vcard type
#### Parameters
##### name - string, that name or surname of employee contains
##### fullName - string, full name and surname of employee


#### Endpoints
##### GET /string?s={valueToReverse} - endpoint for getting reversed string
##### GET /string/check/upper?s={value} - endpoint for checking string contains any upper letters
##### GET /string/check/lower?s={value} - endpoint for checking string contains any lower letters
##### GET /string/check/number?s={value} - endpoint for checking string contains any numbers
##### GET /string/check/special?s={value} - endpoint for checking string contains any special letters
##### GET /events?year={year}&month={month} - endpoint for getting weeia events by year and month

#### Parameters
##### valueToReverse - string to reverse
##### value - [required] string which operations will be made ons
##### year - [required] year to take events by
##### month - [required] month to take events by

#### Return
##### /string/check/* - all endpoints return value false or true
##### /string - returns reversed string
##### /events - returns ical format with all weeia events by requested year and month
