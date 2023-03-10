using System;
using System.Collections.Generic;

namespace ZooManager
{
    public class Alien: Occupant, IPredator
    {
        public List<string> Preys { get; private set; } = new List<string>() { "" };

        public Alien(string name)
        {
            emoji = "👽";
            species = "alien";
            this.name = name;
        }

        protected bool Seek(int x, int y, Direction d)
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

            if (y < 0 || x < 0 || y > Game.numCellsY - 1 || x > Game.numCellsX - 1) return false;
            if (Game.animalZones[y][x].occupant == null) return false;
            if (Game.animalZones[y][x].occupant.species != "alien")
            {
                return true;
            }
            return false;
        }

        public void Hunt()
        {
            if (Seek(location.x, location.y, Direction.up))
            {
                Attack(this, Direction.up);
            }
            else if (Seek(location.x, location.y, Direction.down))
            {
                Attack(this, Direction.down);
            }
            else if (Seek(location.x, location.y, Direction.left))
            {
                Attack(this, Direction.left);
            }
            else if (Seek(location.x, location.y, Direction.right))
            {
                Attack(this, Direction.right);
            }

        }
        protected void Attack(Alien attacker, Direction d)
        {
            Console.WriteLine($"{attacker.name} is attacking {d.ToString()}");
            int x = attacker.location.x;
            int y = attacker.location.y;

            switch (d)
            {
                case Direction.up:
                    Game.animalZones[y - 1][x].occupant = attacker;
                    break;
                case Direction.down:
                    Game.animalZones[y + 1][x].occupant = attacker;
                    break;
                case Direction.left:
                    Game.animalZones[y][x - 1].occupant = attacker;
                    break;
                case Direction.right:
                    Game.animalZones[y][x + 1].occupant = attacker;
                    break;
            }
            Game.animalZones[y][x].occupant = null;
        }

        override public void Activate()
        {
            base.Activate();
            Console.WriteLine($"Alien {name} at {location.x},{location.y} activated");
            Hunt();
        }
    }

}
