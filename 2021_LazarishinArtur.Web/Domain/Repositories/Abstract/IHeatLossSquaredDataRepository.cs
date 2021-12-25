using _2021_LazarishinArtur.Web.Domain.Entities;
using System;
using System.Linq;

namespace _2021_LazarishinArtur.Web.Domain.Repositories.Abstract
{
    public interface IHeatLossSquaredDataRepository
    {
        IQueryable<HeatLossSquaredData> GetUserHeatLossCircleDatas(int userId);
        HeatLossSquaredData GetHeatLossCircleDataById(int id);
        void SeveHeatLossCircleData(HeatLossSquaredData entity);
        void DeleteHeatLossCircleData(int id);
    }
}
