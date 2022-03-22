using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DungeonRunner
{
    class Hero
    {
        public int health;
        public int strength;
        public int magic;
        public int armor;
        public int healthPotions;
        public int key;
        public int gold;
        public int heroLevel;

        /// <summary>
        /// Updates magic, health and strength based on level.
        /// </summary>
        public void UpdateHero()
        {
            magic = 15 + heroLevel;
            health = 190 + heroLevel * 10;
            strength = 19 + heroLevel;
        }
        /// <summary>
        /// Object for player character.
        /// </summary>
        public Hero()
        {
            //Creates base values.
            UpdateHero();
            armor = 5;
            healthPotions = 1;
            gold = 10;

        }

    }
    class Monster
    {
        public int health;
        public int strength;
        public int armor;
        public int gold;
        public int magicResist;

        /// <summary>
        /// object for an enemy with stats based on the level.
        /// </summary>
        /// <param name="level"></param>
        public Monster(int level)
        {
            health = 100;
            strength = 1 * level;
            armor = 2 + level;
            gold = 10 * level;
            magicResist = 30 - level * 2;
        }
    }

    class Program
    {
        /// <summary>
        /// Creates a text file with the new highscore.
        /// </summary>
        /// <param name="hero"></param>
        public static void HighScore(Hero hero)
        {
            //Creates highscore using remaning gold, health, health potions and level then writes it to a file named HighScore.txt.
            int newHighScore = hero.gold + hero.health + hero.healthPotions * 100 + hero.heroLevel * 100;
            StreamWriter file = new StreamWriter("HighScore.txt");
            file.Write("" + newHighScore);
            file.Close();
        }
        /// <summary>
        /// Generates a new enemy and handels the fight with said enemy.
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="level"></param>
        public static void Fight(Hero hero, int level)
        {
            //Creates new enemy with random level.
            Monster monster = new Monster(level + new Random().Next(1, 15));

            //Creates string for what happened and ConsoleKeyInfo for what key is pressed.
            string happened = "";
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            //Keeps the fight running while x isnt pressed and the enemy has more than 0 health.
            while (key.KeyChar != 'x' && monster.health > 0)
            {
                Console.Clear();

                Console.WriteLine("\n Hero:");
                Console.WriteLine(" Health: " + hero.health);
                Console.WriteLine("\n Monster:");
                Console.WriteLine(" Health: " + monster.health + "%");

                Console.WriteLine("\n");
                Console.WriteLine("" + happened);
                Console.WriteLine("\n");

                Console.WriteLine("(F) = Hit Monster");
                Console.WriteLine("(T) = Cast Spell On Monster");
                Console.WriteLine("(G) = Steal From Monster");
                Console.WriteLine("(H) = Drink Health Potion" + " " + hero.healthPotions);

                //Ends the fight if the player has less 0 or less health.
                if (hero.health <= 0)
                {
                    Console.Clear();
                    break;
                }

                //Waits for player to press a key.
                key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    //Removes the hero strength minus enemy armor from the enemys health and vice versa.
                    case 'f':
                        monster.health -= hero.strength - monster.armor;
                        hero.health -= monster.strength - hero.armor;
                        happened = "you hit the monster but it hit you back";
                        break;
                    //Uses a potion to heal the hero if they have one.
                    case 'h':
                        if (hero.healthPotions >= 1)
                        {
                            happened = "you used a Health Potion. You feel Refreshed";
                            hero.health += 100;
                            hero.healthPotions -= 1;
                        }
                        break;
                    //Tries to steal ten gold from the enemy.
                    case 'g':
                        if (monster.gold >= 10)
                        {
                            monster.gold -= 10;
                            hero.gold += 10;
                            hero.health -= monster.strength - hero.armor;
                            happened = "you tried to steal from the monster and found some gold but it hit you";

                            //This shit does so you get hit twice if steel enough gold from the enemy and lies.
                            if (monster.gold <= 10)
                            {

                                happened = "you tried to steal from the monster but coudnt find any gold on it, but it hit you";
                                hero.health -= monster.strength - hero.armor;

                            }
                        }
                        break;
                    //Deals magic damage to enemy minus enemy magic resist. enemy hit back
                    case 't':
                        monster.health -= hero.magic - monster.magicResist;
                        hero.health -= monster.strength - hero.armor;
                        happened = "you cast a spell on the monster and it hit you back";
                        break;
                }
                Console.Clear();
            }
        }
        /// <summary>
        /// Gets a two dimensional array for the map, the x and y for the character and the character itself.
        /// <br/>
        /// Then prints the map with the character and all the actions the player can take.
        /// </summary>
        /// <param name="maze"></param>
        /// <param name="hX"></param>
        /// <param name="hY"></param>
        /// <param name="hero"></param>
        public static void PrintMap(int[,] maze, int hX, int hY, Hero hero)
        {
            //Creates a char c and print the map.
            char c = ' ';
            for (int y = 0; y < maze.GetLength(0); y++)
            {
                Console.Write("\n  ");
                for (int x = 0; x < maze.GetLength(1); x++)
                {
                    if (x == hX && y == hY)
                    {
                        Console.Write((char)2);
                    }
                    else
                    {
                        switch (maze[y, x])
                        {
                            case 0: c = ' '; break;
                            case 1: c = '#'; break;
                            case 2: c = '@'; break;
                            case 3: c = '%'; break;
                            case 4: c = '*'; break;
                            case 5: c = ' '; break;
                            case 6: c = ' '; break;
                        }
                        Console.Write(c);
                    }
                }
            }
            //Prints the actions the player can take.
            Console.WriteLine("\n\n");
            Console.WriteLine("   Options     Level:" + hero.heroLevel);
            Console.WriteLine("   A = Move Left       D = Move Right");
            Console.WriteLine("   S = Move Down       W = Move Up");
            Console.Write("   HeroStats: " + "Strenght  " + hero.strength + "   " + "Health  " + hero.health);
            Console.WriteLine("\n" + "   Gold: " + hero.gold + "   press b to buy a level for 100 Gold");
            Console.WriteLine("\n " + " ? = player // # = wall // @ = healthpotion // % = key // * = locked door ");
            Console.WriteLine("\n");
            Console.WriteLine("   X To Exit Game");
        }
        static void Main(string[] args)
        {

            //Creates a new hero object and its position
            Hero hero = new Hero();
            int heroX = 1;
            int heroY = 1;

            //Two-dimensional array used as the map.
            int[,] maze =
{                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, },
                 { 1,0,1,6,0,0,0,0,0,0,0,6,0,0,0,0,0,0,6,1, },
                 { 1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1, },
                 { 1,0,1,0,1,1,0,0,0,0,0,0,0,1,0,0,0,1,0,1, },
                 { 1,6,0,0,2,1,0,1,1,1,1,1,0,1,0,1,0,1,0,1, },
                 { 1,1,1,1,1,1,0,1,0,6,0,1,0,0,0,1,2,0,0,1, },
                 { 1,0,0,0,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1, },
                 { 1,0,1,1,0,0,0,1,0,1,0,1,1,1,1,1,0,0,0,1, },
                 { 1,6,1,1,2,1,6,0,0,1,0,0,0,6,0,0,0,1,6,1, },
                 { 1,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,1, },
                 { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,5,1, },             };

            //This will run until a break; happens.
            while (true)
            {
                //Clears the console and checks where the hero object is.
                Console.Clear();
                //Starts a fight if the hero is on a 6 and then sets it to a 0.
                if (maze[heroY, heroX] == 6)
                {
                    Fight(hero, maze[heroY, heroX]);
                    maze[heroY, heroX] = 0;
                }
                //Gives the hero a potion if it is on a 2 and then sets it to a 0.
                if (maze[heroY, heroX] == 2)
                {
                    hero.healthPotions += 1;
                    maze[heroY, heroX] = 0;
                }
                //Gives the hero a key if it is on a 3 and then sets it to a 0.
                if (maze[heroY, heroX] == 3)
                {
                    hero.key += 1;
                    maze[heroY, heroX] = 0;
                }

                //ends the game if the hero is on a 4 and has 1 or less keys. this is the win condition.
                if (maze[heroY, heroX] == 4 && hero.key <= 1)
                {
                    Console.Clear();
                    Console.WriteLine("You Won The Game!");
                    Console.WriteLine("Your Score has ben saved to your binFolder");
                    Console.WriteLine("Press Enter to exit");
                    HighScore(hero);

                    Console.ReadLine();
                    break;
                }


                //ends the game if the hero has 0 or less health. this is the lose condition.
                if (hero.health <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("\n The Monster Killed you!");
                    Console.WriteLine("You Lost The GAME!");
                    Console.WriteLine("\n Press Enter To Exit");
                    Console.ReadLine();
                    break;
                }

                //prints the map using PrintMap and moves the hero in a direction if there isnt a wall there.
                PrintMap(maze, heroX, heroY, hero);
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.KeyChar == 'w' && maze[heroY - 1, heroX] != 1 && maze[heroY + 1, heroX] != 5) heroY--;
                if (key.KeyChar == 'a' && maze[heroY, heroX - 1] != 1 && maze[heroY + 1, heroX] != 5) heroX--;
                if (key.KeyChar == 's' && maze[heroY + 1, heroX] != 1 && maze[heroY + 1, heroX] != 5) heroY++;
                if (key.KeyChar == 'd' && maze[heroY, heroX + 1] != 1 && maze[heroY + 1, heroX] != 5) heroX++;
                if (key.KeyChar == 'b' && hero.gold >= 100) { hero.gold -= 100; hero.heroLevel++; hero.UpdateHero(); }

                //ends the game if the player presses x. this is the quit condition.
                if (key.KeyChar == 'x')
                    break;

            }
        }
    }
}