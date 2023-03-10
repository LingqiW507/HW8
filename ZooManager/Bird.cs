using System;
namespace ZooManager
{
    public class Bird : Animal
    {
        /*public Bird(string name)
        {
            species = "bird";
            this.name = name;
            reactionTime = 5; // reaction time 1 (fast) to 5 (medium)
        }*/
        public override void Activate()
        {
            base.Activate();
            //Console.WriteLine("I am a bird.");
            //flee();
            //Hunt();
        }
    }

}
