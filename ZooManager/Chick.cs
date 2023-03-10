using System;
using System.Collections.Generic;

namespace ZooManager
{
    public class Chick : Bird, IPrey
    {
        public List<string> Predators { get; private set; } = new List<string>() { "cat", "alien" };

        public Chick(string name)
        {
            emoji = "🐥";
            species = "chick";
            this.name = name;
            reactionTime = new Random().Next(6, 11); //reaction time of 6 to 10
            
        }
        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a chick. Peep.");
            Flee();
            Mature();
        }
        //n.each Chick grows up after three turns.
        public void Mature()
        {

            if (TurnsOnBoard == 4)// check if Chick has been on the board for 3 turns.
            {//when it is the fourth turns of this chick...
                Raptor raptor = new Raptor("Cruel");
                Game.ReplaceAnimal(this, raptor);//replace chick with new Raptor 
            }
        }

        public bool Flee()
        {
            foreach (string predator in Predators)
            {
                if (Seek(location.x, location.y, Direction.up, predator))
                {
                    if (Retreat(this, Direction.down)) return true;
                }
                if (Seek(location.x, location.y, Direction.down, predator))
                {
                    if (Retreat(this, Direction.up)) return true;
                }
                if (Seek(location.x, location.y, Direction.left, predator))
                {
                    if (Retreat(this, Direction.right)) return true;
                }
                if (Seek(location.x, location.y, Direction.right, predator))
                {
                    if (Retreat(this, Direction.left)) return true;
                }
            }
            return false;
        }

    }

}
