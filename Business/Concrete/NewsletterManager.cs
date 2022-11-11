using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class NewsletterManager : INewsletterService
    {
        private readonly INewsletterDal _newsletterDal;

        public NewsletterManager(INewsletterDal newsletterDal)
        {
            _newsletterDal = newsletterDal;
        }

        public void Add(Newsletter entity)
        {
            _newsletterDal.Add(entity);
        }

        public void Delete(Newsletter entity)
        {
            _newsletterDal.Delete(entity);
        }

        public Newsletter GetById(int id)
        {
            return _newsletterDal.GetById(id);
        }

        public List<Newsletter> GetList()
        {
            return _newsletterDal.GetList();
        }

        public void Update(Newsletter entity)
        {
            _newsletterDal.Update(entity);
        }
    }
}