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

        public void Add(Writer writer)
        {
            _writerDal.Add(writer);
        }

        public List<Writer> GetList()
        {
            return _writerDal.GetList();
        }
    }
}