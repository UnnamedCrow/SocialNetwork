using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork
{
    internal class Program
    {
        public static UserSevice userSevice = new UserSevice();
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в социальную сеть");

            while (true)
            {



                Console.Write("Для регистрации пользователя введите имя пользователя:");
                string firstName = Console.ReadLine();

                Console.Write("фамилия: ");
                string lastName = Console.ReadLine();

                Console.Write("пароль: ");
                string password = Console.ReadLine();

                Console.Write("почтовый адрес: ");
                string email = Console.ReadLine();

                UserRegistrationData userRegistrationData = new UserRegistrationData()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password,
                    Email = email
                };

                try
                {
                    userSevice.Register(userRegistrationData);
                    Console.WriteLine("Регистрация прошла успешно!");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Введите корректные данные");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка регистрации");
                }

                Console.ReadLine();
            }
        }
    }
}