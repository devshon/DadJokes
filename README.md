# Dad Jokes Web Application
A simple web application for dad jokes. It allows users to search for dad jokes or fetch a random one.

## Technologies
* The backend is writen in **C#**
* An **ASP.NET Core Web App** is used to present a frontend
* Standard **MVC** pattern is followed 
* Target Framework is **.NET 5.0** ([Download SDK and Runtime](https://dotnet.microsoft.com/download/dotnet/5.0))
* **Newtonsoft.JSON** is used for deserializing *JSON* respones to *.NET types*
* Utilizes the [*icanhazdadjoke* public API](https://icanhazdadjoke.com/api)

## Features
This web application has two main features that are similar to the [*icanhazdadjoke* website](https://icanhazdadjoke.com/):

1. Webpage that fetches a random joke.
1. Webpage that accepts a search term and returns up to the first 30 results that contain it.

### Fetching a random joke
Navigate to the *Random* webpage by clicking the link the navigation bar. A random joke is automatically fetched on each request to this page. Refresh your browser window to fetch a new random joke. 

### Searching for jokes
Navigate to the *Search* webpage by clicking the link in the navigation bar. Type your search term in the text field and click the *Search* button to submit your request. The search will look for jokes that contain the search term. The *icanhazdadjoke API* **_appears to_** return jokes with words that either *begins with*, *ends with*, or *are* the search term.

```
Ex. A search for "are" will return results with words such as "AREna", "squARE", "ARE", but it will not return jokes with words such as "appAREntly".
```

#### Searching with multiple terms
The *icanhazdadjoke API* **_appears to_** support multiple terms when searching so the web application will as well. It will pass the search term to the API as-is. The API appears to split the terms on the whitespaces and will use an OR operation for searching.

```
Ex. A search for "cat dog" will return jokes that contain "cat" or "dog". 
```

#### Search Results
A maximum of 30 jokes will be returned in a search result. 

The search term is emphasized with all UPPERCASE letters.

The results are grouped into 3 categories:
* Short: Less than 10 words.
* Medium: 10 or more words but less than 20.
* Long: 20 or more words.
