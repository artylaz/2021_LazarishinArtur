using _2021_LazarishinArtur.Web.Domain;
using _2021_LazarishinArtur.Web.Domain.Repositories.EntityFramework;
using _2021_LazarishinArtur.Web.Models.UserViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _2021_LazarishinArtur.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly EFHeatLossCircleDataRepository heatLossCir;
        private readonly EFHeatLossRectangleDataRepository heatLossRec;
        private readonly EFHeatLossSquaredDataRepository heatLossSq;
        public UserController(AppDbContext context)
        {
            heatLossCir = new EFHeatLossCircleDataRepository(context);
            heatLossRec = new EFHeatLossRectangleDataRepository(context);
            heatLossSq = new EFHeatLossSquaredDataRepository(context);
        }

        [HttpGet]
        public IActionResult Calculate(CalculateViewModel viewModel)
        {
            if (viewModel.Id != default && viewModel.DateAdded != default)
                return View(viewModel);
            else
                return View(null);
        }

        [HttpGet]
        public IActionResult Calculations()
        {
            return View(GetByIdUserCalculateViewModels());
        }

        [HttpPost]
        public IActionResult Delete(int id, string windowShape)
        {
            if (windowShape == "Прямоугольное")
                heatLossRec.DeleteHeatLossCircleData(id);
            else if (windowShape == "Квадратное")
                heatLossSq.DeleteHeatLossCircleData(id);
            else if (windowShape == "Круглое")
                heatLossCir.DeleteHeatLossCircleData(id);

            return View("Calculations", GetByIdUserCalculateViewModels());
        }


        [HttpPost]
        public IActionResult Report(CalculateViewModel viewModel)
        {
            return View(viewModel);
        }


        private List<CalculateViewModel> GetByIdUserCalculateViewModels()
        {
            var list = new List<CalculateViewModel>();

            var heatLossRectangleDatas = heatLossRec.GetUserHeatLossCircleDatas(int.Parse(User.Claims.First().Value));
            var heatLossSquaredDatas = heatLossSq.GetUserHeatLossCircleDatas(int.Parse(User.Claims.First().Value));
            var heatLossCircleDatas = heatLossCir.GetUserHeatLossCircleDatas(int.Parse(User.Claims.First().Value));

            foreach (var item in heatLossRectangleDatas)
            {
                list.Add(new CalculateViewModel
                {
                    Id = item.Id,
                    DateAdded = item.DateAdded,
                    HeightWindow = item.HeightWindow,
                    Name = item.Name,
                    TempBake = item.TempBake,
                    WallThickness = item.WallThickness,
                    WidthWindow = item.WidthWindow,
                    WindowOpenTime = item.WindowOpenTime,
                    WindowShape = "Прямоугольное"

                });
            }

            foreach (var item in heatLossSquaredDatas)
            {
                list.Add(new CalculateViewModel
                {
                    Id = item.Id,
                    DateAdded = item.DateAdded,
                    SideLength = item.SideLength,
                    Name = item.Name,
                    TempBake = item.TempBake,
                    WallThickness = item.WallThickness,
                    WindowOpenTime = item.WindowOpenTime,
                    WindowShape = "Квадратное"

                });
            }

            foreach (var item in heatLossCircleDatas)
            {
                list.Add(new CalculateViewModel
                {
                    Id = item.Id,
                    DateAdded = item.DateAdded,
                    Diameter = item.Diameter,
                    Name = item.Name,
                    TempBake = item.TempBake,
                    WallThickness = item.WallThickness,
                    WindowOpenTime = item.WindowOpenTime,
                    WindowShape = "Круглое"

                });
            }

            return list;
        }
    }
}
