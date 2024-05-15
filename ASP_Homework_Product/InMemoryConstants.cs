using ASP_Homework_Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASP_Homework_Product
{
    public class InMemoryConstants : IConstants
    {
        private List<LoginUser> Users = new List<LoginUser>() { new LoginUser() { Name="DefoltUser", Login="Defolt@def", Password="1234", Id=Guid.NewGuid(), Role=new Role() {Name="User" } } };
        private LoginUser CurrentUser = null;
        //private Guid SpareId = Guid.NewGuid();
        //public Guid UserId = Guid.NewGuid();

        public LoginUser GetUserById(Guid Id)
        {
            return Users.FirstOrDefault(x => x.Id == Id);
        }
        public void RegisterUser(LoginUser user)
        {
            user.Id = Guid.NewGuid();
            user.Role = new Role() { Name="User"};
            Users.Add(user);
            CurrentUser = user;
        }

        public LoginUser LoginUser(LoginUser user)
        {
            var logUser = Users.FirstOrDefault(u => user.Login == u.Login && user.Password == u.Password);
            if (logUser != null)
            {
                CurrentUser = logUser;
                return CurrentUser;
            }
            return null;
        }

        public List<LoginUser> GetUsers()
        {
            return Users;
        }

        public Guid GetUserId()
        {
            if(CurrentUser != null) return CurrentUser.Id;
            return Users[0].Id; //Костыль. Пока не зареган никакой юзер пользователь добпаляет в ничью корзину и после регистрации эта корзина исчезает.
        }

        public void ChangeUserDataInfo(Guid id, string newName, string newLogin)
        {
            foreach(var user in Users)
            {
                if(user.Id == id)
                {
                    user.Name = newName;
                    user.Login = newLogin;
                }
            }
        }
        
        public void ChangeUserPass(Guid id, string newPass)
        {
            foreach (var user in Users)
            {
                if (user.Id == id)
                {
                    user.Password = newPass;
                }
            }
        }

        public void ChangeUserRole(Guid id, string newRole)
        {
            foreach (var user in Users)
            {
                if (user.Id == id)
                {
                    user.Role.Name = newRole;
                }
            }
        }

        public void DeleteUser(Guid id)
        {
            var user = GetUserById(id);
            Users.Remove(user);
        }
    }

    public interface IConstants
    {
        public Guid GetUserId();
        public void RegisterUser(LoginUser user);
        public LoginUser LoginUser(LoginUser user);
        public List<LoginUser> GetUsers();
        public LoginUser GetUserById(Guid Id);
        public void ChangeUserDataInfo(Guid id, string newName, string newLogin);
        public void ChangeUserPass(Guid id, string newPass);
        public void ChangeUserRole(Guid id, string newRole);
        public void DeleteUser(Guid id);
    }
}
