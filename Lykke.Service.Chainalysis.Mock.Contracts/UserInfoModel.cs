using System.Collections.Generic;

namespace Lykke.Service.Chainalysis.Mock.Contracts
{
    public class UserInfoModel
    {
        public int Total { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public List<UserDataModel> Data { get; set; }
    }
}
