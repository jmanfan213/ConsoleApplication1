using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    // ----------------------------------------------------------------
    // Everything should be column, row
    // ----------------------------------------------------------------
    public class SimObject
    {
        private int row, column;
        public int Column
        {
            get { return this.column; }
            set
            {
                if (value >= 0)
                    this.column = value;
                else
                    throw new ArgumentOutOfRangeException("Column cannot be negative");
            }
        }
        public int Row
        {
            get { return this.row; }
            set
            {
                if (value >= 0 && value < Console.WindowHeight)
                    this.row = value;
                else
                    throw new ArgumentOutOfRangeException("Row cannot be negative");
            }
        }

        public SimObject(int Column, int Row, ConsoleColor Color = ConsoleColor.White)
        {
            this.Column = Column;
            this.Row = Row;
            this.Color = Color;
        }
        
        // Allow each child to have a unique color
        public ConsoleColor Color { get; set; }

        public override string ToString()
        {
            return "SimObject at " + this.Column + ", " + this.Row;
        }

        public void Draw(string character) //I changed the Draw method so that you can determine what character should be drawn in main
        {
            // Draw the character to the screen in the correct position
            Console.SetCursorPosition(this.Column, this.Row);
            Console.ForegroundColor = this.Color;    
            Console.Write(character); 
        }

        public virtual void Turn(List <SimObject> theList)
        { }
    }
}
