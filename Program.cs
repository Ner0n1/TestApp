using System;
using System.Configuration;
using EntityWords;
using DictionaryLibrary;
using TextHandling;


namespace AutoCompleteDictionary
{
    class Program
    {
        static void Main(string[] args)
        {            
            DBDictionary<TextProcessing> DBIO = new DBDictionary<TextProcessing>();       


                if (args.Length != 0)
                {
                    if (args[0] == ConfigurationManager.AppSettings["CreateDictionary"])
                    {
                        DBIO.Create();
                        Console.WriteLine("Словарь создан.");
                        Environment.Exit(0);
                    }

                    if (args[0] == ConfigurationManager.AppSettings["UpdateDictionary"])
                    {
                        TextProcessing w = new TextProcessing();
                        Console.WriteLine("Укажите путь к файлу:");
                        string path = Console.ReadLine();                        
                        DBIO.Update(w, path);
                        Console.WriteLine("Обновление завершено.");
                    }

                    if (args[0] == ConfigurationManager.AppSettings["DeleteDictionary"])
                    {
                        DBIO.Delete();
                        Console.WriteLine("Удаление завершено.");
                        Environment.Exit(0);
                    }
                }

            ConsoleKeyInfo cki;
            string searchWord = string.Empty;           
            do
            {               
                               
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Escape)
                    break;                
                searchWord = Console.ReadLine();
                if (cki.Key >= ConsoleKey.A && cki.Key <= ConsoleKey.Z)
                    searchWord = cki.KeyChar + searchWord;
                if (searchWord == "")
                    break;                
                searchWord.ToLower();
                var result = DBIO.Search(searchWord);
                foreach (Words w in result)
                    Console.WriteLine($"{w.Word}");
            }
            while (true); ;
        }   
    }
}
