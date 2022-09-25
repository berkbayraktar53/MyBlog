using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public List<About> GetList()
        {
            return _aboutDal.GetList();
        }
    }
}