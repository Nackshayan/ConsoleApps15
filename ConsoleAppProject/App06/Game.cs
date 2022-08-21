using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App06
{
    /// <summary>
    /// This class stores the model for the RPS game, and controls
    /// the starting of the game, the computer choice, scoring each
    /// round and determining a winner at the end of the game
    /// </summary>
    /// <author>
    /// Nackshayan 13/08/2022
    /// </author> 
    public class Game
    {
        public const int MAX_ROUND = 10;

        public int Round { get; set; }
        public double LastRound { get; set; }
        public Player Human { get; }
        public Player Computer { get; }
        public Player CurrentPlayer { get; set; }
        public Player Winner { get; set; }
        private Random generator = new Random(55);

        /// <summary>
        /// Constructor for objects of class Game
        /// </summary>
        public Game(string name)
        {
            Human = new Player(name, GamePlayers.Player);
            Computer = new Player("Computer", GamePlayers.Computer);

            Round = 0;
        }

        /// <summary>
        /// This method starts a new game and initialises default
        /// values, such as setting the scores to 0 and setting the
        /// round to round 1
        /// </summary>
        public void Start()
        {
            Round = 1;
            LastRound = 1;

            CurrentPlayer = Human;

            Human.Score = 0;
            Computer.Score = 0;
        }

        /// <summary>
        /// This method uses a random generator for the computer to
        /// its choice from the options available in the GameChoices
        /// enumeration
        /// </summary>
        public void MakeComputerChoice()
        {
            int choice = generator.Next(1, 4);

            switch (choice)
            {
                case 1: Computer.Choice = GameChoices.Paper; 
                    break;
                case 2: Computer.Choice = GameChoices.Rock; 
                    break;
                case 3: Computer.Choice = GameChoices.Scissors; 
                    break;
            }
        }

        /// <summary>
        /// This method awards a score to the player for each round
        /// according to the choice they made compared to that of the 
        /// other player
        /// </summary>
        public void ScoreRound()
        {
            if (Human.Choice == GameChoices.Rock &&
               Computer.Choice == GameChoices.Paper)
            {
                Computer.Score += 2;
                Winner = Computer;
            }

            else if (Human.Choice == GameChoices.Rock &&
               Computer.Choice == GameChoices.Scissors)
            {
                Human.Score += 2;
                Winner = Human;
            }

            else if (Human.Choice == GameChoices.Paper &&
               Computer.Choice == GameChoices.Rock)
            {
                Human.Score += 2;
                Winner = Human;
            }

            else if (Human.Choice == GameChoices.Paper &&
               Computer.Choice == GameChoices.Scissors)
            {
                Computer.Score += 2;
                Winner = Computer;
            }

            else if (Human.Choice == GameChoices.Scissors &&
               Computer.Choice == GameChoices.Rock)
            {
                Computer.Score += 2;
                Winner = Computer;
            }

            else if (Human.Choice == GameChoices.Scissors &&
               Computer.Choice == GameChoices.Paper)
            {
                Human.Score += 2;
                Winner = Human;
            }

            else if (Human.Choice == Computer.Choice)
            {
                Human.Score += 1;
                Computer.Score += 1;
            }

            if (Round < LastRound)
            {
                Round++;
            }
            else End();
        }

        /// <summary>
        /// This method determines the winner of the game once
        /// the final round has been played according to the
        /// score achieved by each player
        /// </summary>
        public void End()
        {
            if (Computer.Score > Human.Score)
            {
                Winner = Computer;
            }
            else if (Computer.Score < Human.Score)
            {
                Winner = Human;
            }
            else Winner = null;
        }
    }
}