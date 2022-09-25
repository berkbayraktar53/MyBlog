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

        public void Add(Newsletter newsletter)
        {
            _newsletterDal.Add(newsletter);
        }

        public List<Newsletter> GetList()
        {
            return _newsletterDal.GetList();
        }
    }
}