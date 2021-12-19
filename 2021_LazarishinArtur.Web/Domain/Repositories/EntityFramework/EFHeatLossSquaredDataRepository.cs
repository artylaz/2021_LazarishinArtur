using _2021_LazarishinArtur.Web.Domain.Entities;
using _2021_LazarishinArtur.Web.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _2021_LazarishinArtur.Web.Domain.Repositories.EntityFramework
{
    public class EFHeatLossSquaredDataRepository : IHeatLossSquaredDataRepository
    {
        private readonly AppDbContext context;
        public EFHeatLossSquaredDataRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void SeveHeatLossCircleData(HeatLossSquaredData entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;

            context.SaveChanges();
        }

        public void DeleteHeatLossCircleData(Guid id)
        {
            context.HeatLossSquaredDatas.Remove(new HeatLossSquaredData { Id = id });
            context.SaveChanges();
        }

        public HeatLossSquaredData GetHeatLossCircleDataById(Guid id)
        {
            return context.HeatLossSquaredDatas.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<HeatLossSquaredData> GetUserHeatLossCircleDatas(Guid userId)
        {
            return context.HeatLossSquaredDatas.Where(x => x.UserId == userId.ToString());
        }
    }
}
