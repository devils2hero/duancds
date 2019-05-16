using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Model.CustomModels.API
{
    public class RoomCustom
    {
        public string _id { get; set; }
        public string Home_id { get; set; }
        public string Home_name { get; set; }
        public string Name { get; set; }
        public double Acreage { get; set; }
        public bool IsUsed { get; set; }
    }
}
