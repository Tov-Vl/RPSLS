# RPSLS

### Description
A Web API-based service for playing the "Rock, Paper, Scissors, Lizard, Spock" game from the famous "The Big Bang Theory" show.

Backend is built on top of ASP.NET Core.  
Frontend UI implemented via React javascript library.

### Endpoints

#### 1. Choices
Get all the choices that are usable for the UI.
* GET: /choices  
Result: `application/json`
```
[
  {
    "id": integer [1-5],
    "name": string [12] (rock, paper, scissors, lizard, spock)
  }
]
```

#### 2. Choice
Get a randomly generated choice.
* GET: /choice  
Result: `application/json`
```
{
  "id": integer [1-5],
  "name" : string [12] (rock, paper, scissors, lizard, spock)
}
```

#### 3. Play
Play a round against a computer opponent.
* POST: /play  
Data: `application/json`
```
{
  "player": choice_id
}
```
Result: `application/json`
```
{
  "results": string (win, lose, tie),
  "player": choice_id,
  "computer": choice_id
}
```

#### 4. Scoreboard Get
Get a scoreboard of the most recent game results.
* GET: /scoreboard/get  
Result: `application/json`
```
[
  {
    "player_one_name": string,
    "player_one_gesture": integer [1-5],
    "player_two_name": string,
    "player_two_gesture": integer [1-5],
    "results": string (win, lose, tie)
  }
]
```

#### 4. Scoreboard Reset
Get a scoreboard of the most recent game results.
* PUT: /scoreboard/reset  
Result: `Status Code`

### Note
You can test all of these endpoints using Swagger UI from the `service_url`/swagger endpoint.

## Installation

#### 1. Clone repository.
#### 2. Follow this instruction starting from "Set the project properties": [Tutorial: Create an ASP.NET Core app with React in Visual Studio](https://learn.microsoft.com/en-us/visualstudio/javascript/tutorial-asp-net-core-with-react?view=vs-2022#set-the-project-properties).

## Settings
Settings for the service are located in the RPSLS-Server's `appsettings.json` file.  
React's proxy settings are located in the `src/setupProxy.js` file.  
Custom settings are as follows:
* RandomNumberServiceOptions
  * BaseUrl - URL to the random number providing service.  
    The response is expected to be in the following format:
    * GET: `BaseUrl`  
    Result: `application/json`  
    `{ "random_number": integer [1-100] }`  

    Default value: https://codechallenge.boohma.com/random.
* ScoreboardOptions
  * Limit - max number of rows in the scoreboard table.  
    Default value: 10.

## Screenshots
<img
  src="https://user-images.githubusercontent.com/63316608/220223127-82a17537-a92a-4550-a7b2-09d07ec87f7d.png"
  title="Home page"
  style="display: inline-block; margin: 0 auto; width: 50%">
<img
  src="https://user-images.githubusercontent.com/63316608/220487996-9bd5550e-abe9-4d5d-850c-7ddc1376a3cd.png"
  title="Scoreboard"
  style="display: inline-block; margin: 0 auto; width: 50%">

## ToDo
- [ ] Provide codebase coverage with unit tests.
- [ ] Allow multiple users to play on the same service.
- [ ] Provide a Dockerfile to run a containerized version of the service.
- [ ] Add user authentication (to store the scoreboard info based on the user's id).

## References
* [How to create a Dropdown select component in React?](https://medium.com/tinyso/how-to-create-a-dropdown-select-component-in-react-bf85df53e206): Thi Tran's blogpost.
* [Adding decorated classes to the ASP.NET Core DI container using Scrutor](https://andrewlock.net/adding-decorated-classes-to-the-asp.net-core-di-container-using-scrutor/): Andrew Lock's blogpost.
* [RPSLS Game in C#](https://codereview.stackexchange.com/a/36491): ChrisWue's answer.
