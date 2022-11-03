using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class WriterManager : IWriterService
    {
        private readonly IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(User writer)
        {
            _writerDal.Add(writer);
        }

        public void Delete(User writer)
        {
            _writerDal.Delete(writer);
        }

        public User GetById(int id)
        {
            return _writerDal.GetById(id);
        }

        public List<User> GetList()
        {
            return _writerDal.GetList();
        }

        public List<User> GetWriterById(int id)
        {
            return _writerDal.GetList(x => x.Id == id);
        }

        public void Update(User writer)
        {
            _writerDal.Update(writer);
        }
    }
}