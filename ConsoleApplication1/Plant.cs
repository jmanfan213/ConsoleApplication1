using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Plant : SimObject
    {
        private int mAmount;
        public int Amount
        {
            get { return mAmount; }
            set
            {
                if (value >= 0)
                    mAmount = value;
                else
                    mAmount = 0;//throw new ArgumentOutOfRangeException("Amount of plant cannot be negative");
            }
        }

        public Plant(int aColumn, int aRow, int anAmount = 5)
            : base(aColumn, aRow, ConsoleColor.DarkGreen)   // Use DarkGreen for plants
        {
            Amount = anAmount;
        }

        public override string ToString()
        {
            return "Plant at " + Column + ", " + Row + " with amount = " + Amount;
        }

        public override void Turn(List<SimObject> theList)
        {
            // Add to the plant's amount every turn
            if (Amount != 0 && Amount < 5)
                Amount++;

            // Add a new plant to theList when amount > 12
        }

        public void Eat()
        {
            if (Amount > 0)
                Amount = Amount - 2;
        }
    }
}
