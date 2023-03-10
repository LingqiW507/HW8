using System;
using System.Collections.Generic;

namespace ZooManager
{
    public class Mouse : Animal, IPrey
    {
        public bool reproduced = false;
        public List<string> Predators { get; private set; } = new List<string>(){"cat","raptor","alien"};
        public Mouse(string name)
        {
            emoji = "🐭";
            species = "mouse";
            this.name = name; // "this" to clarify instance vs. method parameter
            reactionTime = new Random().Next(1, 4); // reaction time of 1 (fast) to 3
            /* Note that Mouse reactionTime range is smaller than Cat reactionTime,
             * so mice are more likely to react to their surroundings faster than cats!
             */
        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a mouse. Squeak.");
            Flee();
            Reproduce();
        }
        //new added q
        public void Reproduce()
        {

            if (reproduced == false && TurnsOnBoard >= 4)// check if Chick has been on the board for 3 turns.
            {//when it is the fourth turns of this chick...
                if (SeekEmpty(location.x, location.y, Direction.up))
                {
                    Mouse mouse = new Mouse("Squeaky");
                    Game.DuplicateAnimal(this, mouse, Direction.up);
                    reproduced = true;
                    return;
                }
                if (SeekEmpty(location.x, location.y, Direction.down))
                {
                    Mouse mouse = new Mouse("Squeaky");
                    Game.DuplicateAnimal(this, mouse, Direction.down);
                    reproduced = true;
                    return;
                }
                if (SeekEmpty(location.x, location.y, Direction.left))
                {
                    Mouse mouse = new Mouse("Squeaky");
                    Game.DuplicateAnimal(this, mouse, Direction.left);
                    reproduced = true;
                    return;
                }
                if (SeekEmpty(location.x, location.y, Direction.right))
                {
                    Mouse mouse = new Mouse("Squeaky");
                    Game.DuplicateAnimal(this, mouse, Direction.right);
                    reproduced = true;
                    return;
                }
   
            }
        }

        /* Note that our mouse is (so far) a teeny bit more strategic than our cat.
         * The mouse looks for cats and tries to run in the opposite direction to
         * an empty spot, but if it finds that it can't go that way, it looks around
         * some more. However, the mouse currently still has a major weakness! He
         * will ONLY run in the OPPOSITE direction from a cat! The mouse won't (yet)
         * consider running to the side to escape! However, we have laid out a better
         * foundation here for intelligence, since we actually check whether our escape
         * was succcesful -- unlike our cats, who just assume they'll get their prey!
         */
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

        protected bool SeekEmpty(int x, int y, Direction d)
        {
            switch (d)
            {
                case Direction.up:
                    y--;
                    break;
                case Direction.down:
                    y++;
                    break;
                case Direction.left:
                    x--;
                    break;
                case Direction.right:
                    x++;
                    break;
            }

            // out of range
            if (y < 0 || x < 0 || y > Game.numCellsY - 1 || x > Game.numCellsX - 1) return false;

            // find empty zone
            if (Game.animalZones[y][x].occupant == null) return true;

            // doesn't find empty zone
            return false;
        }
    }
}

