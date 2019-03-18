using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the list of parent objects
            List<SimObject> theObjects = new List<SimObject>();
            Random aRan = new Random();

            // Adds some plants
            const int NUM_PLANTS = 250;
            for (int i = 0; i < NUM_PLANTS; i++)
                theObjects.Add(new Plant(aRan.Next(80), aRan.Next(24)));
            
            // Add some caterpillars
            const int NUM_CATS = 25;
            for (int i = 0; i < NUM_CATS; i++)
                theObjects.Add(new Caterpillar(aRan.Next(78), aRan.Next(22)));

            // Run the sim until the user presses a key
            while (Console.KeyAvailable == false)
            {
                Console.Clear();
                foreach (var x in theObjects)
                {
                    if (x is Plant) //asks if the object in question is type Plant
                        x.Draw("#");
                    if (x is Caterpillar) //asks if the object in question is type Caterpillar
                        x.Draw("0");
                }
                // Call each sim object's turn method
                for (int i = 0; i < theObjects.Count; i++)
                    theObjects[i].Turn(theObjects);

                Thread.Sleep(600);                
            }

            Console.SetCursorPosition(0, 24);
            Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine($"Remaining Caterpillars is {NUM_CATS}, Remaining Plants is {NUM_PLANTS}");
            Console.Write("PAK ...");
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}
