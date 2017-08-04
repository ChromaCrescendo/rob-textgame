using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextGame
{
    class Character
    {
        public int hp;
        public int mp;
        public string name;
        public int minAtk = 1;
        public int maxAtk;
        //public int ac;
        public int dmg;
        public int armor;




        //unused grab health function
        /*public int get_hp()
        {
            return hp;
        }*/

        //abandoned battle function
        /*public void battle()
        {
            
        }*/
        //making an abstract equipped item class
        /*abstract class EqpItm
        {
            abstract putOn(Character)
            {
                Character.Armor = this.Armor;
                Character.Wpn.name =
            }
            abstract takeOff();
            abstract public string descrip();
            abstract public string name();


            public void setValues(string name, int dmg, bool eqpFlag)
            {
                this.name = name;
                this.dmg = age;
                this.eqpFlag = eqpFlag;
            }
        }

        class Armor : EqpItm
        {
        putOn();
        takeOff();
        }

        class Wpn : EqpItm
        {

        }*/

    }

    class Paladin : Character
    {
        public Paladin()
        {
            hp = 70;
            maxAtk = 7;
            armor = 7;
            mp = 10;
        }
        
    }

    class Mage: Character
    {
        public Mage()
        {
            hp = 30;
            maxAtk = 11;
            armor = 0;
            mp = 20;
                
        }
    }

    class Warrior: Character
    {
        public Warrior()
        {
            hp = 50;
            maxAtk = 9;
            armor = 5;
            mp = 0;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            //intial setup for random damage throw
            Random r = new Random();

            //setting up first monster
            Character m1 = new Character();
            m1.hp = 30;
            m1.minAtk = 1;
            m1.maxAtk = 5;
            m1.name = "Large Rat";

            //appearance of first NPC and player name entry
            Character p1;
            Console.WriteLine("You awake in a cage in the dark. You hear a rough voice ask, 'Stranger, what is it that you do?'");     
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("You look all around you but see no one, only bars of iron\n");
            System.Threading.Thread.Sleep(1000);
            //bool behindBars = true;
            bool validClass = false;
            string classInput;
            string classInOriginal;
            do
            {
                Console.WriteLine("Pick a class: paladin, warrior, mage");

                classInOriginal = Console.ReadLine();
                classInput = classInOriginal.ToUpper();
                switch (classInput)
                    {
                        case "PALADIN":
                            p1 = new Paladin();
                            validClass = true;
                            break;
                        case "WARRIOR":
                            p1 = new Warrior();
                            validClass = true;
                            break;
                        case "MAGE":
                            p1 = new Mage();
                            validClass = true;
                            break;
                        default:
                            p1 = new Character();
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
            Console.WriteLine("'SHUT THE @*&# UP! OR I'LL BEAT YOU TO SLEEP!', you hear a voice shout in the distance");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("'...'");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("'I apologize, I... ");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("'I have random outbursts when I get excited'");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("'Now what did you say your name was, young {0}?'", classInOriginal);

            p1.name = Console.ReadLine();
            Console.WriteLine("{0}? What a terrible name!", p1.name);
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("{0} the {1}? No that doesn't have a good ring to it... How did you end up in this prison?", p1.name, classInOriginal);
            Console.ReadLine();
            Console.WriteLine("'Oh wow really? That's interesting... Just kidding I don't care.");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("'Shhhh be quiet {0}!', whispers the voice, 'Is that a rat?! Kill it before you catch a disease!'", p1.name);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("A " + m1.name + " appears before you with " + m1.hp + " health and " + m1.maxAtk + " attack");
            Console.ForegroundColor = ConsoleColor.Gray;
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("What do you do? Attack or run?");

            while (p1.hp > 0 && m1.hp > 0)
            {
                string input = Console.ReadLine().ToUpper();
                //randomizing both attacks
                p1.dmg = r.Next(p1.minAtk, p1.maxAtk);
                m1.dmg = r.Next(m1.minAtk, m1.maxAtk);

                //taking commands
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
                //checking if the monster is still alive, without this the monster will deal a final blow with negative health
                if (m1.hp > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The " + m1.name + " attacks you for " + m1.dmg + " damage");
                    //double nested if statement checks if you're a mage to do armor calculations
                    if (classInput != "MAGE")
                    {
                        Console.WriteLine("Your worn armor saves you from " + p1.armor + " damage");
                        //this triple nested if statement prevents an enemy from dealing negative damage because of armor and healing the character (HOPEFULLY)
                        if (m1.dmg > p1.armor)
                        {
                            p1.hp -= (m1.dmg - p1.armor);
                        }
                        else
                        {
                            Console.WriteLine("The attack bounces off your armor and you receive no damage");
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

            if (p1.hp <= 0)
            {
                Console.WriteLine("YOU LOSE");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("YOU WIN");
                Console.WriteLine("'Very good me lad, {0}, you were named poorly but ye be quite scrappy!", p1.name);
            }

            Console.ReadKey();
        }
    }
}
