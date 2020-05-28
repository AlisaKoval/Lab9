using System;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Collections.Generic;
namespace Lab9._1a
{

    class Program
    {
        public enum Type { И, А, Т }
        struct Telecast
        {
            public string telecast;
            public string key;
            public int top;
            public Type type;
            public void Print()
            {
                Console.WriteLine("{0,-20}{1,-20}{2,-10}{3,-10}", telecast, key, top, type);
            }
        }
        struct Log
        {
            public DateTime time;
            public string name;
            public string operation;
            public void Print()
            {
                Console.WriteLine("{0,-20} - {1,-20} {2,-15}", time, operation, name);
            }
        }
        static async Task Main(string[] args)
        {
            DoublyLinkedList<Telecast> table = new DoublyLinkedList<Telecast>();
            DoublyLinkedList<Log> log = new DoublyLinkedList<Log>();

            DateTime time1 = DateTime.Now;
            DateTime time2 = DateTime.Now;
            TimeSpan interval = time2 - time1;

            string PathTextFile = @"C:\Users\alisa\source\repos\Lab9\Lab9.1a\lab.dat";

            using (StreamReader readTextFile = new StreamReader(PathTextFile))
            {
                bool first = true;
                while (readTextFile.Peek() > -1)
                {
                    string telecast = await readTextFile.ReadLineAsync();
                    string key = await readTextFile.ReadLineAsync();
                    int top = Convert.ToInt32(await readTextFile.ReadLineAsync());
                    string typeText = await readTextFile.ReadLineAsync();
                    Type type;
                    type = Type.А;
                    if (typeText == "A" || typeText == "А")
                    {
                        type = Type.А;
                    }
                    else if (typeText == "И")
                    {
                        type = Type.И;
                    }
                    else if (typeText == "T" || typeText == "Т")
                    {
                        type = Type.Т;
                    }
                    Telecast newTelecast;
                    newTelecast.telecast = telecast;
                    newTelecast.key = key;
                    newTelecast.top = top;
                    newTelecast.type = type;
                    if(first)
                    {
                        table.AddFirst(newTelecast);
                        first = false;
                    }
                    else
                    {
                        table.Add(newTelecast);
                    }
                }
            }



            bool errorOption = true;
            do
            {
                int f = table.Count;
                Console.WriteLine("1 - Просмотр таблицы\n2 - Добавить запись\n3 - Удалить запись\n4 - Обновить запись\n5 - Поиск записей\n6 - Просмотреть лог\n7 - Выход");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        foreach (Telecast telecasts in table)
                        {
                            telecasts.Print();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Введите название передачи");
                        string telecast = Console.ReadLine();
                        Console.WriteLine("Введите имя ведущего");
                        string key = Console.ReadLine();
                        bool errorTop = false;
                        int top = 0;
                        do
                        {
                            Console.WriteLine("Введите рейтинг");
                            try
                            {
                                top = int.Parse(Console.ReadLine());
                                errorTop = false;
                            }
                            catch
                            {
                                Console.WriteLine("Введите верный рейтинг");
                                errorTop = true;
                            }
                        }
                        while (errorTop);
                        Console.WriteLine("Введите тип передачи(И-Игровая, А - Аналитическая, Т - Ток-шоу)");
                        bool errorType = false;
                        Type type = Type.А;
                        do
                        {
                            string s_type = Console.ReadLine();
                            if (s_type == "И")
                            {
                                type = Type.И;
                                errorType = false;
                            }
                            else if (s_type == "Т")
                            {
                                type = Type.Т;
                                errorType = false;
                            }
                            else if (s_type == "А")
                            {
                                type = Type.А;
                                errorType = false;
                            }
                            else
                            {
                                Console.WriteLine("Введите верный тип : А или И или Т");
                                errorType = true;
                            }
                        }
                        while (errorType);
                        Telecast newTelecast;
                        newTelecast.telecast = telecast;
                        newTelecast.key = key;
                        newTelecast.top = top;
                        newTelecast.type = type;
                        table.Add(newTelecast);

                        Log ADD;
                        ADD.time = DateTime.Now;
                        ADD.operation = "Добавлена запись";
                        ADD.name = telecast;
                        log.Add(ADD);

                        time1 = DateTime.Now;
                        TimeSpan interval2 = time1 - time2;
                        if (interval < interval2)
                        {
                            interval = interval2;
                        }
                        time2 = ADD.time;
                        break;
                    case 3:
                        Console.WriteLine("Введите номер записи, которую нужно удалить");
                        bool errorDelete = false;
                        do
                        {
                            try
                            {
                                int iForDelete = int.Parse(Console.ReadLine());
                                if (iForDelete <= table.Count && iForDelete > 0)
                                {
                                    Log DELETE = new Log();
                                    DELETE.time = DateTime.Now;
                                    DELETE.operation = "Запись удалена";
                                    int i = 0;
                                    string deleteName = "";
                                    foreach(Telecast telecast1 in table)
                                    {
                                        if (i == iForDelete-1)
                                        {
                                            deleteName = telecast1.telecast;
                                            table.Remove(telecast1);
                                        }
                                        i++;
                                    }
                                    DELETE.name = deleteName;
                                    log.Add(DELETE);
                                    time1 = DateTime.Now;
                                    interval2 = time1 - time2;
                                    if (interval < interval2)
                                    {
                                        interval = interval2;
                                    }
                                    time2 = DELETE.time;
                                    errorDelete = false;
                                }
                                else
                                {
                                    Console.WriteLine("Введите верный номер строки");
                                    errorDelete = true;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Введите верный номер строки");
                                errorDelete = true;
                            }
                        }
                        while (errorDelete);
                        break;
                    case 4:
                        Console.WriteLine("Введите номер строки для обновления");
                        bool errorEdit = false;
                        int iForEdit = 0;
                        do
                        {
                            try
                            {
                                iForEdit = int.Parse(Console.ReadLine());
                                if (iForEdit <= table.Count && iForEdit > 0)
                                {
                                    errorEdit = false;
                                }
                                else
                                {
                                    Console.WriteLine("Введите верный номер строки");
                                    errorEdit = true;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Введите верный номер строки");
                                errorEdit = true;
                            }
                        }
                        while (errorEdit);
                        int cnt = 0;
                        foreach (Telecast telecast1 in table)
                        {
                            if (cnt == iForEdit - 1)
                            {
                                table.Remove(telecast1);
                                break;
                            }
                            cnt++;

                        }
                        Console.WriteLine("Введите название передачи");
                        string oldTelecast = Console.ReadLine();
                        Console.WriteLine("Введите имя ведущего");
                        string oldKey = Console.ReadLine();
                        int oldTop = 0;
                        do
                        {
                            Console.WriteLine("Введите рейтинг");
                            try
                            {
                                oldTop = int.Parse(Console.ReadLine());
                                errorTop = false;
                            }
                            catch
                            {
                                Console.WriteLine("Введите верный рейтинг");
                                errorTop = true;
                            }
                        }
                        while (errorTop);
                        Console.WriteLine("Введите тип передачи(И-Игровая, А - Аналитическая, Т - Ток-шоу)");
                        errorType = false;
                        Type oldType = Type.А;
                        do
                        {
                            string s_type = Console.ReadLine();
                            if (s_type == "И")
                            {
                                oldType = Type.И;
                                errorType = false;
                            }
                            else if (s_type == "Т")
                            {
                                oldType = Type.Т;
                                errorType = false;
                            }
                            else if (s_type == "А")
                            {
                                oldType = Type.А;
                                errorType = false;
                            }
                            else
                            {
                                Console.WriteLine("Введите верный тип : А или И или Т");
                                errorType = true;
                            }
                        }
                        while (errorType);
                        Telecast EditTelecast;
                        EditTelecast.telecast = oldTelecast;
                        EditTelecast.key = oldKey;
                        EditTelecast.top = oldTop;
                        EditTelecast.type = oldType;
                        table.Insert(EditTelecast, iForEdit - 1);

                        Log UPDATE;
                        UPDATE.time = DateTime.Now;
                        UPDATE.operation = "Измненена запись";
                        UPDATE.name = oldTelecast;
                        log.Add(UPDATE);

                        time1 = UPDATE.time;
                        interval2 = time1 - time2;
                        if (interval < interval2)
                        {
                            interval = interval2;
                        }
                        time2 = UPDATE.time;         
                        break;
                    case 5:
                        Console.WriteLine("Выберите пункт:");
                        int iOfChoise = 0;
                        bool errorChoise = false;
                        Console.WriteLine("1 - Вывести игровые передачи \n2 - Вывести Аналитические передачи \n3 - Вывести ток-шоу");
                        do
                        {
                            try
                            {
                                iOfChoise = int.Parse(Console.ReadLine());
                                if (iOfChoise == 1)
                                {
                                    foreach(Telecast telecast1 in table)
                                    {
                                        if (telecast1.type == Type.И)
                                        {
                                            telecast1.Print();
                                        }
                                    }                              
                                    errorChoise = false;
                                }
                                else if (iOfChoise == 2)
                                {
                                    foreach (Telecast telecast1 in table)
                                    {
                                        if (telecast1.type == Type.А)
                                        {
                                            telecast1.Print();
                                        }
                                    }
                                    errorChoise = false;
                                }
                                else if (iOfChoise == 3)
                                {
                                    foreach (Telecast telecast1 in table)
                                    {
                                        if (telecast1.type == Type.Т)
                                        {
                                            telecast1.Print();
                                        }
                                    }
                                    errorChoise = false;
                                }
                                else
                                {
                                    errorChoise = true;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Введите верный пункт");
                                errorChoise = true;
                            }
                        }
                        while (errorChoise);
                        break;
                    case 6:
                        foreach (Log logs in log)
                        {
                            logs.Print();
                        }
                        Console.WriteLine();
                        Console.WriteLine("{0} - Самый долгий период бездействия пользователя", interval);
                        break;
                    case 7:
                        errorOption = false;
                        using (StreamWriter sw = new StreamWriter(PathTextFile, false))
                        {
                            foreach( Telecast telecast1  in table)
                            {
                                await sw.WriteLineAsync(telecast1.telecast + "\n" + telecast1.key + "\n" + telecast1.top + "\n" + telecast1.type);
                            }
                            sw.Close();
                        }
                        break;
                    default:
                        Console.WriteLine("Введите верную операцию");
                        errorOption = true;
                        break;
                }

            }
            while (errorOption);
        }
    }
}

