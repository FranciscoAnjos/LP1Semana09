using System;
using System.Collections.Generic;

namespace PlayerManager3 // >>> Change to PlayerManager2 for exercise 4 <<< //
{
    /// <summary>
    /// The player listing program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The list of all players.
        /// </summary>
        private List<Player> _playerList;

        /// <summary>
        /// Program begins here.
        /// </summary>
        private static void Main()
        {
            // Create a new instance of the player listing program
            Program prog = new Program();
            // Start the program instance
            prog.Start();
        }

        /// <summary>
        /// Creates a new instance of the player listing program.
        /// </summary>
        private Program()
        {
            // Initialize the player list with two players using collection
            // initialization syntax
            _playerList = new List<Player>
            {
                new Player("Best player ever", 100),
                new Player("An even better player", 500)
            };
        }

        /// <summary>
        /// Start the player listing program instance
        /// </summary>
        private void Start()
        {
            // We keep the user's option here
            string option;

            // Main program loop
            do
            {
                // Show menu and get user option
                ShowMenu();
                option = Console.ReadLine();

                // Determine the option specified by the user and act on it
                switch (option)
                {
                    case "1":
                        InsertPlayer();
                        break;
                    case "2":
                        ListPlayers(_playerList);
                        break;
                    case "3":
                        ListPlayersWithScoreGreaterThan();
                        break;
                    case "4":
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.Error.WriteLine("\n>>> Unknown option! <<<\n");
                        break;
                }

                // Wait for user to press a key...
                Console.Write("\nPress any key to continue...");
                Console.ReadKey(true);
                Console.WriteLine("\n");

                // Loop keeps going until players choses to quit (option 4)
            } while (option != "4");
        }

        /// <summary>
        /// Shows the main menu.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine("Player Manager");
            Console.WriteLine("==============");
            Console.WriteLine("1. Insert new player");
            Console.WriteLine("2. List all players");
            Console.WriteLine("3. List players with score greater than...");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option (1-4): ");
        }

        /// <summary>
        /// Inserts a new player in the player list.
        /// </summary>
        private void InsertPlayer()
        {
            Console.Write("Enter player name: ");
            string name = Console.ReadLine();

            int score;
            while (true)
            {
                Console.Write("Enter player score: ");
                string input = Console.ReadLine();
                
                if (int.TryParse(input, out score))
                {
                    break;
                }
                
                Console.WriteLine("Invalid score. Please enter a valid integer.");
            }

            _playerList.Add(new Player(name, score));
            Console.WriteLine("Player added successfully!");
        }

        /// <summary>
        /// Show all players in a list of players. This method can be static
        /// because it doesn't depend on anything associated with an instance
        /// of the program. Namely, the list of players is given as a parameter
        /// to this method.
        /// </summary>
        /// <param name="playersToList">
        /// An enumerable object of players to show.
        /// </param>
        private static void ListPlayers(IEnumerable<Player> playersToList)
        {
            Console.WriteLine("Listing players:");
            Console.WriteLine("----------------");

            List<Player> sortedList = new List<Player>(playersToList);
            sortedList.Sort();

            foreach (Player player in sortedList)
            {
                Console.WriteLine($"{player.Name}, score: {player.Score}");
            }
        }

        /// <summary>
        /// Show all players with a score higher than a user-specified value.
        /// </summary>
        private void ListPlayersWithScoreGreaterThan()
        {
            int minScore;
            
            while (true)
            {
                Console.Write("Enter minimum score: ");
                string input = Console.ReadLine();
                
                if (int.TryParse(input, out minScore))
                {
                    break;
                }
                
                Console.WriteLine("Invalid number. Please enter a valid integer.");
            }

            IEnumerable<Player> filteredPlayers = GetPlayersWithScoreGreaterThan(minScore);
            ListPlayers(filteredPlayers);
        }

        /// <summary>
        /// Get players with a score higher than a given value.
        /// </summary>
        /// <param name="minScore">Minimum score players should have.</param>
        /// <returns>
        /// An enumerable of players with a score higher than the given value.
        /// </returns>
        private IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            foreach (Player player in _playerList)
            {
                if (player.Score > minScore)
                {
                    yield return player;
                }
            }
        }
    }
}
