using System;

namespace Lykke.Service.ChainalysisMock.Services.Extentions
{
    public static class DateTimePosix
    {
        public static int ToPosix(this DateTime dateTime)
        {
            return (int)(dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public static DateTime FromPosix(this int posixTime)
        {
            return new DateTime(1970, 1, 1).AddSeconds(posixTime).ToLocalTime();
        }
    }
}
