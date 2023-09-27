using Store.Data.Infrastructure;
using Store.Data.Repositories;
using Store.Model;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Store.Service
{
    public interface IShalvesService
    {
        IEnumerable<Shalves> GetShalves(string name = null);
        Shalves GetShalve(int id);
        void CreateShalve(Shalves name);
        void DeleteShalve(Shalves name);
        void SaveShalve();
    }

    public class ShalvesService : IShalvesService
    {
        private readonly IShalvesRepository ShalvesRepository;
        private readonly IUnitOfWork unitOfWork;

        public ShalvesService(IShalvesRepository ShalvesRepository, IUnitOfWork unitOfWork)
        {
            this.ShalvesRepository = ShalvesRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<Shalves> GetShalves(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return ShalvesRepository.GetAll();
            else
                return ShalvesRepository.GetAll().Where(c => c.Section == name);
        }

        public Shalves GetShalve(int id)
        {
            var Shalve = ShalvesRepository.GetById(id);
            return Shalve;
        }

        public void CreateShalve(Shalves Shalve)
        {
            ShalvesRepository.Add(Shalve);
        }
        public void DeleteShalve(Shalves Shalve)
        {
            ShalvesRepository.Delete(Shalve);
        }

        public void SaveShalve()
        {
            unitOfWork.Commit();
        }



    }

    #endregion
}