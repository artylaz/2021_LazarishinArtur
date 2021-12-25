using _2021_LazarishinArtur.Web.Domain.Entities;
using System;
using System.Linq;

namespace _2021_LazarishinArtur.Web.Domain.Repositories.Abstract
{
    public interface IHeatLossCircleDataRepository
    {
        IQueryable<HeatLossCircleData> GetUserHeatLossCircleDatas(int userId);
        HeatLossCircleData GetHeatLossCircleDataById(int id);
        void SeveHeatLossCircleData(HeatLossCircleData entity);
        void DeleteHeatLossCircleData(int id);
    }
}
