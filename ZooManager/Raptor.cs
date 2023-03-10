using System;
using System.Collections.Generic;

namespace ZooManager
{
    public class Raptor : Bird, IPredator, IPrey
    {
        public List<string> Preys { get; private set; } = new List<string>(){"cat","mouse"};
        public List<string> Predators { get; private set; } = new List<string>() { "alien" };
        public Raptor(string name)
        {
            emoji = "🦅";
            species = "raptor";
            this.name = name; // "this" to clarify instance vs. method parameter
            reactionTime = 1;
        }
        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a Raptor. Screech.");
            if (Flee())
            {
                return;
            }
            Hunt();
        }

        public bool Flee()
        {
            foreach (string prey in Preys)
            {
                if (Seek(location.x, location.y, Direction.up, "alien"))
                {
                    if (Seek(location.x, location.y, Direction.down, prey))
                    {
                        Attack(this, Direction.down);
                        return true;
                    }

                    if (Retreat(this, Direction.down)) return true;
                }
                if (Seek(location.x, location.y, Direction.down, "alien"))
                {
                    if (Seek(location.x, location.y, Direction.up, prey))
                    {
                        Attack(this, Direction.up);
                        return true;
                    }
                    if (Retreat(this, Direction.up)) return true;
                }
                if (Seek(location.x, location.y, Direction.left, "alien"))
                {
                    if (Seek(location.x, location.y, Direction.right, prey))
                    {
                        Attack(this, Direction.right);
                        return true;
                    }
                    if (Retreat(this, Direction.right)) return true;
                }
                if (Seek(location.x, location.y, Direction.right, "alien"))
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