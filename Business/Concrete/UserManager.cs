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

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public User GetById(int userId)
        {
            return _userDal.GetById(userId);
        }

        public List<User> GetList()
        {
            return _userDal.GetList();
        }

        public List<User> GetListWithBlog()
        {
            return _userDal.GetListWithBlog();
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}