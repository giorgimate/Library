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
    // operations you want to expose
    public interface IPositionsService
    {
        IEnumerable<Positions> GetPositions(string name = null);
        //IEnumerable<Users> GetUserName(string name );
        Positions GetPositionByID(int id);
        Positions GetPositionByPositionTitle(string PositionTitle);

        void CreatePosition(Positions Position);
        void DeletePosition(Positions Position);
        void SavePosition();
    }

    public class PositionsService : IPositionsService
    {
        private readonly IPositionsRepository PositionsRepository;
        private readonly IUnitOfWork unitOfWork;

        public PositionsService(IPositionsRepository PositionsRepository, IUnitOfWork unitOfWork)
        {
            this.PositionsRepository = PositionsRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<Positions> GetPositions(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return PositionsRepository.GetAll();
            else
                return PositionsRepository.GetAll().Where(c => c.PositionTitle == name);
        }

        public Positions GetPositionByPositionTitle(string PositonTitle)
        {
            var Position = PositionsRepository.GetPositionByPositionTitle(PositonTitle);
            return Position;
        }

        public Positions GetPositionByID(int id)
        {
            var Position = PositionsRepository.GetById(id);
            return Position;
        }

        public void CreatePosition(Positions position)
        {
            PositionsRepository.Add(position);
        }
        public void DeletePosition(Positions position)
        {
            PositionsRepository.Delete(position);
        }

        public void SavePosition()
        {
            unitOfWork.Commit();
        }

    }

    #endregion
}