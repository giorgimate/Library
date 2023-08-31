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
    public interface IGenresService
    {
        IEnumerable<Genres> GetGenres(string name = null);
        Genres GetGenre(int id);
        Genres GetGenreByName(string name);

        void CreateGenre(Genres genre);
        void DeleteGenre(Genres genre);
        void SaveGenre();
    }

    public class GenresService : IGenresService
    {
        private readonly IGenresRepository GenresRepository;
        private readonly IUnitOfWork unitOfWork;

        public GenresService(IGenresRepository GenresRepository, IUnitOfWork unitOfWork)
        {
            this.GenresRepository = GenresRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<Genres> GetGenres(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return GenresRepository.GetAll();
            else
                return GenresRepository.GetAll().Where(c => c.Name == name);
        }

        public Genres GetGenre(int id)
        {
            var genre = GenresRepository.GetById(id);
            return genre;
        }

        public Genres GetGenreByName(string name)
        {
            var genre = GenresRepository.GetGenreByName(name);
            return genre;
        }
        public void CreateGenre(Genres genre)
        {
            GenresRepository.Add(genre);
        }
        public void DeleteGenre(Genres genre)
        {
            GenresRepository.Delete(genre);
        }
        public void SaveGenre()
        {
            unitOfWork.Commit();
        }
    }
    #endregion

}