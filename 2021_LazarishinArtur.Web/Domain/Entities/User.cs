using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace _2021_LazarishinArtur.Web.Domain.Entities
{
    public class User : IdentityUser
    {
        public List<HeatLossCircleData> HeatLossCircleDatas { get; set; }
        public List<HeatLossRectangleData> HeatLossRectangleDatas { get; set; }
        public List<HeatLossSquaredData> HeatLossSquaredDatas { get; set; }
    }
}
