using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserDal _userDal;

        public UserManager(UserManager<User> userManager, IUserDal userDal)
        {
            _userManager = userManager;
            _userDal = userDal;
        }

        public void Add(User entity)
        {
            _userDal.Add(entity);
        }

        public void AddAsync(User user)
        {
            _userManager.CreateAsync(user);
        }

        public void Delete(User entity)
        {
            _userDal.Delete(entity);
        }

        public void DeleteAsync(User user)
        {
            _userManager.DeleteAsync(user);
        }

        public User GetById(int userId)
        {
            return _userDal.GetById(userId);
        }

        public List<User> GetLast10UserList()
        {
            return _userDal.GetList().TakeLast(10).OrderByDescending(x => x.Id).ToList();
        }

        public List<User> GetList()
        {
            return _userDal.GetList();
        }

        public List<User> GetListWithBlog()
        {
            return _userDal.GetListWithBlog();
        }

        public void Update(User entity)
        {
            _userDal.Update(entity);
        }

        public void UpdateAsync(User user)
        {
            _userManager.UpdateAsync(user);
        }
    }
}