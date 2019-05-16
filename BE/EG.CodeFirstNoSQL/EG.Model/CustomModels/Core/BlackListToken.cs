using System;

namespace EG.Model.CustomModels.Core
{
    public class BlackListToken
    {
        public string Id { get; set; }
        public string Token { get; set; }
        public DateTime Expried { get; set; }
    }
}
