using System;

namespace MyTextGame
{
    class Character
    {
        public int hpCurrent;
        public int hpMax;
        public int mp;
        public string name;
        public int minAtk = 1;
        public int maxAtk;
        public int dmg;
        public int armor;
        public int level = 1;
    }

    class Monster : Character
    {

    }
    class Paladin : Character
    {
        public Paladin()
        {
            hpMax = 70;
            maxAtk = 7;
            armor = 5;
            mp = 10;
        }

    }

    class Mage : Character
    {
        public Mage()
        {
            hpMax = 30;
            maxAtk = 11;
            armor = 0;
            mp = 20;
        }
    }

    class Warrior : Character
    {
        public Warrior()
        {
            hpMax = 50;
            minAtk = 3;
            maxAtk = 9;
            armor = 3;
            mp = 0;
        }
    }

 
    class Battle
    {
        public Character p1;
        public Monster m1;

        public bool doBattle()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("A " + m1.name + " appears before you with " + m1.hpCurrent + " health and " + m1.maxAtk-- + " attack");
            Console.ForegroundColor = ConsoleColor.Gray;
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("What do you do? Attack or run?");
            System.Threading.Thread.Sleep(1000);

            while (p1.hpCurrent > 0 && m1.hpCurrent > 0)
            {

                //secondary setup for
                //randomizing both attacks
                Random r = new Random();
                p1.dmg = r.Next(p1.minAtk, p1.maxAtk);
                m1.dmg = r.Next(m1.minAtk, m1.maxAtk);

                //taking commands
                string input = Console.ReadLine().ToUpper();
                switch (input)
                {
                    case "ATTACK":
                    case "ATK":
                        Console.WriteLine("You attack " + m1.name + " for " + p1.dmg + " damage");
                        m1.hpCurrent -= p1.dmg;
                        Console.ForegroundColor = ConsoleColor.Green;
                        //Erase comment mark to show monster health
                        Console.WriteLine("It now has " + m1.hpCurrent + "/" + m1.hpMax + " health left");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;

                    case "RUN":

                        Console.WriteLine("You attempt to flee but you are behind bars, so you run in a circle");
                        break;

                    default:
                        Console.WriteLine("Unknown command, the monster gets a free hit! Try again.");
                        break;

                }
                //checking if the monster is still alive, without this the monster will
                //deal a final blow with negative health
                if (m1.hpCurrent > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The " + m1.name + " attacks you for " + m1.dmg + " damage");
                    //double nested if statement checks if you're a mage to do armor calculations
                    //partially no longer works with battle class system
                    //but still can calculate armor no matter what
                    //original line as follows
                    //if (classInput!= "MAGE")
                    if (p1.armor > 0)
                    {
                        Console.WriteLine("Your worn armor saves you from " + p1.armor + " damage");
                        //Now checking if armor is greater than one instead of player class before doing armor calc
                        if (m1.dmg > p1.armor)
                        {
                            p1.hpCurrent -= (m1.dmg - p1.armor);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The attack bounces off your armor");
                        }
                    }
                    else { p1.hpCurrent -= m1.dmg; }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You now have " + p1.hpCurrent + "/" + p1.hpMax + " health left \n");
                    //Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    break;
                }

            }

            if (m1.hpCurrent <= 0 & p1.hpCurrent > 0)
            { Console.WriteLine("The corpse of the fallen " + m1.name + " lies cold at your feet");
                return true; }
            else
            {
                Console.WriteLine("Proving superior in battle, the " + m1.name + " has bested you, young " + p1.name);
                return false; }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "The Bane Of Klothor";
            Character c = new Character();
            //making first monster, a large rat
            //set some stats
            Monster m = new Monster();
            m.hpMax = 30;
            m.hpCurrent = m.hpMax;
            m.minAtk = 1;
            m.maxAtk = 10;
            m.name = "Large Rat";

            //appearance of first NPC and player name entry

            Console.WriteLine("You awake in a strange room in the dark.\n" +
                "You hear a rough voice ask, 'Stranger, what is it that you do?'");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("You look all around you but see no one, only bars of iron\n");
            System.Threading.Thread.Sleep(2000);

            bool validClass = false;
            string classInput;
            string classInOriginal;
            //class select loop
            //cannot be skipped
            do
            {
                Console.WriteLine("Pick a class: paladin, warrior, mage");

                classInOriginal = Console.ReadLine();
                classInput = classInOriginal.ToUpper();
                switch (classInput)
                {
                    case "PALADIN":
                    case "PAL":
                    case "P":
                        c = new Paladin();
                        validClass = true;
                        break;
                    case "WARRIOR":
                    case "WAR":
                    case "W":
                        c = new Warrior();
                        validClass = true;
                        break;
                    case "MAGE":
                    case "M":
                        c = new Mage();
                        validClass = true;
                        break;
                    default:
                        c = new Character();
                        validClass = false;
                        Console.WriteLine("'I'm sorry, you were a what now?', queries the voice, bewildered.");
                        Console.WriteLine("(Invalid Class. Try Again!)");
                        break;
                }

            } while (validClass == false);
            c.hpCurrent = c.hpMax;

            //figured out a clever way to utilize the to upper function on chosen class, thought the solution was funny
            //but also figured out how to keep and use the original case, but kept the to upper plot utilization for the development of the npc character

            Console.WriteLine("'BUT OF COURSE... YOU WERE A {0}!', exclaims the voice.", classInput);
            //epic pauses to harness the true awkward silence
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("'Now what did you say your name was, young {0}?'", classInOriginal);

            c.name = Console.ReadLine();
            Console.WriteLine("{0}? What a terrible name!", c.name);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("{0} the {1}? No that doesn't have a good ring to it... How did you end up in this prison?", c.name, classInOriginal);
            Console.ReadLine();
            Console.WriteLine("'Oh wow really? That's interesting...'");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("'Just kidding I don't care.'");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("'Shhhh be quiet {0}!', whispers the voice, 'Is that a rat?! Kill it before you catch a disease!'", c.name);
            
            //making the first battle, setting characters and monsters for the fight
            Battle b = new Battle();
            b.p1 = c;
            b.m1 = m;
            bool did_p1_win = b.doBattle();

            if (did_p1_win == true)
            {                
                Console.WriteLine("YOU WIN");
                Console.WriteLine("'Very good me lad, {0}, you were named poorly but be quite a scrappy {1}!'", c.name, classInOriginal);
                //making the second monster
                Monster g = new Monster();
                Battle b1 = new Battle();
                //setting new monsters stats
                b1.p1 = c; b1.m1 = g;
                g.hpMax = 50; g.hpCurrent = g.hpMax; g.minAtk = 2; g.maxAtk = 21;
                g.name = "Sleepy Guard";
                //introducing sleepy guard
                Console.WriteLine("You see a light in the distance grow, and you watch an angry guard with a torch approach you");
                Console.WriteLine("'Who keeps shouting while I'm trying to sleep?!'");

                did_p1_win = b1.doBattle();
                if (did_p1_win == true)
                {
                    Console.WriteLine("GOOD JOB YOU KILLED THAT GUARD DUDE!\n" +
                        "'Now let's escape'\n" +
                        "TO BE CONTINUED...");
                }
                else
                {
                    Console.WriteLine("You died...\n" +
                        "'I'll spit on your grave', says the guard");
                }
            }
            else
            {
                Console.WriteLine("YOU LOSE");
            }

            Console.ReadKey();
        }
    }
}

