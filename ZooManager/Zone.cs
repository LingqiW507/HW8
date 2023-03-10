using System;
namespace ZooManager
{
    public class Zone
    {
        private Occupant _occupant = null;
        public Occupant occupant
        {
            get { return _occupant; }
            set {
                _occupant = value;
                if (_occupant != null) {
                    _occupant.location = location;
                }
            }
        }

        public Point location;

        public string emoji
        {
            get
            {
                if (occupant == null) return "";
                return occupant.emoji;
            }
        }
        //reaction time label
        public string rtLabel
        {
            get
            {
                if (occupant == null) return "";
                return occupant.reactionTime.ToString();
            }
        }
        //r.turns on board table
        public string tbLabel
        {
            get
            {
                if (occupant == null) return "";
                return occupant.TurnsOnBoard.ToString();
            }
        }

        public Zone(int x, int y, Animal animal)
        {
            location.x = x;
            location.y = y;

            occupant = animal;
        }
    }
}
