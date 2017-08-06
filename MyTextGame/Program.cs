using System;

namespace MyTextGame
{
    class Character
    {
        public int hp;
        public int mp;
        public string name;
        public int minAtk = 1;
        public int maxAtk;
        public int dmg;
        public int armor;
    }

    class Monster : Character
    {

    }
    class Paladin : Character
    {
        public Paladin()
        {
            hp = 70;
            maxAtk = 7;
            armor = 5;
            mp = 10;
        }

    }

    class Mage : Character
    {
        public Mage()
        {
            hp = 30;
            maxAtk = 11;
            armor = 0;
            mp = 20;

        }
    }

    class Warrior : Character
    {
        public Warrior()
        {
            hp = 50;
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
            Console.WriteLine("A " + m1.name + " appears before you with " + m1.hp + " health and " + m1.maxAtk + " attack");
            Console.ForegroundColor = ConsoleColor.Gray;
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("What do you do? Attack or run?");
            System.Threading.Thread.Sleep(1000);

            while (p1.hp > 0 && m1.hp > 0)
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
                        m1.hp -= p1.dmg;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("It now has " + m1.hp + " health left");
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
                if (m1.hp > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The " + m1.name + " attacks you for " + m1.dmg + " damage");
                    //double nested if statement checks if you're a mage to do armor calculations
                    //partially no longer works with battle class system
                    //but still can calculate armor no matter what
                    //original line as follows
                    //if (classInput!= "MAGE")
                    if (p1.name != "MAGE")
                    {
                        Console.WriteLine("Your worn armor saves you from " + p1.armor + " damage");
                        //this triple nested if statement prevents an enemy from dealing negative
                        //damage because of armor and healing the character (HOPEFULLY)
                        if (m1.dmg > p1.armor)
                        {
                            p1.hp -= (m1.dmg - p1.armor);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The attack bounces off your armor");
                        }
                    }
                    else { p1.hp -= m1.dmg; }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You now have " + p1.hp + " health left \n");
                    //Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    break;
                }

            }

            if (m1.hp <= 0 & p1.hp >= 0)
            { return true; }
            else
            { return false; }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "The Bane Of Klothor";
            Character c = new Character();
            //set some stats
            Monster m = new Monster();
            m.hp = 30;
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
                        c = new Paladin();
                        validClass = true;
                        break;
                    case "WARRIOR":
                        c = new Warrior();
                        validClass = true;
                        break;
                    case "MAGE":
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

            //figured out a clever way to utilize the to upper function on chosen class, thought the solution was funny
            //but also figured out how to keep and use the original case, but kept the to upper plot utilization for the development of the npc character

            Console.WriteLine("'BUT OF COURSE... YOU WERE A {0}!', exclaims the voice.", classInput);
            //epic pauses to harness the true awkward silence
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("'SHUT UP! OR I'LL BEAT YOU TO SLEEP!', you hear a voice shout in the distance");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("'...'");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("'I apologize, I... ");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("'I have random outbursts when I get excited'");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("'Now what did you say your name was, young {0}?'", classInOriginal);

            c.name = Console.ReadLine();
            Console.WriteLine("{0}? What a terrible name!", c.name);
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("{0} the {1}? No that doesn't have a good ring to it... How did you end up in this prison?", c.name, classInOriginal);
            Console.ReadLine();
            Console.WriteLine("'Oh wow really? That's interesting...'");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("'Just kidding I don't care.'");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("'Shhhh be quiet {0}!', whispers the voice, 'Is that a rat?! Kill it before you catch a disease!'", c.name);
            

            Battle b = new Battle();
            b.p1 = c;
            b.m1 = m;
            bool did_p1_win = b.doBattle();

            if (did_p1_win == true)
            {
                Console.WriteLine("YOU WIN");
                Console.WriteLine("'Very good me lad, {0}, you were named poorly but be quite a scrappy {1}!'", c.name, classInOriginal);

                Monster g = new Monster();
                Battle e = new Battle();
                e.p1 = c;
                e.m1 = g;
                g.hp = 50;
                g.minAtk = 2;
                g.maxAtk = 21;
                g.name = "Sleepy Guard";
                Console.WriteLine("'Who keeps shouting while I'm trying to sleep?!'");
                did_p1_win = e.doBattle();
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

