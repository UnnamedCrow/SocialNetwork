using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class AddFriendView
    {
        AddFriendService addFriendService;

        public AddFriendView(AddFriendService addFriendService)
        {
            this.addFriendService = addFriendService;
        }

        public void Show(User user)
        {
            // Создаём экземпляр класса для добавления друга
            var userAddFriendData = new UserAddfriendData();
            Console.WriteLine("Введите адрес аккаунта, который хотите добавить в друзья");
            userAddFriendData.UserFriendEmail = Console.ReadLine();
            userAddFriendData.UserId = user.Id;

            try
            {
                addFriendService.AddFriend(userAddFriendData);
                SuccessMessage.Show("Пользователь успешно добавлен в друзья");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь с таким почтовым адресом не найден");
            }
            catch(ArgumentNullException)
            {
                AlertMessage.Show("Введите корректный адрес");
            }
            catch(UserFoundException)
            {
                AlertMessage.Show("Этот пользователь уже находится у Вас в друзьях");
            }
            catch(Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении друга");
            }

        }
    }
}
