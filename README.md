# FantasyFootballDreams
This project utilizes c#, asp.net, and n-tier architecture. Our API allows you to create players. Each player has their own stats. All players can be assigned to teams. Teams can also face eachother in a fantasy match-up game to determine the stronger team and the winner.

Prereqisites
This project was built using:

Visual Studio 2019 - Visual Studio 2019 Community.

Postman - Postman Api Development Environment

Github - Code Repository, Team collaboration, where our project is hosted.
Getting Started

There are two ways to obtain the code. You can download the project as a zip file or clone the repository. If you choose to download the zip file you can then expand it in your choosen location. The prefered method of obtaining the project is by using the command-line Git utility. There is a clip-board friendly Git link right next to the download option. That Git link will allow you to clone the repository using the command line. Either way you obtain the project you can either double click on the solution file in the main directory or open it within Visual Studio.

Once you have the project open there are two aspects to this project. There is an API which accessible using the Postman utility or through the launch page in your browser. Through this API you can view, delete, edit, and create players. Each player has a list of realistic stats. Each player is also assigned to a team which is completely customizable.

The console application is a proof of concept that mirrors our api Player/Team structure and allows you to create a fantasy matchup between the teams of your choice.

API Endpoints
One you register and receive a token you have access to the API.

Players can be created with the following attributes:

Api/Player - These are the base stats every player needs.

PlayerFirstName PlayerLastName 

PlayerPosition PlayerJerseyNumber

PlayerHeightByINches PlayerWeightByPounds  

TeamId

Api/PlayerStats - these extended stats apply to all players as well.

PassingYards PassingTouchdowns 

InterceptionThrown RushingYards

RushingAttempts RushingTouchDowns 

ReceivingYards Catches

ReceivingTouchDowns Fumbles 

Tackles Sacks Interceptions

ForcedFumbles FumbleRecovery 

Safety BlockedKick

ReturnTouchDown
