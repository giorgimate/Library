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
    public interface IAuthorsService
    {
        IEnumerable<Authors> GetAuthors(string name = null);
        //IEnumerable<Users> GetUserName(string name );
        Authors GetAuthor(int id);
        Authors GetAuthorByFirstname(string name);
        Authors GetAuthorByLastname(string name);
        //Users GetUserByUsername(string username);
        //Users GetUserByPassword(string password);
        void CreateAuthor(Authors author);
        void DeleteAuthor(Authors author);
        void SaveAuthor();
    }

    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorsRepository AuthorsRepository;
        private readonly IUnitOfWork unitOfWork;

        public AuthorsService(IAuthorsRepository AuthorsRepository, IUnitOfWork unitOfWork)
        {
            this.AuthorsRepository = AuthorsRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<Authors> GetAuthors(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return AuthorsRepository.GetAll();
            else
                return AuthorsRepository.GetAll().Where(c => c.FirstName == name);
        }

        public Authors GetAuthor(int id)
        {
            var author = AuthorsRepository.GetById(id);
            return author;
        }

        public Authors GetAuthorByFirstname(string name)
        {
            var author = AuthorsRepository.GetAuthorByFirstname(name);
            return author;
        }
        public Authors GetAuthorByLastname(string name)
        {
            var author = AuthorsRepository.GetAuthorByLastname(name);
            return author;
        }
        public void CreateAuthor(Authors author)
        {
            AuthorsRepository.Add(author);
        }
        public void DeleteAuthor(Authors author)
        {
            AuthorsRepository.Delete(author);
        }
        public void SaveAuthor()
        {
            unitOfWork.Commit();
        }
    }
    #endregion

}