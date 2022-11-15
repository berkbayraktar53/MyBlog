using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(About entity)
        {
            _aboutDal.Add(entity);
        }

        public void Delete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public About GetById(int id)
        {
            return _aboutDal.GetById(id);
        }

        public List<About> GetList()
        {
            return _aboutDal.GetList();
        }

        public List<About> GetListByActiveStatus()
        {
            return _aboutDal.GetList(x => x.Status == true);
        }

        public void Update(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}