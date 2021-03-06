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

The console application is a proof of concept that mirrors our api Player/Team structure and allows you to create a fantasy matchup between the teams of your choice. To launch the cconsole app set fasntasyFD.Gameplayer as start up and launch the api, it will open a console app where you can play the game

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

Games can be created with the following attributes:

DateOfGame

Games can be updated with the following attributes:

HomeTeam AwayTeam

HomeScore AwayScore

GameId

Sources:
https://stackoverflow.com/questions/52478984/ef-6-0-many-to-many-relationship-is-not-working-in-codefirst
https://stackoverflow.com/questions/37867659/cannot-insert-the-value-null-into-column-where-using-sql-select-statement/37867709
https://stackoverflow.com/questions/9817860/unable-to-generate-an-explicit-migration-in-entity-framework
https://stackoverflow.com/questions/52268985/may-cause-cycles-or-multiple-cascade-paths-specify-on-delete-no-action-or-on-up
https://forums.asp.net/t/2015180.aspx?Two+foreign+keys+referencing+1+class+issue
https://stackoverflow.com/questions/17127351/introducing-foreign-key-constraint-may-cause-cycles-or-multiple-cascade-paths
https://stackoverflow.com/questions/40090288/unable-to-determine-a-composite-foreign-key-ordering-for-foreign-key
https://elevenfifty.instructure.com/courses/550/pages/eleven-note-10-dot-00-migrations?module_item_id=39722
https://stackoverflow.com/questions/1256757/sequence-contains-more-than-one-element/1256784
https://stackoverflow.com/questions/22691622/sequence-contains-more-than-one-element-singleordefault-not-helping
https://www.codeproject.com/Questions/806655/Sequence-contains-more-than-one-element
https://forums.asp.net/t/2015180.aspx?Two+foreign+keys+referencing+1+class+issue
https://docs.microsoft.com/en-us/aspnet/web-api/overview/getting-started-with-aspnet-web-api/creating-api-help-pages#adding-api-documentation
