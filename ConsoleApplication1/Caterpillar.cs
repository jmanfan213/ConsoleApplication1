using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Caterpillar : SimObject
    {
        private static Random aRan = new Random();

        public Caterpillar(int Column, int Row, int Speed = 1)
            : base(Column, Row, ConsoleColor.Red)
        {
            this.Speed = Speed;
        }

        private int speed;
        public int Speed
        {
            get { return this.speed; }
            set
            {
                if (value >= 0)
                    this.speed = value;
                else
                    throw new ArgumentOutOfRangeException("Speed of caterpillar cannot be negative");
            }
        }

        public override void Turn(List<SimObject> theList)
        {
            SimObject so = null;
            //nt health = 15;
            for (int index = 0; index < theList.Count; index++)
            {
                if (theList[index] != this && theList[index].Row == this.Row && theList[index].Column == this.Column)
                    so = theList[index];
            }

            if (so is Plant)               // it's a plant, so don't move the caterpillar away from it
            {
                Plant p = (Plant)so;
                if (p.Amount > 0)         // eat some of the plant if any is left
                    p.Eat();
                else if (p.Amount == 0)   // if no plant is left, remove the plant from theList (this is the simulation's list)
                    theList.Remove(p);
            }
            else //if (so == null)        // no other object in this space, so try moving to a new space without another caterpillar
            {
                //health--;
                //if (health < 0)
                //    this = null;
                // Move randomly but not off the screen's edges
                int newCol = this.Column + aRan.Next(-2, 3);
                int newRow = this.Row + aRan.Next(-2, 3);
                while (newCol < 0 || newCol >= Console.WindowWidth || newRow < 0 || newRow >= Console.WindowHeight)
                {
                    newCol = this.Column + aRan.Next(-2, 3);
                    newRow = this.Row + aRan.Next(-2, 3);
                }

                // make sure the new space is empty or has a plant (e.g. don't move on top of another caterpillar)
                so = null;
                for (int index = 0; index < theList.Count; index++)
                {
                    if (theList[index] != this && theList[index].Row == newRow && theList[index].Column == newCol && theList[index].Color != Color)
                        so = theList[index];
                }

                if (so == null || (so is Plant))
                {
                    this.Column = newCol;
                    this.Row = newRow;
                }
            }
        }

        public override string ToString()
        {
            return "Caterpillar at " + this.Row + ", " + this.Column + " with speed = " + this.Speed;
        }
    }
}
