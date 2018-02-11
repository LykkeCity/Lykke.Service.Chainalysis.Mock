﻿using System;
using System.Collections.Generic;
using System.Text;
using Lykke.Service.ChainalysisMock.Core.Domain;

namespace Lykke.Service.ChainalysisMock.Services.Dto
{
    public class UserDetails : IUserDetails
    {
        public UserDetails()
        {
            ExposureDetails = new List<IUserExplosureDetails> {new UserExplosureDetails()};
        }
        public string UserId { get; set; }
        public int CreationDate { get; set; }
        public string Comment { get; set; }
        public int LastActivity { get; set; }
        public string Score { get; set; }
        public int ScoreUpdatedDate { get; set; }
        public List<IUserExplosureDetails> ExposureDetails { get; set; }
    }
}
