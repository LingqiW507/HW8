using System;
namespace ZooManager
{
    public class Occupant
    {
        public string emoji;
        public string species;
        public string name;
        public int reactionTime = 5;

        public Point location;

        public void ReportLocation()
        {
            Console.WriteLine($"I am at {location.x},{location.y}");
        }
        //m.add a trait to Animal that tracks how many turns each Animal en?ty has been on the board.
        public int TurnsOnBoard { get; set; }
        //move Seek, Attack, Retreat from game into animal
        //Make animals run these functions automatically through their own traits instead of being asked to run them from the game.
        //change Seek, Attack, Retreat methods from public to protected, to avoid these methods
        //to be called individually in other classes that are not related to Animal

        virtual public void Activate()
        {
            TurnsOnBoard++;
        }
    }

}
