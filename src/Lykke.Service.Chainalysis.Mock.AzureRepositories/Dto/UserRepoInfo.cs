using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lykke.Service.ChainalysisMock.Core.Domain;

namespace Lykke.Service.ChainalysisMock.AzureRepositories.Dto
{
    public class UserRepoInfo : IUserRepoInfo
    {
        public UserRepoInfo()
        {
            Limit = 0;
            Offset = 0;
        }

        public UserRepoInfo(IEnumerable<IUserRepoData> users)
        {
            Data = users.ToList();
            Total = Data.Count;
        }

        public int Total { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public List<IUserRepoData> Data { get; set; }
    }
}
