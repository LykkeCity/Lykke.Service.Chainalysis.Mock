using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lykke.Service.ChainalysisMock.Core.Domain;

namespace Lykke.Service.ChainalysisMock.Services.Dto
{
    public class UserInfo : IUserInfo
    {
        public UserInfo()
        {
            
        }

        public UserInfo(IUserRepoInfo info, IEnumerable<IUserRepoData> userData)
        {
            Total = info.Total;
            Limit = info.Limit;
            Offset = info.Offset;
            Data = userData.Cast<IUserData>().ToList();
        }

        public int Total { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public List<IUserData> Data { get; set; }
    }
}
