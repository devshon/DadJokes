# Dad Jokes Web Application
A simple web application that utilizes the [*icanhazdadjoke* public API](https://icanhazdadjoke.com/api). 

## Technologies
* The backend is writen in **C#**
* An **ASP.NET Core Web App** is used to present a frontend
* Standard **MVC** pattern is followed 
* Target Framework is **.NET 5.0** ([Download SDK and Runtime](https://dotnet.microsoft.com/download/dotnet/5.0))
* **Newtonsoft.JSON** is used for deserializing API respones to .NET types

## Features
This web application has two main features that are similar to the [*icanhazdadjoke* website](https://icanhazdadjoke.com/):

1. Webpage that fetches a random joke.
1. Webpage that accepts a search term and returns up to the first 30 results that contain it.
    * Search term is emphasized in results by all uppercase. 
    * Results are grouped into 3 categories based on word length: short, medium, and long.
        * Short: Less than 10 words.
        * Medium: More than 10 words and less than 20 words.
        * Long: 20 or more words.

### Fetching a random joke
Navigate to the *Random* webpage by clicking the link the navigation bar. A random joke is automatically fetched on each request to this page. Refresh your browser window to fetch a new random joke. 

### Searching for jokes
Navigate to the *Search* webpage by clicking the link in the navigation bar. Type your search term in the text field and click the *Search* button to submit your request. The search will look for jokes that *contain* the search term.

```
Ex. A search for "me" will return results with words like ME, MEat, hoME, coMEt.
```

#### Searching with multiple terms
The DadJoke API does support mutliple terms when searching. It will split the terms on whitespace and use an OR operation when searching. 

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

## Implementation

### IJokeService

### DadJokeService

### POCOs
