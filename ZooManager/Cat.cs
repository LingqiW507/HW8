using System;
using System.Collections.Generic;

namespace ZooManager
{
    public class Cat : Animal, IPredator, IPrey
    {
        public List<string> Preys { get; private set; } = new List<string>() { "chick", "mouse", "alien"};
        public List<string> Predators { get; private set; } = new List<string>() { "raptor" };
        public Cat(string name)
        {
            emoji = "🐱";
            species = "cat";
            this.name = name;
            reactionTime = new Random().Next(1, 6); // reaction time 1 (fast) to 5 (medium)
        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a cat. Meow.");
            if (Flee())
            {
                return;
            }
            Hunt();
        }

        /* Note that our cat is currently not very clever about its hunting.
         * It will always try to attack "up" and will only seek "down" if there
         * is no mouse above it. This does not affect the cat's effectiveness
         * very much, since the overall logic here is "look around for a mouse and
         * attack the first one you see." This logic might be less sound once the
         * cat also has a predator to avoid, since the cat may not want to run in
         * to a square that sets it up to be attacked!
         */
        public bool Flee()
        {
            foreach (string prey in Preys)
            {
                if (Seek(location.x, location.y, Direction.up, "raptor"))
                {
                    if (Seek(location.x, location.y, Direction.down, prey))
                    {
                        Attack(this, Direction.down);
                        return true;
                    }
                    
                    if (Retreat(this, Direction.down)) return true;
                }
                if (Seek(location.x, location.y, Direction.down, "raptor"))
                {
                    if (Seek(location.x, location.y, Direction.up, prey))
                    {
                        Attack(this, Direction.up);
                        return true;
                    }
                    if (Retreat(this, Direction.up)) return true;
                }
                if (Seek(location.x, location.y, Direction.left, "raptor"))
                {
                    if (Seek(location.x, location.y, Direction.right, prey))
                    {
                        Attack(this, Direction.right);
                        return true;
                    }
                    if (Retreat(this, Direction.right)) return true;
                }
                if (Seek(location.x, location.y, Direction.right, "raptor"))
                {
                    if (Seek(location.x, location.y, Direction.left, prey))
                    {
                        Attack(this, Direction.left);
                        return true;
                    }
                    if (Retreat(this, Direction.left)) return true;
                }
            }
            
            return false;//no flee
        }

        public void Hunt()
        {
            foreach (string prey in Preys)
            {
                if (Seek(location.x, location.y, Direction.up, prey))
                {
                    Attack(this, Direction.up);
                }
                else if (Seek(location.x, location.y, Direction.down, prey))
                {
                    Attack(this, Direction.down);
                }
                else if (Seek(location.x, location.y, Direction.left, prey))
                {
                    Attack(this, Direction.left);
                }
                else if (Seek(location.x, location.y, Direction.right, prey))
                {
                    Attack(this, Direction.right);
                }
            }
        }

        
    }
}

