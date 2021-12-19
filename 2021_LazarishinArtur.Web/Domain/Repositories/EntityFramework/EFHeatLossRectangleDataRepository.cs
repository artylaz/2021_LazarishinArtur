using _2021_LazarishinArtur.Web.Domain.Entities;
using _2021_LazarishinArtur.Web.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _2021_LazarishinArtur.Web.Domain.Repositories.EntityFramework
{
    public class EFHeatLossRectangleDataRepository : IHeatLossRectangleDataRepository
    {
        private readonly AppDbContext context;
        public EFHeatLossRectangleDataRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void SeveHeatLossCircleData(HeatLossRectangleData entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;

            context.SaveChanges();
        }

        public void DeleteHeatLossCircleData(Guid id)
        {
            context.HeatLossRectangleDatas.Remove(new HeatLossRectangleData { Id = id });
            context.SaveChanges();
        }

        public HeatLossRectangleData GetHeatLossCircleDataById(Guid id)
        {
            return context.HeatLossRectangleDatas.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<HeatLossRectangleData> GetUserHeatLossCircleDatas(Guid userId)
        {
            return context.HeatLossRectangleDatas.Where(x => x.UserId == userId.ToString());
        }
    }
}
