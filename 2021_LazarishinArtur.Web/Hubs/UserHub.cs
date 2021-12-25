using _2021_LazarishinArtur.Web.Domain;
using _2021_LazarishinArtur.Web.Models.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2021_LazarishinArtur.Web.Domain.Repositories.EntityFramework;
using _2021_LazarishinArtur.Web.Domain.Entities;

namespace _2021_LazarishinArtur.Web.Hubs
{
    [Authorize]
    public class UserHub : Hub
    {
        private readonly EFHeatLossCircleDataRepository heatLossCir;
        private readonly EFHeatLossRectangleDataRepository heatLossRec;
        private readonly EFHeatLossSquaredDataRepository heatLossSq;
        public UserHub(AppDbContext context)
        {
            heatLossCir = new EFHeatLossCircleDataRepository(context);
            heatLossRec = new EFHeatLossRectangleDataRepository(context);
            heatLossSq = new EFHeatLossSquaredDataRepository(context);
        }

        public async Task Send(CalculateViewModel calculateVM)
        {

            await Clients.Caller.SendAsync("Receive", calculateVM);
        }

        public async Task Save(CalculateViewModel calculateVM)
        {
            if (calculateVM.WindowShape == "Прямоугольное")
            {
                heatLossRec.SeveHeatLossCircleData(new HeatLossRectangleData
                {
                    Id = calculateVM.Id,
                    UserId = int.Parse(Context.User.Claims.First().Value),
                    Name = calculateVM.Name,
                    DateAdded = DateTime.Now,
                    HeightWindow = calculateVM.HeightWindow,
                    TempBake = calculateVM.TempBake,
                    WallThickness = calculateVM.WallThickness,
                    WidthWindow = calculateVM.WidthWindow,
                    WindowOpenTime = calculateVM.WindowOpenTime,
                    ApertureRatio = calculateVM.GetApertureRatio,
                    RadiationHeatLoss = calculateVM.GetRadiationHeatLoss


                });

                await Clients.Caller.SendAsync("SaveCalculate", calculateVM.Name);

            }
            else if (calculateVM.WindowShape == "Квадратное")
            {
                heatLossSq.SeveHeatLossCircleData(new HeatLossSquaredData
                {
                    Id = calculateVM.Id,
                    UserId = int.Parse(Context.User.Identity.Name),
                    Name = calculateVM.Name,
                    DateAdded = DateTime.Now,
                    SideLength = calculateVM.SideLength,
                    TempBake = calculateVM.TempBake,
                    WallThickness = calculateVM.WallThickness,
                    WindowOpenTime = calculateVM.WindowOpenTime,
                    ApertureRatio = calculateVM.GetApertureRatio,
                    RadiationHeatLoss = calculateVM.GetRadiationHeatLoss
                });

                await Clients.Caller.SendAsync("SaveCalculate", calculateVM.Name);
            }
            else if (calculateVM.WindowShape == "Круглое")
            {
                heatLossCir.SeveHeatLossCircleData(new HeatLossCircleData
                {
                    Id = calculateVM.Id,
                    UserId = int.Parse(Context.User.Identity.Name),
                    Name = calculateVM.Name,
                    DateAdded = DateTime.Now,
                    Diameter = calculateVM.Diameter,
                    TempBake = calculateVM.TempBake,
                    WallThickness = calculateVM.WallThickness,
                    WindowOpenTime = calculateVM.WindowOpenTime,
                    ApertureRatio = calculateVM.GetApertureRatio,
                    RadiationHeatLoss = calculateVM.GetRadiationHeatLoss
                });

                await Clients.Caller.SendAsync("SaveCalculate", calculateVM.Name);
            }

        }

    }
}
