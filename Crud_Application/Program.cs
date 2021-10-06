using System;
using System.Linq;
using Crud_Application.Model;
using Crud_Application.Context;
using System.Collections.ObjectModel;

namespace Crud_Application
{
    class Program
    {
        private static ObservableCollection<Player> Players { get; set; }


        public static int Action { get; set; }

         static void Main(string[] args)
         { 
        


            Players = new ObservableCollection<Player>();
            while (Action != 5)
            {

                try
                {

                    Console.WriteLine("Пожалуйста,укажите что вы хотите сделать?");
                    ListCommand();
                    Action = int.Parse(Console.ReadLine());
                    switch (Action)
                    {
                        case 1:
                            AppData.db.Player.Add(ActionPlayer(new Player()));
                            AppData.db.SaveChanges();
                            Console.WriteLine("Данные успешно добавлены!");
                            break;
                        case 2:
                            Console.WriteLine("Укажите ID: ");
                            int IdEditor = int.Parse(Console.ReadLine());
                            var selectItemEditor = AppData.db.Player.FirstOrDefault(item => item.ID == IdEditor);
                            if (selectItemEditor != null)
                            {
                                ActionPlayer(selectItemEditor);
                                AppData.db.SaveChanges();
                                Console.WriteLine("Данные успешно отредактированы!");
                            }
                            else
                            {
                                Console.WriteLine("Такого пользователя не существует!");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Укажите ID: ");
                            int IdRemove = int.Parse(Console.ReadLine());
                            var SelectedItemRemove = AppData.db.Player.FirstOrDefault(item => item.ID == IdRemove);
                            if (SelectedItemRemove != null)
                            {
                                AppData.db.Player.Remove(SelectedItemRemove);
                                AppData.db.SaveChanges();
                                Console.WriteLine("Данные успешно удалены!");
                            }
                            else
                            {
                                Console.WriteLine("Такого пользователя не существует!");
                            }
                            break;
                        case 4:
                            if (Players != null)
                            {
                                Players = new ObservableCollection<Player>(AppData.db.Player.ToList());
                                foreach (var item in Players)
                                {
                                    Console.WriteLine("ID: " + item.ID);
                                    Console.WriteLine("Имя: " + item.LastName);
                                    Console.WriteLine("Фамилия: " + item.FirstName);
                                    Console.WriteLine("Команда: " + item.Team);
                                    Console.WriteLine("Позиция: " + item.Position);
                                    Console.WriteLine("Возраст: " + item.Age);
                                    Console.WriteLine("-------------------------------------");
                                }


                            }
                            break;
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message, ex.Source);

                }


            }


         }



        private static void ListCommand()
        {
            Console.WriteLine("1. Добавить данные в базу данных");
            Console.WriteLine("2. Редактировать выбранный объект");
            Console.WriteLine("3. Удалить выбранный объект");
            Console.WriteLine("4. Отобразить существующие данные");
            Console.WriteLine("5. Выйти");
        }

        private static Player ActionPlayer(Player player)
        {
            if (player.ID != 0)
            {
                player = new Player();
            }

            Console.Write("Введите имя: ");
            player.LastName = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            player.FirstName = Console.ReadLine();
            Console.Write("Введите команду игрока: ");
            player.Team = Console.ReadLine();
            Console.Write("Введите позицию игрока: ");
            player.Position = Console.ReadLine();
            Console.Write("Введите возраст игрока: ");
            player.Age = int.Parse(Console.ReadLine());
            return player;


        }


    
    }
}
