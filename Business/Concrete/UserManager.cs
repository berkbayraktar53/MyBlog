using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetById(int userId)
        {
            return _userDal.GetById(userId);
        }

        public List<User> GetList()
        {
            return _userDal.GetList();
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}