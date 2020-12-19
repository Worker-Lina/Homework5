using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Users;
using System.Text.RegularExpressions;
using ConsoleMenu;
using System.Collections.Generic;

namespace AppForRegistrationByPhone
{
    class Program
    {
        static void Main(string[] args)
        {
            string accountSid = "AC03798a1882921c7f150d85a1f9967***";
            string authToken = "ad39026ddd99dc8700deba5d111d5***";
            TwilioClient.Init(accountSid, authToken);

            List<User> users = new List<User>
            {
                new User("Мария","Цветаева","+77478902343",235467),
                new User("Дмитрий","Коршунов","+77471233454",902376),
                new User("Юрий","Шатунов","+77078901020",709345),
            };


            string[] items = { "Войти", "зарегистрироваться", "выйти" };
            var menu = new Menu(items);
            string choice;
            do
            {
                Console.Clear();
                menu.Print();
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Введите номер: ");
                        string phone = Console.ReadLine();
                        Console.Write("Введите пароль: ");
                        int password = int.Parse(Console.ReadLine());

                        bool succesful = false;
                        foreach(User user in users)
                        {
                            if(user.GetPhone()==phone && user.GetPassword() == password)
                            {
                                succesful = true;
                                Console.WriteLine($"{user.GetName()}, рады Вас видеть!");
                            }
                        }

                        if (!succesful)
                        {
                            Console.WriteLine("Произошла ошибка, попробуйте вновь");
                        }
                        break;
                    case "2":
                        {
                            Console.Clear();
                            Console.Write("Имя: ");
                            string name = Console.ReadLine();
                            Console.Write("Фамилия: ");
                            string surname = Console.ReadLine();

                            string pattern = "[+]{1}[7]{1}[0-9]{3}[0-9]{3}[0-9]{4}";
                            while (true)
                            {
                                Console.WriteLine("Введите номер в формате | +7XXXXXXXXXX  |");
                                phone = Console.ReadLine();
                                if (Regex.IsMatch(phone, pattern, RegexOptions.IgnoreCase))
                                {
                                    Console.WriteLine("ok");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Некорректно введен номер");
                                }
                            }


                            Random random = new Random();
                            int randomCode = random.Next(100000, 999999);
                            string code = randomCode.ToString();

                            var to = new PhoneNumber(phone);
                            var from = new PhoneNumber("+12059473430");

                            var message = MessageResource.Create(
                                to: to,
                                from: from,
                                body: code
                            );

                            Console.WriteLine("На ваш номер был выслан код");
                            Console.Write("Введите код для подверждения: ");
                            int inputCode = int.Parse(Console.ReadLine());

                            if (randomCode == inputCode)
                            {
                                users.Add(new User(name, surname, phone,randomCode));
                                Console.WriteLine($"{name}, Ваша регистрация прошла успешно!");
                            }
                            else
                            {
                                Console.WriteLine("Произошла ошибка, повторите попытку");
                            }
                        }
                        break;
                }
                Console.ReadKey();
            } while (choice != "3");
        }
    }
}
