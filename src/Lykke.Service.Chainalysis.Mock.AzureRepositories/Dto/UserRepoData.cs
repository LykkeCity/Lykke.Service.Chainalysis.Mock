using System;
using System.Collections.Generic;
using System.Text;
using Lykke.Service.ChainalysisMock.Core.Domain;

namespace Lykke.Service.ChainalysisMock.AzureRepositories.Dto
{
    public class UserRepoData : IUserRepoData
    {
        public string UserId { get; set; }
        public int LastActivity { get; set; }
        public string Score { get; set; }
        public int ScoreUpdatedDate { get; set; }
        public int CreatedDate { get; set; }
    }
}
