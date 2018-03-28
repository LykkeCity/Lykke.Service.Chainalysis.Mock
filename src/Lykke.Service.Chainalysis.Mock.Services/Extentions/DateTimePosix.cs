using System;

namespace Lykke.Service.ChainalysisMock.Services.Extentions
{
    public static class DateTimePosix
    {
        public static long ToPosix(this DateTime dateTime)
        {
            return (long)(dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public static DateTime FromPosix(this long posixTime)
        {
            return new DateTime(1970, 1, 1).AddSeconds(posixTime).ToLocalTime();
        }
    }
}
