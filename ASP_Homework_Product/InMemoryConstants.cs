using ASP_Homework_Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASP_Homework_Product
{
    public class InMemoryConstants : IConstants
    {
        private List<LoginUser> Users = new List<LoginUser>();
        private LoginUser CurrentUser = null;
        private Guid SpareId = Guid.NewGuid();
        public Guid UserId = Guid.NewGuid();
        public void RegisterUser(LoginUser user)
        {
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

        public Guid GetUserId()
        {
            if(CurrentUser != null) return CurrentUser.Id;
            return SpareId; //Костыль. Пока не зареган никакой юзер пользователь добпаляет в ничью корзину и после регистрации эта корзина исчезает.
        }
        
    }

    public interface IConstants
    {
        public Guid GetUserId();
        public void RegisterUser(LoginUser user);
        public LoginUser LoginUser(LoginUser user);
    }
}
