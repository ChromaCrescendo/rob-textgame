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
        //public int mp;
        public string name;
        public int minAtk;
        public int maxAtk;
        //public int ac;
        public int dmg;

        /*stats unimplimented
        public int str;
        public int dex;
        public int con;
        public int intel;
        public int wis;
        public int cha;*/




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



    class Program
    {
        static void Main(string[] args)
        {
            //intial setup for random damage throw
            Random r = new Random();

            //setting up player one starting stats
            Character p1 = new Character();
            p1.hp = 50;
            p1.minAtk = 1;
            p1.maxAtk = 10;

            //setting up first monster
            Character m1 = new Character();
            m1.hp = 30;
            m1.minAtk = 1;
            m1.maxAtk = 5;
            m1.name = "Large Rat";

            //bool namegood = false;

            //appearance of first NPC and player name entry
            Console.WriteLine("You awake in a cage in the dark. You hear a rough voice ask, 'What be your name lad?'");
            p1.name = Console.ReadLine();
            Console.WriteLine("{0}? What a terrible name!", p1.name);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("'Shhhh be quiet {0}!', whispers the voice, 'Is that a rat?! Kill it before you catch a disease!'", p1.name);
            //Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("A " + m1.name + " appears before you with " + m1.hp + " health and " + m1.maxAtk + " attack");
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
                        Console.WriteLine("You cannot run you are in a cage");
                        break;

                    default:
                        Console.WriteLine("Unknown command, the monster gets a free hit! Try again.");
                        break;

                }

                if (m1.hp > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The " + m1.name + " attacks you for " + m1.dmg + " damage");
                    p1.hp -= m1.dmg;
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
                Console.WriteLine("'Very good me lad, {0}, you were named poorly but ye be quite scrappy! Now make a lockpick and get us out of here', " +
                    "says the voice", p1.name);
            }

            Console.ReadKey();
        }
    }
}
