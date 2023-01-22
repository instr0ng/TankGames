using System;

namespace Game
{

    interface Interface
    {

    }

    public class Tank
    {
        public int MAX_HP;
        public int HP;
        public int Armor;
        public int Damage;
        public int MAX_Ammo;
        public int Cnt_Ammo;
        Random rand = new Random();

        public Tank(int h, int ar, int dm, int ammo)
        {
            MAX_HP = HP = h;
            Armor = ar;
            Damage = dm;
            MAX_Ammo = Cnt_Ammo = ammo;
        }

        public string Shot(Tank name_target)
        {
            string info;
            int HC = rand.Next(1, 11);
            if (HC < 9)
            {
                if (HC > 1)
                {
                    name_target.HP -= (Damage - name_target.Armor);
                    Cnt_Ammo--;
                    info = " Нанесено " + (Damage - name_target.Armor) + " урона";
                }
                else
                {
                    name_target.HP -= (int)(Damage * 1.2 - name_target.Armor);
                    Cnt_Ammo--;
                    info = " Критическое попадание! Нанесено " + (int)(Damage * 1.2 - name_target.Armor) + " урона";
                }
            }
            else
            {
                info = " Промах";
                Cnt_Ammo--;
            }
            return info;
        }

        public void Repair()
        {
            HP += 50;
            if (HP > MAX_HP)
                HP = MAX_HP;
        }

        public void Buy_Ammo()
        {
            Cnt_Ammo = MAX_Ammo;
        }
    }

    class Game
    {
        static void Main()
        {
            Tank Player_Tank = new (500, 20, 100, 8);
            Tank Enemy_Tank = new (300, 20, 50, 5);
            Random Enemy_deystvie = new();
            ConsoleKeyInfo deystvie;
            int bb;

            while (Player_Tank.HP > 0 && Enemy_Tank.HP > 0)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                Console.WriteLine($"My Tank HP =  {Player_Tank.HP} Armor = {Player_Tank.Armor}  Damage = {Player_Tank.Damage} Ammo = {Player_Tank.Cnt_Ammo}\n");
                Console.WriteLine($"Enemy Tank HP =  {Enemy_Tank.HP} Armor = {Enemy_Tank.Armor} Damage = {Enemy_Tank.Damage} Ammo = {Enemy_Tank.Cnt_Ammo}\n");
                Console.WriteLine("Выберите действие:\n");
                Console.WriteLine("1. Выстрел\n");
                Console.WriteLine("2. Починка \n");
                Console.WriteLine("3. Купить боеприпасы\n");
                Console.WriteLine("Ваш ход: ");
                deystvie = Console.ReadKey();
                switch (deystvie.Key)
                {
                    case ConsoleKey.D1 or ConsoleKey.NumPad1:

                        if (Player_Tank.Cnt_Ammo > 0)
                            Console.WriteLine(Player_Tank.Shot(Enemy_Tank));
                        else
                            Console.WriteLine("У вас кончились снаряды");
                        break;

                    case ConsoleKey.D2 or ConsoleKey.NumPad2:
                        Player_Tank.Repair();
                        break;

                    case ConsoleKey.D3 or ConsoleKey.NumPad3:
                        Player_Tank.Buy_Ammo();
                        break;

                    default:
                        Console.WriteLine("\nНеверная клавиша\nНажмите любую клавишу чтобы продолжить");
                        Console.ReadKey();
                        continue;

                }

                Console.Write("\nХод противника: ");
                if (Enemy_Tank.HP == Enemy_Tank.MAX_HP)
                    bb = 1;
                else
                    bb = Enemy_deystvie.Next(1, 3);
                switch (bb)
                {
                    case 1:
                        if (Enemy_Tank.Cnt_Ammo > 0)
                        {
                            Console.WriteLine("1. Выстрел\n");
                            Console.WriteLine(Enemy_Tank.Shot(Player_Tank));
                        }
                        else
                        {
                            Console.WriteLine("3. Купить боеприпасы\n");
                            Enemy_Tank.Buy_Ammo();
                        }
                        break;

                    case 2:
                        Console.WriteLine("2. Починка\n");
                        Enemy_Tank.Repair();
                        break;
                        
                }
                Console.WriteLine($"My Tank HP =  {Player_Tank.HP} Armor = {Player_Tank.Armor}  Damage = {Player_Tank.Damage} Ammo = {Player_Tank.Cnt_Ammo}\n");
                Console.WriteLine($"Enemy Tank HP =  {Enemy_Tank.HP} Armor = {Enemy_Tank.Armor} Damage = {Enemy_Tank.Damage} Ammo =  {Enemy_Tank.Cnt_Ammo} \n");
                Console.WriteLine("-----------------------------------------------------------------------------------------------");

                Console.Write("Нажмите любую клавишу чтобы продолжить");
                Console.ReadKey();

            }
            Console.Clear();
            if (Player_Tank.HP > 0)
                Console.WriteLine("Вы выиграли!");
            else
                Console.WriteLine("Вы проиграли!");
        } 
    }
}
