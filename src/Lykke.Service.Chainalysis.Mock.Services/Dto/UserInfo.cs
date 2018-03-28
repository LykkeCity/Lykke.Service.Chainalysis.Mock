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

        public long Total { get; set; }
        public long Limit { get; set; }
        public long Offset { get; set; }
        public List<IUserData> Data { get; set; }
    }
}
