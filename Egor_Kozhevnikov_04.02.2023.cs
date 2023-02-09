using System;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace hey
{
    class Programm
    {
        static void Main()
        {
            Console.Clear();
            List<Stud> stud = new List<Stud>();
            int q = 0;
            while(true)
            {
                Console.WriteLine("==Студенты==\n\n1) Заполните список студентов\n2) Выборка по...");
                int n = Convert.ToInt32(Console.ReadLine());
                if (n == 1) { A1(ref stud, ref q); }
                else if (n == 2 && q > 0) { A2(stud); }
                else { Console.WriteLine("Нет данных, заполните список студентов"); Console.ReadKey(); Main(); }
            }
        }
        static void A1(ref List<Stud> stud, ref int q)
        {
            Console.Clear();
            Console.WriteLine("==Заполнение==\n");
            Console.Write("Введите количество студентов: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.Write("ФИО: ");
                string fio = Console.ReadLine();
                Console.Write("День рожения: ");
                int day = Convert.ToInt32(Console.ReadLine());
                Console.Write("Месяц рождения: ");
                int month = Convert.ToInt32(Console.ReadLine());
                Console.Write("Год рождения: ");
                int year = Convert.ToInt32(Console.ReadLine());
                Console.Write("Группа: ");
                string group = Console.ReadLine();

                Console.Write("Введите кол-во предметов: ");
                int k;
                k = Convert.ToInt32(Console.ReadLine());
                string[] subj = new string[k];
                for (int j = 0; j < k; j++)
                {
                    Console.Write("Предмет: ");
                    subj[j] = Console.ReadLine();
                }

                int[] score = new int[k];
                for (int j = 0; j < k; j++)
                {
                    Console.Write($"Оценка по {subj[j]}: ");
                    score[j] = Convert.ToInt32(Console.ReadLine());
                }

                stud.Add(new Stud(fio, day, month, year, group, subj, score));

                Console.WriteLine();

            }
            q++;
            Console.Clear();
        }

        static void A2(List<Stud> stud)
        {
            Console.Clear();
            Console.WriteLine("Сделать выбору студентов по:\n1) Группе\n2) Должникам\n3) Отличникам\n4) Моложе 20-ти лет\n\nВ меню...(5)");
            int l;
            l = Convert.ToInt32(Console.ReadLine());
            if (l == 1) { A3(stud); }
            else if (l == 2) { A4(stud); }
            else if (l == 3) { A5(stud); }
            else if(l == 4) {A6(stud); }
            else if (l == 5) { Main(); }
            Console.WriteLine("В меню...(1)\nПродолжить выборку по...(2)");
            int n;
            if ((n = Convert.ToInt32(Console.ReadLine())) == 1) { Main(); }
            else { A2(stud); }
        }

        static void A3(List<Stud> stud)
        {
            Console.Clear();
            Console.Write("Введите группу: ");
            string group;
            group = Console.ReadLine();
            List<string> name = new List<string>();
            for (int i = 0; i < stud.Count; i++)
            {
                if (stud[i].Group == group)
                {
                    name.Add(stud[i].FIO);
                }
            }

            if (name.Count > 0)
            {
                for (int i = 0; i < name.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {name[i]}");
                }
            }
            else { Console.WriteLine("Данной группы нет"); }

        }
        static void A4(List<Stud> stud)
        {
            Console.Clear();
            List<string> name = new List<string>();
            for (int i = 0; i < stud.Count; i++)
            {
                for (int j = 0; j < stud[i].Score.Length; j++)
                {
                    if (stud[i].Score[j] < 3)
                    {
                        name.Add(stud[i].FIO);
                    }
                }
            }
            for (int i = 0; i < name.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {name[i]}");
            }
        }
        static void A5(List<Stud> stud)
        {
            Console.Clear();
            List<string> name = new List<string>();
            for (int i = 0; i < stud.Count; i++)
            {
                int k = 0;
                for (int j = 0; j < stud[i].Score.Length; j++)
                {
                    if (stud[i].Score[j] == 5)
                    {
                        k++;
                    }
                }
                if (k == stud[i].Score.Length)
                {
                    name.Add(stud[i].FIO);
                }
            }
            for (int i = 0; i < name.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {name[i]}");
            }
        }

        static void A6(List<Stud> stud)
        {
            Console.Clear();
            List<string> name = new List<string>();
            for (int i = 0; i < stud.Count; i++)
            {
                if (stud[i].Year >= 2003)
                {
                    if (stud[i].Month >= 2)
                    {
                        if (stud[i].Day > 9)
                        {
                            name.Add(stud[i].FIO);
                        }
                    }
                }


            }
            for (int i = 0; i < name.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {name[i]}");
            }
        }
    }

    class Stud
    {
        public string FIO;
        public int Day, Month, Year;
        public string Group;
        public string[] Subj;
        public int[] Score;

        public Stud(string fio, int day, int month, int year, string group, string[] subj, int[] score)
        {
            FIO = fio;
            Day = day;
            Month = month;
            Year = year;
            Group = group;
            Subj = subj;
            Score = score;
        }
    }
}
