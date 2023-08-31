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
    public interface ILanguagesService
    {
        IEnumerable<Languages> GetLanguages(string name = null);
        Languages GetLanguage(int id);
        Languages GetLanguageByName(string name);

        void CreateLanguage(Languages language);
        void DeleteLanguage(Languages language);
        void SaveLanguage();
    }

    public class LanguagesService : ILanguagesService
    {
        private readonly ILanguagesRepository LanguagesRepository;
        private readonly IUnitOfWork unitOfWork;

        public LanguagesService(ILanguagesRepository LanguagesRepository, IUnitOfWork unitOfWork)
        {
            this.LanguagesRepository = LanguagesRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<Languages> GetLanguages(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return LanguagesRepository.GetAll();
            else
                return LanguagesRepository.GetAll().Where(c => c.Language == name);
        }

        public Languages GetLanguage(int id)
        {
            var language = LanguagesRepository.GetById(id);
            return language;
        }

        public Languages GetLanguageByName(string name)
        {
            var language = LanguagesRepository.GetLanguageByName(name);
            return language;
        }
        public void CreateLanguage(Languages language)
        {
            LanguagesRepository.Add(language);
        }
        public void DeleteLanguage(Languages language)
        {
            LanguagesRepository.Delete(language);
        }
        public void SaveLanguage()
        {
            unitOfWork.Commit();
        }
    }
    #endregion

}