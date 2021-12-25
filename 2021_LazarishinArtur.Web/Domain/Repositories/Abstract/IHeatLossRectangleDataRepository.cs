using _2021_LazarishinArtur.Web.Domain.Entities;
using System;
using System.Linq;

namespace _2021_LazarishinArtur.Web.Domain.Repositories.Abstract
{
    public interface IHeatLossRectangleDataRepository
    {
        IQueryable<HeatLossRectangleData> GetUserHeatLossCircleDatas(int userId);
        HeatLossRectangleData GetHeatLossCircleDataById(int id);
        void SeveHeatLossCircleData(HeatLossRectangleData entity);
        void DeleteHeatLossCircleData(int id);
    }
}
