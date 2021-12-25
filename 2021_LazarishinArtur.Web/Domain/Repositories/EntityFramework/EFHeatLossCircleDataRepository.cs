using _2021_LazarishinArtur.Web.Domain.Entities;
using _2021_LazarishinArtur.Web.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _2021_LazarishinArtur.Web.Domain.Repositories.EntityFramework
{
    public class EFHeatLossCircleDataRepository : IHeatLossCircleDataRepository
    {
        private readonly AppDbContext context;
        public EFHeatLossCircleDataRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void SeveHeatLossCircleData(HeatLossCircleData entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;

            context.SaveChanges();
        }

        public void DeleteHeatLossCircleData(int id)
        {
            context.HeatLossCircleDatas.Remove(new HeatLossCircleData { Id = id });
            context.SaveChanges();
        }

        public HeatLossCircleData GetHeatLossCircleDataById(int id)
        {
            return context.HeatLossCircleDatas.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<HeatLossCircleData> GetUserHeatLossCircleDatas(int userId)
        {
            return context.HeatLossCircleDatas.Where(x => x.UserId == userId);
        }
    }
}
