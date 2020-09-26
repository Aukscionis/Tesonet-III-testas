/* So my thoughts would be that egg has a certain strength and and each floor is higher so the probability of breaking
   increases too, + there is random things that increases or decreases that number too so I've added some randomness too.
*/
using System;
namespace tesonet
{
    class Program
    {
        static void Main(string[] args)
        {
            Egg eggs = new Egg(1, 2); // Strength and count
            Building tallBuilding = new Building(100, 0.05, 1); // Floors, brekeage and starting floor

            while(eggs.count != 0)
            {

                if (Egg.eggDrop(eggs.strength, tallBuilding.brekeage, tallBuilding.floor))
                {
                   Console.WriteLine("Egg survived the fall from {0} floor!", tallBuilding.floor);
                    tallBuilding.floor++;
                }
               else
                {
                    Console.WriteLine("Egg didn't survive the fall from {0} floor! :(", tallBuilding.floor);
                    eggs.count--;
                    if (eggs.count == 1) {
                        Console.WriteLine("Lucky we have a second egg! Lets try again.");
                        Console.WriteLine(); }
                    
                    }

                if (tallBuilding.floor == tallBuilding.floors + 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Congratulations! Your egg is made out from metal!");
                    return;
                }


            }


        }



    }

    public class Egg
    {
        public double strength { get; set; }
        public int count { get; set; }

        public Egg(double strength, int count)
        {
            this.strength = strength;
            this.count = count;
        }

        public static bool eggDrop(double strength, double brekeage, int floor)
        {
            Random random = new Random();
            brekeage *= random.NextDouble() * floor;

            if (strength >= brekeage)
                return true;
            else
                return false;
        }

    }

    public class Building
    {
        public int floors { get; set; }
        public double brekeage { get; set; }
        public int floor { get; set; }

        public Building(int floors, double brekeage, int floor)
        {
            this.floors = floors;
            this.brekeage = brekeage;
            this.floor = floor;
        }

    }

}
