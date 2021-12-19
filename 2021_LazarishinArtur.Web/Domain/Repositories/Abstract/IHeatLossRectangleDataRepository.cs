using _2021_LazarishinArtur.Web.Domain.Entities;
using System;
using System.Linq;

namespace _2021_LazarishinArtur.Web.Domain.Repositories.Abstract
{
    public interface IHeatLossRectangleDataRepository
    {
        IQueryable<HeatLossRectangleData> GetUserHeatLossCircleDatas(Guid userId);
        HeatLossRectangleData GetHeatLossCircleDataById(Guid id);
        void SeveHeatLossCircleData(HeatLossRectangleData entity);
        void DeleteHeatLossCircleData(Guid id);
    }
}
