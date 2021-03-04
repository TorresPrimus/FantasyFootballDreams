using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFD.GamePlayer
{
    class ProgramUI
    {
        enum Team { Colts = 1, Jaguars }
        enum Position { QB, RB1, RB2, WR1, WR2, TE, DL, LB, DB }

        //private readonly HttpClient _httpClient = new HttpClient();
        //public async Task<Team> GetTeamAsync(string url)
        //{
        //    HttpResponseMessage response = await _httpClient.GetAsync(url);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Team teamID = await response.Content.ReadAsAsync<Team>();
        //        return teamID;
        //    }
        //    return null;
        //}
        //public async Task<Team> GetTeamDetailsAsync(string url)
        //{
        //    HttpResponseMessage response = await _httpClient.GetAsync(url);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Team teamDetails = await response.Content.ReadAsAsync<Team>();
        //        return teamDetails;
        //    }
        //    return null;
        //}

        bool isGameActive = true;
        int playerOneScore = 0;
        int playerTwoScore = 0;

        int possessions = 0;
        int maxPossessions = 4;
        string playerOneChoice;
        string playerTwoChoice;

        static string nameKey = "Name";
        static string positionKey = "Position";
        static string ratingKey = "Rating";

        static string ReturnToTheMainMenu = "Return to the Main Menu";
        static string PleasePressAnyKeyToContinue = "\n\n[ Please press any key to continue ]";

        //Dictionary<string, int> computerTeamSelection = new Dictionary<string, int>
        //{
        //    { "Colts" , 1 },                                                      
        //    { "Jaguars" , 2 },
        //    { "Texans" , 3 },
        //    { "Titans" , 4 },
        //    { "Buccaneers" , 5 },
        //    { "Falcons" , 6 },
        //    { "Panthers" , 7 },
        //    { "Saints" , 8 }
        //};

        Dictionary<string, int> coinToss = new Dictionary<string, int>
        {
            {"Heads" , 1 },
            {"Tails" , 2 }
        };

        Dictionary<string, dynamic>[] coltsPlayerArray = new Dictionary<string, dynamic>[]
        {
            new Dictionary<string, dynamic>
            {
                {nameKey, "Philip Rivers"},
                {positionKey, Position.QB},
                {ratingKey, 84}
            },
            new Dictionary<string, dynamic>
            {
                {nameKey, "Marlon Mack"},
                {positionKey, Position.RB1},
                {ratingKey, 85}
            },
            new Dictionary<string, dynamic>
            {
                {nameKey, "Nyheim Hines"},
                {positionKey, Position.RB2},
                {ratingKey, 80}
            },
            new Dictionary<string, dynamic>
            {
                {nameKey, "T.Y. Hilton"},
                {positionKey, Position.WR1},
                {ratingKey, 86}
            },new Dictionary<string, dynamic>
            {
                {nameKey, "Zach Pascal"},
                {positionKey, Position.WR2},
                {ratingKey, 77}
            },new Dictionary<string, dynamic>
            {
                {nameKey, "Jack Doyle"},
                {positionKey, Position.TE},
                {ratingKey, 81}
            },

            new Dictionary<string, dynamic>
            {
                {nameKey, "DeForest Buckner"},
                {positionKey, Position.DL},
                {ratingKey, 96}
            },new Dictionary<string, dynamic>
            {
                {nameKey, "Justin Houston"},
                {positionKey, Position.DL},
                {ratingKey, 88}
            },new Dictionary<string, dynamic>
            {
                {nameKey, "Darius Leonard"},
                {positionKey, Position.LB},
                {ratingKey, 96}
            },new Dictionary<string, dynamic>
            {
                {nameKey, "Anthony Walker"},
                {positionKey, Position.LB},
                {ratingKey, 84}
            },new Dictionary<string, dynamic>
            {
                {nameKey, "Kenny Moore II"},
                {positionKey, Position.DB},
                {ratingKey, 82}
            },new Dictionary<string, dynamic>
            {
                {nameKey, "Malik Hooker"},
                {positionKey, Position.DB},
                {ratingKey, 83}
            },
        };

        Dictionary<string, dynamic>[] jaguarsPlayerArray = new Dictionary<string, dynamic>[]
        {
            new Dictionary<string, dynamic>
            {
                {nameKey, "Gardner Minshew II"},
                {positionKey, Position.QB},
                {ratingKey, 81}
            },
            new Dictionary<string, dynamic>
            {
                {nameKey, "Leonard Fournette"},
                {positionKey, Position.RB1},
                {ratingKey, 83}
            },
            new Dictionary<string, dynamic>
            {
                {nameKey, "Chris Thompson"},
                {positionKey, Position.RB2},
                {ratingKey, 75}
            },
            new Dictionary<string, dynamic>
            {
                {nameKey, "D.J. Chark Jr."},
                {positionKey, Position.WR1},
                {ratingKey, 88}
            },
            new Dictionary<string, dynamic>
            {
                {nameKey, "Dede Westbrook"},
                {positionKey, Position.WR2},
                {ratingKey, 76}
            },new Dictionary<string, dynamic>
            {
                {nameKey, "Tyler Eifert"},
                {positionKey, Position.TE},
                {ratingKey, 80}
            },

            new Dictionary<string, dynamic>
            {
                {nameKey, "Josh Allen"},
                {positionKey, Position.DL},
                {ratingKey, 90}
            },
            new Dictionary<string, dynamic>
            {
                {nameKey, "Yannick Ngakoue"},
                {positionKey, Position.DL},
                {ratingKey, 94}
            },
            new Dictionary<string, dynamic>
            {
                {nameKey, "Myles Jack"},
                {positionKey, Position.LB},
                {ratingKey, 93}
            },
            new Dictionary<string, dynamic>
            {
                {nameKey, "Joe Schobert"},
                {positionKey, Position.LB},
                {ratingKey, 79}
            },
            new Dictionary<string, dynamic>
            {
                {nameKey, "CJ Henderson"},
                {positionKey, Position.DB},
                {ratingKey, 80}
            },
            new Dictionary<string, dynamic>
            {
                {nameKey, "Ronnie harrison"},
                {positionKey, Position.DB},
                {ratingKey, 75}
            },
        };

        public void Run()
        {
            string titlescreen = "This is the titlescreen";
            Console.WriteLine(titlescreen);
            Console.ReadKey();
            RunMenu();
        }

        public void RunMenu()
        {
            {
                Console.Clear();                                                // Clears everything at the start of the screen
                string startGame = "1. Start Game";                             // Creating our three options on our Run Menu
                string viewTeams = "2. View Teams";
                string exitGame = "3. Exit";                                    // The options are to start the game, view teams or exit
                while (isGameActive == true)                                    // We created a while loop so easily end the game later on
                {
                    Console.WriteLine(startGame + "\n" + viewTeams + "\n" + exitGame);
                    string goodBye = "Goodbye, Thanks for Playing!";
                    string selection = Console.ReadLine();                      // Creating this string for our switch cases, also have it equal
                                                                                // to a ReadLine so the user has to select an option to proceed
                    switch (selection)
                    {
                        case "1":
                            TeamSelection();
                            break;
                        case "2":
                            ViewTeams();
                            break;
                        case "3":
                            Console.WriteLine(goodBye);                         // Console App while also saying goodbye, with padding
                            Environment.Exit(0);                                // This line of code closes the console application and avoids crash
                            break;
                        default:                                                // Important to have this default; since we have it set to Run Menu
                            RunMenu();                                          // it basically restarts this page. Without it, if we pressed anything
                            break;                                              // besides our two cases, we would continue to print those two cases,
                    }                                                           // which looks sloppy and broken
                }
            }
        }

        public void TeamSelection()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Fantasy Football!" + PleasePressAnyKeyToContinue);
            Console.ReadKey();

            Team selectedTeam = Team.Colts;
            Team selectedOpponentTeam = Team.Jaguars;

            string prompt = "Player One, please select your Team!";
            string[] teamNamesArray = Enum.GetNames(typeof(Team));

            (bool returnToMainMenu, int userChoice) = PromptUserToMakeNumericSelection(prompt, teamNamesArray, ReturnToTheMainMenu);
            if (returnToMainMenu)
            {
                RunMenu();
            }
            else
            {
                selectedTeam = (Team)userChoice;
                DisplaySelectedTeam(selectedTeam);
            }

            string opponentChoice = OpponentChoice();

            if (opponentChoice == "9")
            {
                RunMenu();
            }
            else
            {
                selectedOpponentTeam = (Team)Convert.ToInt32(opponentChoice);
                DisplaySelectedTeam(selectedOpponentTeam);
            }

            Console.WriteLine($"\nTodays game will be played between the {selectedTeam} and the {selectedOpponentTeam}");
            PressAnyKeyToContinue();

            Console.WriteLine("Are you ready to begin?");
            Console.WriteLine("\n1. Yes!\n" + "2. No, return to the main menu!\n");

            string areYouReadyToPlay = Console.ReadLine();

            switch (areYouReadyToPlay)
            {
                case "1":
                    CoinToss();
                    break;
                case "2":
                    RunMenu();
                    break;
                default:
                    break;
            }
            InGamePlay(selectedTeam, selectedOpponentTeam);
        }

        public string OpponentChoice()
        {
            Console.Clear();
            Console.WriteLine("Would you like to select your opponent or have it be selected for you?");
            Console.WriteLine("\n1. Select your opponent!\n" + "2. Select to have a random opponent!\n");

            string doYouWantToPickYourOpponent = Console.ReadLine();

            switch (doYouWantToPickYourOpponent)
            {
                case "1":
                    string playerTwoSelection = OpponentUserChoice();
                    return playerTwoSelection;
                case "2":
                    string playerTwoRandomSelection = OpponentRandomChoice();
                    return playerTwoRandomSelection;
                default:
                    return "9";
            }
        }

        public string OpponentUserChoice()
        {
            string prompt = "Player Two, please select your Team!";
            string[] teamNamesArray = Enum.GetNames(typeof(Team));

            (bool returnToMainMenu, int userChoice) = PromptUserToMakeNumericSelection(prompt, teamNamesArray, ReturnToTheMainMenu);
            if (returnToMainMenu)
            {
                return Convert.ToString(teamNamesArray.Count() + 1); // hack to send back last item number string which is number of teams plus one
            }
            else
            {
                return Convert.ToString(userChoice); // hack to send back user choice as string
            }
        }

        private string OpponentRandomChoice()
        {
            Console.Clear();

            string randomTeamSelection = Convert.ToString((int)ComputerTeamSelection());

            Console.WriteLine($"Your opponent will be {randomTeamSelection}!");
            Console.WriteLine($"Here is the starting lineup for the {randomTeamSelection}!");

            return randomTeamSelection;
        }

        public void ViewTeams()
        {
            string prompt = "Pick a team to view";
            string[] teamNamesArray = Enum.GetNames(typeof(Team));

            (bool returnToMainMenu, int userChoice) = PromptUserToMakeNumericSelection(prompt, teamNamesArray, ReturnToTheMainMenu);
            if (returnToMainMenu)
            {
                RunMenu();
            }
            else
            {
                Team selectedTeam = (Team)userChoice;
                DisplaySelectedTeam(selectedTeam);
            }

            ViewTeams();

            // At least 2 methods similar to swapi, to bring in Teams and Team Details from API
        }

        public void CoinToss()
        {
            //string coinTossFlip = CoinTossResult(coinToss); // Doesn't work yet, coin toss doesn't attach to a player

            Console.Clear();
            Console.WriteLine("It's time to do the coin toss, would you like Heads or Tails?");
            Console.WriteLine("\n1. Heads\n" + "2. Tails\n");
            string input = Console.ReadLine();
            if (input == "1" || input == "Heads")
            {
                Console.Write("Congratulations, it's Heads! You get the ball first!");
            }
            else if (input == "2" || input == "Tails")
            {
                Console.Write("Congratulations, it's Tails! You get the ball first!");
            }
            else
            {
                Console.WriteLine("Not a correct input. Press 'enter' to continue.");
                Console.ReadLine();
                CoinToss();
            }
            //Console.WriteLine(coinTossFlip);
            Console.ReadKey();
        }

        private void InGamePlay(Team homeTeam, Team awayTeam)
        {
            Console.Clear();

            while (possessions < maxPossessions)
            {
                playerOneChoice = PlayerOneSelection(homeTeam, awayTeam);
                playerTwoChoice = PlayerTwoSelection(awayTeam, homeTeam);

                Console.WriteLine($"The Score is {playerOneScore} - {playerTwoScore}");
                Console.ReadLine();

                possessions++;
            }

            ScoreTable();

            // Maybe include a small % for QB run here
            // If team gets 75 or more than touchdown 6points, then choice to go for 1 or 2
            // 95% for 1 point 50% for 2 points
            // Could include a small % based on Defense Stats to include a turnover during opponents possession
            // For example 5% chance of a sack = loss of play or even loss of yards on play
            // Interception or Fumble equals possession ending
        }

        private string PlayerOneSelection(Team activeTeam, Team inactiveTeam)
        {
            Console.Clear();

            int plays = 0;
            int maxPlays = 4;
            int totalYards = 0;
            int nflFieldGoalYards = 0;

            while (plays < maxPlays)
            {

                Console.WriteLine("Player 1, choose what kind of play you want?\n" + "1. Pass\n" + "2. Run\n");

                string playerOneSelection = Console.ReadLine();
                int currentPlayYards = 0;

                switch (playerOneSelection)
                {
                    case "1":
                        currentPlayYards = GetInGamePassYards(activeTeam);
                        break;
                    case "2":
                        currentPlayYards = GetInGameRunYards(activeTeam);
                        break;
                    default:
                        PlayerOneSelection(activeTeam, inactiveTeam); // todo: maybe fix... should this really call self again?
                        break;
                }

                plays++;
                totalYards += currentPlayYards;

                Console.ReadLine();
                Console.WriteLine($"\nPlayer One has gained {currentPlayYards} for a total of {totalYards} yards on this drive!");

                nflFieldGoalYards = 92 - totalYards;

                Console.ReadLine();
                Console.Clear();
            }

            if (totalYards < 30)
            {
                Console.WriteLine("Player One turned the ball over on downs!");
                Console.ReadLine();
            }
            else if (totalYards < 75)
            {
                Console.WriteLine($"Player One is going to try a {nflFieldGoalYards} yard field Goal!");
                Console.ReadLine();

                int fieldGoal = GetFieldGoalDistanceRandomizer(activeTeam, nflFieldGoalYards);

                Console.WriteLine(fieldGoal);
                Console.ReadLine();

                playerOneScore += fieldGoal;
            }
            else
            {
                Console.WriteLine("Player One scored a TOUCHDOWN!");
                Console.ReadLine();

                playerOneScore += 7;
            }
            return null;
        }

        private string PlayerTwoSelection(Team activeTeam, Team inactiveTeam)
        {
            Console.Clear();

            int plays = 0;
            int maxPlays = 4;
            int totalYards = 0;
            int nflFieldGoalYards = 0;

            while (plays < maxPlays)
            {

                Console.WriteLine("Player 2, choose what kind of play you want?\n" + "1. Pass\n" + "2. Run\n");

                string playerTwoSelection = Console.ReadLine();
                int currentPlayYards = 0;

                switch (playerTwoSelection)
                {
                    case "1":
                        currentPlayYards = GetInGamePassYards(activeTeam);
                        break;
                    case "2":
                        currentPlayYards = GetInGameRunYards(activeTeam);
                        break;
                    default:
                        PlayerTwoSelection(activeTeam, inactiveTeam); // todo: should this call itself ???
                        break;
                }

                plays++;
                totalYards += currentPlayYards;

                Console.ReadLine();
                Console.WriteLine($"Player Two has gained {currentPlayYards} for a total of {totalYards} yards on this drive!");

                nflFieldGoalYards = 92 - totalYards;

                Console.ReadLine();
                Console.Clear();
            }
            if (totalYards < 30)
            {
                Console.WriteLine("Player Two turned the ball over on downs!");
                Console.ReadLine();
            }
            else if (totalYards < 75)
            {
                Console.WriteLine($"Player Two is going to try a {nflFieldGoalYards} yard field Goal!");
                Console.ReadLine();

                int fieldGoal = GetFieldGoalDistanceRandomizer(activeTeam, nflFieldGoalYards);

                Console.WriteLine(fieldGoal);
                Console.ReadLine();

                playerTwoScore += fieldGoal;
            }
            else
            {
                Console.WriteLine("Player Two scored a TOUCHDOWN!");
                Console.ReadLine();

                playerTwoScore += 7;
            }
            return null;
        }

        private void ScoreTable()
        {
            if (possessions == maxPossessions)
            {
                if (playerOneScore > playerTwoScore)
                {
                    string playerWin = "Player One Wins";

                    Console.WriteLine(playerWin.PadLeft(59));
                    Console.ReadKey();

                    isGameActive = false;                                   // Stops the game from continuing
                    Environment.Exit(0);                                    // This line of code closes the console application and avoids crash
                }
                else
                {
                    string playerLose = "Player Two Wins";

                    Console.WriteLine(playerLose.PadLeft(59));
                    Console.ReadKey();

                    isGameActive = false;                                   // Stops the game from continuing
                    Environment.Exit(0);                                    // This line of code closes the console application and avoids crash
                }
            }
        }

        private int GetInGamePassYards(Team team)
        {
            Dictionary<string, dynamic> qbDictionary = GetPlayerDictionaryByPosition(Position.QB, team);
            Dictionary<string, dynamic> rb1Dictionary = GetPlayerDictionaryByPosition(Position.RB1, team);
            Dictionary<string, dynamic> rb2Dictionary = GetPlayerDictionaryByPosition(Position.RB2, team);
            Dictionary<string, dynamic> wr1Dictionary = GetPlayerDictionaryByPosition(Position.WR1, team);
            Dictionary<string, dynamic> wr2Dictionary = GetPlayerDictionaryByPosition(Position.WR2, team);
            Dictionary<string, dynamic> teDictionary = GetPlayerDictionaryByPosition(Position.TE, team);

            if (GetIfThePassIsCompleteRandomizer() <= 80)
            {
                Console.Write($"QB {qbDictionary[nameKey]} completes a ");

                if (GetWhoIsCatchingThePass() <= 5)
                {
                    Console.WriteLine($"{RB2YardRandomizer()} yard pass to RB {rb2Dictionary[nameKey]}.");
                    return RB2YardRandomizer();
                }
                else if (GetWhoIsCatchingThePass() <= 15)
                {
                    Console.WriteLine($"{RB1YardRandomizer()} yard pass to RB {rb1Dictionary[nameKey]}.");
                    return RB1YardRandomizer();
                }
                else if (GetWhoIsCatchingThePass() <= 35)
                {
                    Console.WriteLine($"{TEYardRandomizer()} yard pass to TE {teDictionary[nameKey]}.");
                    return TEYardRandomizer();
                }
                else if (GetWhoIsCatchingThePass() <= 65)
                {
                    Console.WriteLine($"{WR2YardRandomizer()} yard pass to WR {wr2Dictionary[nameKey]}.");
                    return WR2YardRandomizer();
                }
                else
                {
                    Console.WriteLine($"{WR1YardRandomizer()} yard pass to WR {wr1Dictionary[nameKey]}.");
                    return WR1YardRandomizer();
                }
            }
            else
            {
                Console.WriteLine($"QB {qbDictionary[nameKey]} throws an incomplete pass!");
                return 0;
            }
        }

        private int GetInGameRunYards(Team team)
        {
            Dictionary<string, dynamic> rb1Dictionary = GetPlayerDictionaryByPosition(Position.RB1, team);
            Dictionary<string, dynamic> rb2Dictionary = GetPlayerDictionaryByPosition(Position.RB2, team);

            if (RunningRandomizer() <= 20)
            {
                int rb2Yards = RB2YardRandomizer();
                Console.WriteLine($"{rb2Dictionary[nameKey]} ran the ball for {rb2Yards} yards!");
                return rb2Yards;
            }
            else
            {
                int rb1Yards = RB1YardRandomizer();
                Console.WriteLine($"{rb1Dictionary[nameKey]} ran the ball for {rb1Yards} yards!");
                return rb1Yards;
            }
        }

        private int GetFieldGoalDistanceRandomizer(Team team, int nflFieldGoalYards)
        {
            if (nflFieldGoalYards <= 34)
            {
                if (FieldGoalRandomizer() <= 30)
                {
                    Console.WriteLine("The Field Goal was GOOD!");
                    return 3;
                }
                else
                {
                    Console.WriteLine("The Field Goal was NOT GOOD!");
                    return 0;
                }
            }
            else if (nflFieldGoalYards <= 39)
            {
                if (FieldGoalRandomizer() <= 50)
                {
                    Console.WriteLine("The Field Goal was GOOD!");
                    return 3;
                }
                else
                {
                    Console.WriteLine("The Field Goal was NOT GOOD!");
                    return 0;
                }
            }
            else if (nflFieldGoalYards <= 44)
            {
                if (FieldGoalRandomizer() <= 60)
                {
                    Console.WriteLine("The Field Goal was GOOD!");
                    return 3;
                }
                else
                {
                    Console.WriteLine("The Field Goal was NOT GOOD!");
                    return 0;
                }
            }
            else if (nflFieldGoalYards <= 54)
            {
                if (FieldGoalRandomizer() <= 75)
                {
                    Console.WriteLine("The Field Goal was GOOD!");
                    return 3;
                }
                else
                {
                    Console.WriteLine("The Field Goal was NOT GOOD!");
                    return 0;
                }
            }
            else if (nflFieldGoalYards <= 64)
            {
                if (FieldGoalRandomizer() <= 85)
                {
                    Console.WriteLine("The Field Goal was GOOD!");
                    return 3;
                }
                else
                {
                    Console.WriteLine("The Field Goal was NOT GOOD!");
                    return 0;
                }
            }
            else if (nflFieldGoalYards <= 74)
            {
                if (FieldGoalRandomizer() <= 95)
                {
                    Console.WriteLine("The Field Goal was GOOD!");
                    return 3;
                }
                else
                {
                    Console.WriteLine("The Field Goal was NOT GOOD!");
                    return 0;
                }
            }
            return default;
        }

        // R A N D O M I Z E R S

        private int RunningRandomizer()
        {
            Random yards = new Random();
            int runningBack = yards.Next(1, 101);
            return runningBack;
        }

        private int RB1YardRandomizer()
        {
            Random yards = new Random();
            int runYards = yards.Next(1, 25);
            return runYards;
        }

        private int RB2YardRandomizer()
        {
            Random yards = new Random();
            int runYards = yards.Next(0, 12);
            return runYards;
        }

        private int TEYardRandomizer()
        {
            Random yards = new Random();
            int receivingYards = yards.Next(7, 23);
            return receivingYards;
        }

        private int WR1YardRandomizer()
        {
            Random yards = new Random();
            int receivingYards = yards.Next(9, 31);
            return receivingYards;
        }

        private int WR2YardRandomizer()
        {
            Random yards = new Random();
            int receivingYards = yards.Next(7, 21);
            return receivingYards;
        }

        private int GetIfThePassIsCompleteRandomizer()
        {
            Random yards = new Random();
            int completion = yards.Next(1, 101);
            return completion;
        }

        private int GetWhoIsCatchingThePass()
        {
            Random yards = new Random();
            int receiver = yards.Next(1, 101);
            return receiver;
        }
        private int FieldGoalRandomizer()
        {
            Random yards = new Random();
            int fieldGoal = yards.Next(1, 101);
            return fieldGoal;
        }

        //private string CoinTossResult(Dictionary<string, int> coinToss)
        //{
        //    Console.Clear();
        //    Random rand = new Random();
        //    int num = rand.Next(1, 3);
        //    foreach (var data in coinToss)
        //    {
        //        if (data.Value == num)
        //        {
        //            return data.Key;
        //        }
        //    }
        //    return null;
        //}

        private Team ComputerTeamSelection()
        {
            Console.Clear();
            Random rand = new Random();
            Team num = (Team)rand.Next(1, 3);
            return num;
        }

        private Dictionary<string, dynamic>[] GetPlayerArrayForTeam(Team team)
        {
            Dictionary<string, dynamic>[] playerArray = coltsPlayerArray;
            switch (team)
            {
                case Team.Colts:
                    // already set above on line 814
                    break;
                case Team.Jaguars:
                    playerArray = jaguarsPlayerArray;
                    break;
            }
            return playerArray;
        }

        private Dictionary<string, dynamic> GetPlayerDictionaryByPosition(Position position, Team team)
        {
            foreach (Dictionary<string, dynamic> playerDictionary in GetPlayerArrayForTeam(team))
            {
                if (playerDictionary[positionKey] == position)
                {
                    return playerDictionary;
                }
            }
            return null;
        }

        private void DisplaySelectedTeam(Team selectedTeam)
        {
            Console.Clear();
            Console.WriteLine($"You have picked the {selectedTeam}!");
            Console.WriteLine($"Here is the starting lineup for the {selectedTeam}!\n");
            foreach (Dictionary<string, dynamic> player in GetPlayerArrayForTeam(selectedTeam)) // get from specific team array
            {
                Console.WriteLine($"Name:{player[nameKey]}, Position:{player[positionKey]}, Rating:{player[ratingKey]}");
            }
            PressAnyKeyToContinue();
        }

        // Convenience Function
        private void PressAnyKeyToContinue()
        {
            Console.WriteLine(PleasePressAnyKeyToContinue);
            Console.ReadKey();
        }

        private (bool alternateOptionChosen, int numericSelection) PromptUserToMakeNumericSelection(string prompt, string[] options, string alternateOption)
        {
            bool userChoseAlternateOption = false;
            int usersNumericChoice = 0;
            bool userEnteredValidChoice = false;

            while (userEnteredValidChoice == false) // keep prompting until user enters a valid choice
            {
                Console.Clear();
                Console.WriteLine(prompt); // display the prompt
                string buildOptionsList = "\n";
                int index = 1;
                foreach (string option in options) // build options listing
                {
                    buildOptionsList = buildOptionsList + index.ToString() + ". " + option + "\n";
                    index++;
                }
                // it is important to note that index is now the value of the last item in the list (the number of the alternate option)
                buildOptionsList = buildOptionsList + "\n" + index.ToString() + ". " + alternateOption + "\n"; // add alternate option to listing
                Console.WriteLine(buildOptionsList); // display the main options and the alternate option

                string readString = Console.ReadLine();
                if (int.TryParse(readString, out int parsedNumber)) // yes, readString was parsed as a number, parsedNumber is now valid
                {
                    if (parsedNumber == index) // did the user choose the alternate option (the last option in the list)
                    {
                        userChoseAlternateOption = true;
                        userEnteredValidChoice = true; // will not keep prompting user for valid input since user entered a valid number
                    }
                    else if (parsedNumber > 0 && parsedNumber < index) // make sure the valid number entered is in the range of the available options
                    {
                        usersNumericChoice = parsedNumber;
                        userEnteredValidChoice = true; // will not keep prompting user for valid input since user entered a valid number
                    }
                    else
                    {
                        // the user has entered a number but the number was not a valid choice, user will be prompted to try again
                    }
                }
                else
                {
                    // the user entered a non-numeric number that could not be parsed as a number, user will be prompted to try again
                }
                if (userEnteredValidChoice == false)
                {
                    Console.WriteLine("\nPlease choose a valid option from the list above");
                    PressAnyKeyToContinue();
                }
            }
            return (userChoseAlternateOption, usersNumericChoice);
        }
    }
}