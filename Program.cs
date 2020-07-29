using System;

namespace SpookyHouseGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Print("Welcome to the spooky house of mystery and terror!");
            if (args.Length > 1 && args[1] == "-y")
            {
                Confirm();
            }
            else
            {
                Print("Are you sure you want to enter? (yes/no)");

                bool canEnter = false;
                while (!canEnter)
                {
                    string userInput = Console.ReadLine().ToLower();
                    switch (userInput)
                    {
                        case "yes":
                            canEnter = true;
                            break;
                        case "no":
                            Print("You ran away in fear!");
                            return;
                    }

                }
                Console.Clear();
            }
            Print("You open a rusty door and enter a big hallway. You see more doors.");
            Print("An old man stands in the middle of the room...");
            Confirm();
            Print("\"Be careful, adventurer! One of these doors contains a GHOST!\"");
            Confirm();

            Random random = new Random();
            ushort maxDoorsAllowed = 10;
            byte health = 3;
            uint score = 0;

            //Keep going through rooms if alive
            while (health > 0)
            {
                ushort maxDoors = (ushort)random.Next(2, (int)maxDoorsAllowed);
                Print($"There are {maxDoors} doors here, which one will you enter?");
                bool validAnswer = false;
                ushort doorChoosen = 0;
                while (!validAnswer)
                {
                    void Invalid()
                    {
                        Console.Write("\n");
                        Print("That door doesn't exist.");
                    }
                    Console.Write("> I will go through door ");
                    if (ushort.TryParse(Console.ReadLine(), out doorChoosen))
                    {
                        if (doorChoosen <= maxDoors && doorChoosen > 0)
                        {
                            validAnswer = true;
                        }
                        else
                        {
                            Invalid();
                        }
                    }
                    else
                    {
                        Invalid();
                    }
                }
                Print($"You went through door {doorChoosen}.");
                Confirm();
                ushort dangerousDoor = (ushort)random.Next(1, maxDoors + 1);
                if (doorChoosen == dangerousDoor)
                {
                    health--;
                    Print("Aaaaah! There is a ghost!");
                    Confirm();
                    if (health == 0)
                    {
                        break;
                    }
                    else if (health > 1)
                    {
                        Print($"The ghost hits you. Only {health} lives remain!");
                    }
                    else
                    {
                        Print($"The ghost hits you. Only {health} life remains!");
                    }
                    Print("You scream \"Stop, that hurts!\" at the top of your lungs. The ghost apologizes and flies away!");
                    Confirm();
                }
                score++;
                Print("You move to the next room of the spooky house.");
                Print($"A big sign says \"Room {score}\"...");
            }

            //Player died
            Print("The ghost scared you to death.");
            Print($"You survived {score} rooms!");
        }

        private static void Print(object o)
        {
            Console.WriteLine(o.ToString());
        }

        private static void Confirm()
        {
            Console.Read();
            Console.Clear();
        }
    }
}
