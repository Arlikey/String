using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Threading.Channels;
using System.Transactions;

namespace String
{
    /*internal class Program
    {
        static void Main(string[] args)
        {
            String str = new String("Hello world");

            Console.WriteLine($"String: {str}. Length: {str.Length}");

            String str2 = new String(str, 6);

            Console.WriteLine($"String: {str2}. Length: {str2.Length}");

            String str3 = new String(10);

            Console.WriteLine($"String: {str3}. Length: {str3.Length}");
        }

        public class String
        {
            private char[] array;

            public int Length => array.Length;

            public char this[int index] => array[index];

            public override string ToString()
            {
                return array.Length == 0 ? "Пустая строка" : new string(array);
            }

            public String(string text)
            {
                array = text.ToCharArray();
            }

            public String(String text, int length)
            {
                if (length < 0 || length > text.Length)
                {
                    throw new Exception("Not valid length!");
                }
                array = new char[length];
                for (int i = 0; i < length; i++)
                {
                    array[i] = text[i];
                }
            }

            public String(int length)
            {
                array = new char[length];
            }

        }
    }*/

    /*public class AdditionalTask1
    {
        static void Main()
        {
            Team dreamTeam = new Team(new Unit[] {
                new Fighter(100, 30, 10),
                new Wizard(85, 25, 15, 40),
                new Archer(90, 20, 20, 200)
            });

            dreamTeam.ShowInfoAboutTeam();

            dreamTeam.AddUnit(new Archer(75, 10, 15, 100));

            dreamTeam.ShowInfoAboutTeam();

            Console.WriteLine("\nПЕРВАЯ АТАКА\n");

            dreamTeam.Attack();

            dreamTeam.RemoveUnit(3);

            dreamTeam.ShowInfoAboutTeam();

            Console.WriteLine("\nВТОРАЯ АТАКА\n");

            dreamTeam.Attack();

        }

        public class Team
        {
            private Unit[] team;

            public Team(Unit[] team)
            {
                this.team = team;
            }

            public int Count => team.Length;

            public Unit this[int place] => (place >= 0 && place < team.Length) ? team[place] : throw new Exception("Not valid place!");
            public void AddUnit (Unit unit)
            {
                Unit[] newTeam = new Unit[team.Length+1];
                for (int i = 0; i < team.Length; i++)
                {
                    newTeam[i] = team[i];
                }
                newTeam[newTeam.Length - 1] = unit;
                team = newTeam;
            }

            public void RemoveUnit(int place)
            {
                Unit[] newTeam = new Unit[team.Length - 1];
                for (int i = 0, j = 0; i < team.Length; i++)
                {
                    if (i == place) { continue; }
                    newTeam[j++] = team[i];
                }
                team = newTeam;
            }

            public void Attack()
            {
                Random randomStats = new Random();

                foreach (Unit unit in team)
                {
                    if (unit is Fighter fighter)
                    {
                        fighter.Attack(randomStats.Next(10, 100));
                    }
                    else if (unit is Archer archer)
                    {  
                        archer.Shoot(175);
                    }
                    else if (unit is Wizard wizard)
                    {   
                        wizard.CastFireball();
                    }
                }
            }

            public void ShowInfoAboutTeam()
            {
                Console.WriteLine("\n\nОТРЯД:\n\n");
                for (int i = 0; i < team.Length; i++)
                {
                    Console.WriteLine(team[i].Info());
                }
            }
        }
        public abstract class Unit
        {
            protected Unit(int health, int damage, int speed)
            {
                Health = health;
                Damage = damage;
                Speed = speed;
            }

            public int Health { get; set; }
            public int Damage { get; set; }
            public int Speed { get; set; }

            public virtual string Info() {
                return $"HP - {Health}, Урон - {Damage}, Скорость - {Speed}";
            }
        }

        public class Fighter : Unit
        {
            public Fighter(int health, int damage, int speed) : base(health, damage, speed)
            {
            }

            public int AttackPower { get; private set; }

            public void Attack(int power)
            {
                AttackPower = power;

                Console.WriteLine($"Воин атакует с мощностью {AttackPower}.");
            }

            public override string Info()
            {
                return $"Воин: {base.Info()}";
            }
        }

        public class Archer : Unit
        {
            public Archer(int health, int damage, int speed, int fireRange) : base(health, damage, speed)
            {
                FireRange = fireRange;
            }

            public int FireRange { get; set; }

            public void Shoot(int range)
            {
                if ( FireRange >= range ) {
                    Console.WriteLine("Лучник выстрелил в цель.");
                }
                else
                {
                    Console.WriteLine("Цель слишком далеко!");
                }
            }
            public override string Info()
            {
                return $"Лучник: {base.Info()}, Дальность стрельбы - {FireRange}";
            }
        }

        public class Wizard : Unit
        {
            public Wizard(int health, int damage, int speed, int mana) : base(health, damage, speed)
            {
                Mana = mana;
            }

            public int Mana { get; set; }

            public void CastFireball()
            {
                int ManaCost = 30;

                if ( (Mana -= ManaCost) >= 0 ) {
                    Console.WriteLine("Волшебник запустил огненный шар во врага.");
                }
                else
                {
                    Console.WriteLine("Недостаточно маны!");
                }
            }
            public override string Info()
            {
                return $"Маг: HP - {Health}, MP - {Mana}, Урон - {Damage}, Скорость - {Speed}";
            }
        }
    }*/

    /*public class AdditionalTask2
    {
        static void Main()
        {
            Money money = new Money(72, 40);
            Console.WriteLine(money.Amount());

            Good good = new Good("Potato", 3, money);
            good.DecreasePrice(20);
            Console.WriteLine(good.Info());
        }

        public class Money
        {
            private int banknotes;
            public int Banknotes
            {
                get => banknotes;
                set => banknotes = value;
            }

            private int coins;
            public int Coins
            {
                get => coins;
                set
                {
                    if (value > 99)
                    {
                        banknotes += value / 100;
                        coins = value % 100;
                    }
                    else
                    {
                        coins = value;
                    }
                }
            }

            public Money(int banknotes, int coins)
            {
                this.banknotes = banknotes;
                Coins = coins;
            }

            public string Amount()
            {
                return $"{Banknotes}.{Coins}";
            }
        }

        public class Good
        {
            public Good(string name, int count, Money price)
            {
                Name = name;
                Count = count;
                Price = price;
            }

            public string Name { get; set; }
            public int Count { get; set; }
            public Money Price { get; set; }

            public void DecreasePrice(double percent)
            {
                int totalCoins = Price.Banknotes * 100 + Price.Coins;

                double newTotalCoins = totalCoins * (1 - percent / 100);

                Price.Banknotes = (int)newTotalCoins / 100;
                Price.Coins = (int)newTotalCoins % 100;
            }

            public string Info()
            {
                return $"{Price.Amount()}";
            }
        }
    }*/

    /*public class AdditionalTask5
    {
        static void Main()
        {
            Array array = new Array(new int[] { 1, 2, 3, });

            Random rand = new Random();
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"{i}) array element {array[rand.Next(0, 6)]}");
            }
            Console.WriteLine($"Count - {array.Count}");
        }

        public class Array
        {
            private int[] array;

            public int Count { get; set; }
            public int Length { get => array.Length; }
            public Array(int[] array) { 
                this.array = array;
            }

            public int this[int index]
            {
                get
                {
                    if (index < 0 || index >= array.Length)
                    {
                        Count++;
                        return -1;
                    }
                    return array[index];
                }
            }
        }
    }*/
}
