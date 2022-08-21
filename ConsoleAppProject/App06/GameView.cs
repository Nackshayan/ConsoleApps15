using ConsoleAppProject.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App06
{
    /// <summary>
    /// This class will create a user interface for the
    /// Rock-Paper-Scissors game using the windows
    /// Console
    /// </summary>
    /// <author>
    /// Nackshayan 14/08/2022
    /// </author>
    public class GameView
    {
        private Game game;

        /// <summary>
        /// This method will control the progress of the
        /// game from start to end.
        /// </summary>
        public void PlayGame()
        {
            do
            {

                StartGame();

                MakeHumanChoice();

                game.MakeComputerChoice();
                ShowComputerChoice();

                game.ScoreRound();

                if (game.Round == game.LastRound)
                {
                    EndGame();
                }
            } while (game.Round <= game.LastRound);

        }

        /// <summary>
        /// Reset a game so that the scores reset to zero
        /// for both players and the number of rounds is set.
        /// </summary>
        public void StartGame()
        {
            SetupConsole();

            ConsoleHelper.OutputHeading("  Rock-Paper-Scissors Game");

            if (game == null)
            {
                Console.Write(" Please enter your Name > ");
                string name = Console.ReadLine();

                game = new Game(name);

                game.LastRound = ConsoleHelper.InputNumber(" Please " +
                    "input the number of Rounds > "); 
            }

            game.Start();
        }

        /// <summary>
        /// This method sets up the console in which the
        /// game will be played, setting the colour scheme
        /// </summary>
        private void SetupConsole()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();
        }

        /// <summary>
        /// Repeatedly ask the player to make a choice
        /// and then ask the computer to make a choice.
        /// The choices are then compared and scored
        /// </summary>
        public void MakeHumanChoice()
        {
            ConsoleHelper.OutputTitle($" This is Round " + 
                game.Round + " of " + game.LastRound);
            ConsoleHelper.OutputTitle(" Select Your Choice");

            string[] choices =
             {
                " Rock",
                " Paper",
                " Scissors"
            };

            int choice = ConsoleHelper.SelectChoice(choices);
            ExecuteHumanChoice(choice);
        }

        /// <summary>
        /// This method executes the choice, as made by the 
        /// user in the MakeHumanChoice method
        /// </summary>
        private void ExecuteHumanChoice(int choice)
        {
            switch (choice)
            {
                case 1: game.Human.Choice = GameChoices.Rock; 
                    break;
                case 2: game.Human.Choice = GameChoices.Paper; 
                    break;
                case 3: game.Human.Choice = GameChoices.Scissors; 
                    break;

                default: 
                    break;
            }

            ShowHumanChoice();
        }

        /// <summary>
        /// This method displays the choice of the computer
        /// through an appropriate image as well as displaying
        /// the choice in text form
        /// </summary>
        public void ShowHumanChoice()
        {
            if(game.Human.Choice == GameChoices.Rock)
            {
                GameImages.DrawRock(1, 20);
            }
            else if(game.Human.Choice == GameChoices.Paper)
            {
                GameImages.DrawPaper(1, 20);
            }
            else if (game.Human.Choice == GameChoices.Scissors)
            {
                GameImages.DrawScissors(1, 20);
            }

            Console.WriteLine(" You have chosen " + game.Human.Choice);
        }

        /// <summary>
        /// This method displays the choice of the computer
        /// through an appropriate image as well as displaying
        /// the choice in text form
        /// </summary>
        public void ShowComputerChoice()
        {
            ConsoleHelper.OutputTitle(" The Computer's Choice");

            switch (game.Computer.Choice)
            {
                case GameChoices.Rock: GameImages.DrawRock(1, 37); 
                    break;
                case GameChoices.Paper: GameImages.DrawPaper(1, 37); 
                    break;
                case GameChoices.Scissors: GameImages.DrawScissors(1, 37); 
                    break;
            }

            Console.WriteLine(" The computer has chosen " + game.Computer.Choice);
            ShowRoundScores();
        }

        /// <summary>
        /// This method displays the score for both the Human 
        /// and the Computer after each round
        /// </summary>
        public void ShowRoundScores()
        {
            ConsoleHelper.OutputTitle(" Current Scores");

            game.ScoreRound();

            Console.WriteLine(" Your Current Score is: " 
                + game.Human.Score);
            Console.WriteLine(" The Computer's Current " +
                "Score is: " + game.Computer.Score);
            Console.WriteLine();
        }

        /// <summary>
        /// This method displays who has one the game 
        /// and shows an image on screen symbolising 
        /// whether the player has lost or won
        /// </summary>
        public void ShowWinner()
        {
            if(game.Winner == game.Human)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(" Congratulations! You " +
                    "have won the Game! ");

                GameImages.DrawThumbsUp();
            }
            else if(game.Winner == game.Computer)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" The Computer has won the Game. " +
                    "Better luck next time! ");

                GameImages.DrawThumbsDown();
            }
            else if(game.Human.Score == game.Computer.Score)
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(" You and the Computer have achieved " +
                    "an Equal Score! ");

                GameImages.DrawSmile();
            }
            Console.WriteLine(" Your final score is: " + 
                game.Human.Score);
            Console.WriteLine(" The Computer's final score is: " + 
                game.Computer.Score);
            Console.WriteLine();
        }

        /// <summary>
        /// One player or more players have reached the chosen 
        /// maximum score and the winner can be decided.
        /// </summary>
        public void EndGame()
        {
            ShowWinner();
            ChooseRestart();
        }

        private void ChooseRestart()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            string[] choices =
            {
                " Restart",
                " Quit"
            };

            Console.WriteLine(" Would you like to Restart or Quit?");
            Console.WriteLine();

            int choice = ConsoleHelper.SelectChoice(choices);
            ExecuteRestartChoice(choice);
        }

        private void ExecuteRestartChoice(int choice)
        {
            switch (choice)
            {
                case 1: PlayGame();
                    break;

                default:
                    break;
            }
            while (choice != 2) ;
        }
    }
}