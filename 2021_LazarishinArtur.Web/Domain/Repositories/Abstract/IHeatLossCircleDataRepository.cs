using _2021_LazarishinArtur.Web.Domain.Entities;
using System;
using System.Linq;

namespace _2021_LazarishinArtur.Web.Domain.Repositories.Abstract
{
    public interface IHeatLossCircleDataRepository
    {
        IQueryable<HeatLossCircleData> GetUserHeatLossCircleDatas(Guid userId);
        HeatLossCircleData GetHeatLossCircleDataById(Guid id);
        void SeveHeatLossCircleData(HeatLossCircleData entity);
        void DeleteHeatLossCircleData(Guid id);
    }
}
