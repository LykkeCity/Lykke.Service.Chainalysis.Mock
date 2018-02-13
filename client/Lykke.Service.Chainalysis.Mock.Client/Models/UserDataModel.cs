using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Service.ChainalysisMock.Client.Models
{
    public class UserDataModel
    {
        public string UserId { get; set; }
        public int LastActivity { get; set; }
        public string Score { get; set; }
        public int ScoreUpdatedDate { get; set; }
    }
}
