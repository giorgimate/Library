using Store.Data.Infrastructure;
using Store.Data.Repositories;
using Store.Model;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service
{
    // operations you want to expose
    public interface IPublishersService
    {
        IEnumerable<Publishers> GetPublishers(string name = null);
        //IEnumerable<Users> GetUserName(string name );
        Publishers GetPublisher(int id);
        Publishers GetPublisherByName(string name);
        Publishers GetPublisherByPhoneNumber(string name);
        Publishers GetPublisherByEmail(string name);
        void CreatePublisher(Publishers publisher);
        void DeletePublisher(Publishers publisher);
        void SavePublisher();
    }

    public class PublishersService : IPublishersService
    {
        private readonly IPublishersRepository PublishersRepository;
        private readonly IUnitOfWork unitOfWork;

        public PublishersService(IPublishersRepository PublishersRepository, IUnitOfWork unitOfWork)
        {
            this.PublishersRepository = PublishersRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<Publishers> GetPublishers(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return PublishersRepository.GetAll();
            else
                return PublishersRepository.GetAll().Where(c => c.Name == name);
        }

        public Publishers GetPublisher(int id)
        {
            var publisher = PublishersRepository.GetById(id);
            return publisher;
        }

        public Publishers GetPublisherByName(string name)
        {
            var publisher = PublishersRepository.GetPublishersByName(name);
            return publisher;
        }
        public Publishers GetPublisherByPhoneNumber(string name)
        {
            var publisher = PublishersRepository.GetMembersByPhoneNumber(name);
            return publisher;
        }
        public Publishers GetPublisherByEmail(string name)
        {
            var publisher = PublishersRepository.GetPublishersByEmail(name);
            return publisher;
        }
        public void CreatePublisher(Publishers publisher)
        {
            PublishersRepository.Add(publisher);
        }
        public void DeletePublisher(Publishers publisher)
        {
            PublishersRepository.Delete(publisher);
        }
        public void SavePublisher()
        {
            unitOfWork.Commit();
        }
    }
    #endregion

}