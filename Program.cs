using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp62
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandLightningWrath = "1";
            const string CommandMeteor = "2";
            const string CommandAntiTarget = "3";
            const string CommandHeroHealthRecovery = "4";
            const string CommandHeroAutoAttack = "5";

            Random random = new Random();

            int minMana = 75;
            int maxMana = 100;
            int heroManaRandom;
            heroManaRandom = random.Next(minMana, maxMana + 1);
            int minHeroHealth = 200;
            int maxHeroHealth = 350;
            float heroHealthRandom = random.Next(minHeroHealth, maxHeroHealth + 1);
            int minHeroArmor = 25;
            int maxHeroArmor = 50;
            int heroArmorRandom = random.Next(minHeroArmor, maxHeroArmor + 1);
            int minHeroDamage = 65;
            int maxHeroDamage = 115;
            int heroDamageRandom = random.Next(minHeroDamage, maxHeroDamage + 1);
            int minBossHealth = 400;
            int maxBossHealth = 550;
            float bossHealthRandom = random.Next(minBossHealth, maxBossHealth + 1);
            int minBossArmor = 25;
            int maxBossArmor = 75;
            int bossArmorRandom = random.Next(minBossArmor, maxBossArmor + 1);
            int minBossDamage = 75;
            int maxBossDamage = 100;
            int bossDamageRandom = random.Next(minBossDamage, maxBossDamage + 1);
            int minResistance = 20;
            int maxResistance = 45;
            int bossResistanceRandom;
            bossResistanceRandom = random.Next(minResistance, maxResistance + 1);
            int lightningWrath = 125;
            int wrathLightningCost = 20;
            int heroHealthRecovery = 110;
            int costTreatment = 35;
            int meteor = 240;
            int meteorCost = 50;
            int antiTarget = 0;
            int costAntiTarget = 20;
            int number = 100;
            string userInput;

            Console.WriteLine(" Вы попали на уровень с боссом, Вам нужно его победить или умрете ");
            Console.WriteLine(" Во время боя вы можете выбрать один из четырех заклинаний, каждое их использование будет тратить вашу ману ");
            Console.WriteLine(" Герой - " + heroHealthRandom + " хп, " + heroDamageRandom + " урон, " + heroArmorRandom + " броня " + heroManaRandom + " мана ");
            Console.WriteLine(" Босс - " + bossHealthRandom + " хп, " + bossDamageRandom + " урон, " + bossArmorRandom + " броня " + bossResistanceRandom + " сопротивление ");

            while (heroHealthRandom > 0 && bossHealthRandom > 0)
            {
                Console.WriteLine(CommandLightningWrath + " - Молния гнева, стоимсть маны " + wrathLightningCost + "," +  " наносит урона  " + lightningWrath);
                Console.WriteLine(CommandMeteor + " - Метеор позволяет нанести много урона,  стоимость маны " + meteorCost + "," +  " наносит урона  " + meteor);
                Console.WriteLine(CommandAntiTarget + " - Антитаргет позволяет уйти в инвиз и нанести урон боссу, стоимость маны , " + costAntiTarget + ","  + " наносит урона " + heroDamageRandom);
                Console.WriteLine(CommandHeroHealthRecovery + " - Отхил героя, стоимсть маны " + costTreatment + "," + " лечит героя на " + heroHealthRecovery + "," +  " но при этом вас босс может бить " );
                Console.WriteLine(CommandHeroAutoAttack + " - Автоатака героя, не тратит вашу ману , " + heroDamageRandom + " наносит урона ");
                userInput= Console.ReadLine();
 
                switch(userInput)
                {
                    case CommandLightningWrath:
                        Console.WriteLine(" Использована молния гнева ");
                        
                        if (wrathLightningCost <= heroManaRandom)
                        {
                            bossHealthRandom -= lightningWrath * bossResistanceRandom / number;
                            heroManaRandom -= wrathLightningCost;
                        }
                        else
                        {
                            Console.WriteLine(" Недостаточно маны ");
                        }
                      break;
                        
                        case CommandMeteor:
                        Console.WriteLine(" Использован метеор ");
                        if (meteorCost <= heroManaRandom)
                        {
                            bossHealthRandom -= meteor * bossResistanceRandom / number;
                            heroManaRandom -= meteorCost;
                        }
                        else 
                        {
                            Console.WriteLine(" Недостаточно маны ");
                        }
                        break;

                    case CommandAntiTarget:
                        Console.WriteLine(" Вы ушли в инвиз ");

                        if (costAntiTarget <= heroManaRandom)
                        {
                            heroHealthRandom += antiTarget + bossDamageRandom * heroArmorRandom / number;
                            bossHealthRandom -= heroDamageRandom * bossArmorRandom/ number;
                            heroManaRandom -= costAntiTarget;
                        }
                        else 
                        {
                            Console.WriteLine(" Недостаточно маны ");
                        }
                        break;

                    case CommandHeroHealthRecovery:
                        Console.WriteLine(" Вы использовали лечение ");

                        if ( costTreatment<=heroManaRandom)
                        {
                            heroHealthRandom += heroHealthRecovery - bossDamageRandom * heroArmorRandom / number;
                            heroManaRandom -= costTreatment;
                        }
                        else
                        {
                            Console.WriteLine(" Недостаточно маны ");
                        }
                        break;

                    case CommandHeroAutoAttack:
                        Console.WriteLine(" Вы нанесли урон боссу ");
                        bossHealthRandom -= heroDamageRandom * bossArmorRandom / number;
                        break;
                }    
              
                
               heroHealthRandom -= bossDamageRandom * heroArmorRandom / number;
             
               Console.WriteLine(" Герой -  " + heroHealthRandom + " здоровья " + heroManaRandom  + " маны ");
               Console.WriteLine(" Босс  - " + bossHealthRandom + " здоровья ");

            }
            if (heroHealthRandom <= 0 && bossHealthRandom <= 0)
            {
                Console.WriteLine(" Ничья ");
            }
            else if (heroHealthRandom <= 0)
            {
                Console.WriteLine(" Герой пал ");
            }
            else if (bossHealthRandom <= 0)
            {
                Console.WriteLine(" Босс пал ");
            }
        }
    }
}