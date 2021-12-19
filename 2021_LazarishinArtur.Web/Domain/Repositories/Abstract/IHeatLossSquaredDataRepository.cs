using _2021_LazarishinArtur.Web.Domain.Entities;
using System;
using System.Linq;

namespace _2021_LazarishinArtur.Web.Domain.Repositories.Abstract
{
    public interface IHeatLossSquaredDataRepository
    {
        IQueryable<HeatLossSquaredData> GetUserHeatLossCircleDatas(Guid userId);
        HeatLossSquaredData GetHeatLossCircleDataById(Guid id);
        void SeveHeatLossCircleData(HeatLossSquaredData entity);
        void DeleteHeatLossCircleData(Guid id);
    }
}
