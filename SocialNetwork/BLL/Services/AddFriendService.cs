using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class AddFriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;
        public AddFriendService() 
        { 
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }

        public void AddFriend(UserAddfriendData userAddfriendData)
        {
            
            if (!new EmailAddressAttribute().IsValid(userAddfriendData.UserFriendEmail))
                throw new ArgumentNullException();
            var findUserEntity = userRepository.FindByEmail(userAddfriendData.UserFriendEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            var friendEntityFounded = friendRepository.FindFriendById(findUserEntity.id);
            if (findUserEntity != null) throw new UserFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = userAddfriendData.UserId,
                friend_id = findUserEntity.id
            };

            if (friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
    }
}
