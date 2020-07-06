using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Note> notes = new List<Note>();
            while (true)
            {
                Console.WriteLine("Команды: Нажмите 1, чтобы создать запись\nНажмите 2, чтобы редактировать запись\n" +
                    "Нажмите 3 для удаления\n Нажмите 4 - все записи" +
                    "\n Нажмите 5 - все записи кратко\n Нажмите 6 - Exit");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.Write("Введите фамилию: ");
                        string surname = Console.ReadLine();
                        while (surname == "")
                        {
                            Console.Write("Это обязательное поле, попробуйте внести ещё раз: ");
                            surname = Console.ReadLine();
                        }
                        Console.Write("Введите имя: ");
                        string name = Console.ReadLine();
                        while (name == "")
                        {
                            Console.Write("Это обязательное поле, попробуйте внести ещё раз: ");
                            name = Console.ReadLine();
                        }
                        Console.Write("Введите отчество (или оставьте поле пустым): ");
                        string patronymic = Console.ReadLine();
                        Console.Write("Введите номер телефона (без +7): ");
                        string number = Console.ReadLine();
                        while (number.Length != 10)
                        {
                            Console.Write("Введите корректно (Без +7, только 10 цифр): ");
                            number = Console.ReadLine();
                        }
                        Console.Write("Введите страну (0 - Россия, 1 - Украина, 2 - Беларусь, 3 - Казахстан): ");
                        string countryStr = Console.ReadLine();
                        while (countryStr != "0" && countryStr != "1" && countryStr != "2" && countryStr != "3")
                        {
                            Console.Write("Введите страну (0 - Россия, 1 - Украина, 2 - Беларусь, 3 - Казахстан): ");
                            countryStr = Console.ReadLine();
                        }
                        Countries country = 0;
                        switch (countryStr)
                        {
                            case "0":
                                country = Countries.Russia;
                                break;
                            case "1":
                                country = Countries.Ukraine;
                                break;
                            case "2":
                                country = Countries.Belarus;
                                break;
                            case "3":
                                country = Countries.Kazakhstan;
                                break;
                        }
                        Console.Write("Введите дату рождения (или оставьте поле пустым): ");
                        string birthdayStr = Console.ReadLine();
                        DateTime birthday;
                        Console.Write("Введите организацию (или оставьте поле пустым): ");
                        string organisation = Console.ReadLine();
                        Console.Write("Введите профессию (или оставьте поле пустым): ");
                        string profession = Console.ReadLine();
                        Console.Write("Введите заметки (или оставьте поле пустым): ");
                        string note = Console.ReadLine();
                        notes.Add(new Note()
                        {
                            Surname = surname,
                            Name = name,
                            Patronymic = patronymic,
                            Number = number,
                            Country = country,
                            Organisation = organisation,
                            Profession = profession,
                            Notes = note
                        });
                        if (birthdayStr != "")
                        {
                            if (DateTime.TryParse(birthdayStr, out birthday))
                            {
                                notes[notes.Count - 1].Birthday = birthday;
                            }
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("----------------");
                        for (int i = 0; i < notes.Count; i++)
                        {
                            Console.WriteLine($"ID: {i + 1}\nФИО: {notes[i].Surname} {notes[i].Name} {notes[i].Patronymic}\nНомер телефона: {notes[i].Number}");
                            Console.WriteLine("----------------");
                        }
                        bool checkStatus = false;
                        string idChange;
                        do
                        {
                            Console.Write("Введите номер записи, которую необходимо изменить (либо -1, если хотите выйти): ");
                            idChange = Console.ReadLine();
                            if (Int32.TryParse(idChange, out int idChangeInt))
                            {
                                if ((idChangeInt >= 1 && idChangeInt <= notes.Count) || idChangeInt == -1)
                                {
                                    checkStatus = true;
                                }
                                else
                                {
                                    Console.WriteLine("ID введён некорректно.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("ID введён некорректно.");
                            }
                        } while (!checkStatus);
                        if (Convert.ToInt32(idChange) != -1)
                        {
                            bool editStatus = true;
                            Console.WriteLine("Выберите, какую информацию хотите изменить, и введите 0, когда закончите");
                            do
                            {
                                Console.WriteLine("1 - Фамилия, 2 - Имя, 3 - Отчество, 4 - Номер телефона, 5 - Страна, 6 - День рождения, 7 - Организация, 8 - Профессия, 9 - Заметки, 0 - Выход");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.D1:
                                        Console.Write("Введите новое значение фамилии: ");
                                        surname = Console.ReadLine();
                                        while (surname == "")
                                        {
                                            Console.Write("Это обязательное поле, попробуйте внести ещё раз: ");
                                            surname = Console.ReadLine();
                                        }
                                        notes[Convert.ToInt32(idChange) - 1].Surname = surname;
                                        break;
                                    case ConsoleKey.D2:
                                        Console.Write("Введите новое значение имени: ");
                                        name = Console.ReadLine();
                                        while (name == "")
                                        {
                                            Console.Write("Это обязательное поле, попробуйте внести ещё раз: ");
                                            name = Console.ReadLine();
                                        }
                                        notes[Convert.ToInt32(idChange) - 1].Name = name;
                                        break;
                                    case ConsoleKey.D3:
                                        Console.Write("Введите новое значение отчества: ");
                                        patronymic = Console.ReadLine();
                                        notes[Convert.ToInt32(idChange) - 1].Patronymic = patronymic;
                                        break;
                                    case ConsoleKey.D4:
                                        Console.Write("Введите новое значение номера телефона: ");
                                        number = Console.ReadLine();
                                        while (number.Length != 10)
                                        {
                                            Console.Write("Должно быть 10 цифр, попробуйте внести ещё раз: ");
                                            number = Console.ReadLine();
                                        }
                                        notes[Convert.ToInt32(idChange) - 1].Number = number;
                                        break;
                                    case ConsoleKey.D5:
                                        Console.Write("Введите страну (0 - Россия, 1 - Украина, 2 - Беларусь, 3 - Казахстан): ");
                                        countryStr = Console.ReadLine();
                                        while (countryStr != "0" && countryStr != "1" && countryStr != "2" && countryStr != "3")
                                        {
                                            Console.Write("Введите страну (0 - Россия, 1 - Украина, 2 - Беларусь, 3 - Казахстан): ");
                                            countryStr = Console.ReadLine();
                                        }
                                        country = 0;
                                        switch (countryStr)
                                        {
                                            case "0":
                                                country = Countries.Russia;
                                                break;
                                            case "1":
                                                country = Countries.Ukraine;
                                                break;
                                            case "2":
                                                country = Countries.Belarus;
                                                break;
                                            case "3":
                                                country = Countries.Kazakhstan;
                                                break;
                                        }
                                        notes[Convert.ToInt32(idChange) - 1].Country = country;
                                        break;
                                    case ConsoleKey.D6:
                                        Console.Write("Введите дату рождения (или оставьте поле пустым): ");
                                        birthdayStr = Console.ReadLine();
                                        if (birthdayStr != "")
                                        {
                                            if (DateTime.TryParse(birthdayStr, out birthday))
                                            {
                                                notes[Convert.ToInt32(idChange) - 1].Birthday = birthday;
                                            }
                                        }
                                        break;
                                    case ConsoleKey.D7:
                                        Console.Write("Введите новое значение организации: ");
                                        organisation = Console.ReadLine();
                                        notes[Convert.ToInt32(idChange) - 1].Organisation = organisation;
                                        break;
                                    case ConsoleKey.D8:
                                        Console.Write("Введите новое значение профессии: ");
                                        profession = Console.ReadLine();
                                        notes[Convert.ToInt32(idChange) - 1].Profession = profession;
                                        break;
                                    case ConsoleKey.D9:
                                        Console.Write("Введите новые заметки: ");
                                        note = Console.ReadLine();
                                        notes[Convert.ToInt32(idChange) - 1].Notes = note;
                                        break;
                                    case ConsoleKey.D0:
                                        editStatus = false;
                                        break;
                                }
                            } while (editStatus);
                        }
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("----------------");
                        for (int i = 0; i < notes.Count; i++)
                        {
                            Console.WriteLine($"ID: {i + 1}\nФИО: {notes[i].Surname} {notes[i].Name} {notes[i].Patronymic}\nНомер телефона: {notes[i].Number}");
                            Console.WriteLine("----------------");
                        }
                        bool deleteStatus = false;
                        string idDelete;
                        do
                        {
                            Console.Write("Введите номер записи, которую необходимо удалить (либо -1, если хотите выйти): ");
                            idDelete = Console.ReadLine();
                            if (Int32.TryParse(idDelete, out int idDeleteInt))
                            {
                                if ((idDeleteInt >= 1 && idDeleteInt <= notes.Count) || idDeleteInt == -1) 
                                {
                                    deleteStatus = true;
                                }
                                else
                                {
                                    Console.WriteLine("ID введён некорректно.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("ID введён некорректно.");
                            }
                        } while (!deleteStatus);
                        if (Convert.ToInt32(idDelete) != -1)
                        {
                            notes.RemoveAt(Convert.ToInt32(idDelete) - 1);
                        }
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("----------------");
                        for (int i = 0; i < notes.Count; i++)
                        {
                            Console.WriteLine($"{notes[i]}");
                            Console.WriteLine("----------------");
                        }
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine("----------------");
                        for (int i = 0; i < notes.Count; i++)
                        {
                            Console.WriteLine($"ФИО: {notes[i].Surname} {notes[i].Name} {notes[i].Patronymic}\nНомер телефона: {notes[i].Number}");
                            Console.WriteLine("----------------");
                        }
                        break;
                    case ConsoleKey.D6:
                        Process.GetCurrentProcess().Kill();
                        break;
                }
            }
        }
        class Note
        {
            public string Surname { get; set; }
            public string Name { get; set; }
            public string Patronymic { get; set; }
            private string number;
            public string Number
            {
                get
                {
                    return number;
                }
                set
                {
                    char[] c = value.ToCharArray();
                    number = "";
                    number += "+7 (";
                    for (int i = 0; i < 3; i++)
                    {
                        number += c[i];
                    }
                    number += ") ";
                    for (int i = 3; i < 6; i++)
                    {
                        number += c[i];
                    }
                    number += "-";
                    for (int i = 6; i < 8; i++)
                    {
                        number += c[i];
                    }
                    number += "-";
                    for (int i = 8; i < 10; i++)
                    {
                        number += c[i];
                    }
                }
            }
            public Countries Country { get; set; }
            private string birthday;
            public DateTime Birthday
            {
                get
                {
                    if (DateTime.TryParse(birthday, out DateTime dateTime))
                    {
                        return dateTime;
                    }
                    else
                    {
                        return new DateTime(0);
                    }
                }
                set
                {
                    birthday = value.ToShortDateString();
                }
            }
            public string Organisation { get; set; }
            public string Profession { get; set; }
            public string Notes { get; set; }
            public override string ToString()
            {
                if (Birthday.Ticks != 0)
                {
                    return ($"ФИО: {Surname} {Name} {Patronymic}\nНомер телефона: {Number}\nСтрана: {Country}\nДень рождения: {Birthday}\nОрганизация: {Organisation}\nПрофессия: {Profession}\nЗаметки: {Notes}");
                }
                else
                {
                    return ($"ФИО: {Surname} {Name} {Patronymic}\nНомер телефона: {Number}\nСтрана: {Country}\nДень рождения: \nОрганизация: {Organisation}\nПрофессия: {Profession}\nЗаметки: {Notes}");
                }
            }
        }
        public enum Countries
        {
            Russia,
            Ukraine,
            Belarus,
            Kazakhstan
        }
    }
}
