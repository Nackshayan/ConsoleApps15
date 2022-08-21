namespace ConsoleAppProject.App06
{
    /// <summary>
    /// This class stores information about the Player's
    /// name, score, type and choice
    /// </summary>
    /// <author>
    /// Nackshayan 15/08/2022
    /// </author> 
    public class Player
    {
        public string Name { get; }
        public int Score { get; set; }
        public GamePlayers PlayerType { get; }
        public GameChoices Choice { get; set; }
        
        /// <summary>
        /// Constructor for objects of class Player
        /// </summary>
        public Player(string name, GamePlayers playerType)
        {
            this.Name = name;
            this.PlayerType = playerType;
            Score = 0;
            Choice = GameChoices.None;
        }
    }
}
