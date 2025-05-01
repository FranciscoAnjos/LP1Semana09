using System;

namespace PlayerManager4
{
    public class Player: IComparable<Player>
    {
        public readonly string Name;
        public int Score { get; set; }

        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }
        
        public int CompareTo(Player other)
        {
            if (other == null) return -1;
            return other.Score.CompareTo(this.Score); // descending order
        }
    }
}